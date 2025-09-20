using System.Text;
using System.Text.Json;
using Disconance.Configuration;
using Disconance.Http.Json;
using Disconance.Interactions.Attributes;
using Disconance.Interactions.Commands;
using Disconance.Interactions.Processors;
using Disconance.Interactions.Processors.Results;
using Disconance.Interactions.Security;
using Disconance.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Disconance.Interactions.Extensions;

public static class WebApplicationExtensions
{
    public static async Task UseInteractionsAsync(this WebApplication webApplication)
    {
        webApplication.MapPost("api/interactions", async (
            HttpContext context,
            IOptions<DisconanceOptions> disconanceOptions,
            IInteractionRequestProcessor interactionRequestProcessor,
            ILogger logger,
            IInteractionSecurityHandler securityHandler,
            IOptions<DiscordJsonOptions> jsonOptions) =>
        {
            logger.LogTrace("Received interaction request");

            var signature = context.Request.Headers["X-Signature-Ed25519"].FirstOrDefault();
            var timestamp = context.Request.Headers["X-Signature-Timestamp"].FirstOrDefault();

            if (signature == null || timestamp == null)
            {
                logger.LogWarning("Received interaction request without required headers");
                return Results.BadRequest();
            }

            var bodyBytes = new byte[context.Request.ContentLength ?? 0];
            await context.Request.Body.ReadExactlyAsync(bodyBytes);
            var requestBody = Encoding.UTF8.GetString(bodyBytes);
            var publicKey = disconanceOptions.Value.PublicKey;

            if (!securityHandler.ValidateInteractionSignature(requestBody, signature, timestamp, publicKey))
            {
                logger.LogWarning("Interaction request failed security validation");
                return Results.Unauthorized();
            }

            logger.LogDebug("Received interaction request data: {RequestBody}", requestBody);

            try
            {
                var interactionRequestResult =
                    await interactionRequestProcessor.ProcessInteractionRequestAsync(requestBody);

                switch (interactionRequestResult)
                {
                    case SuccessfulInteractionRequestProcessorResult successfulResult:
                    {
                        var jsonResponse = JsonSerializer.Serialize(successfulResult.InteractionResponse,
                            jsonOptions.Value.SerializerOptions);

                        return Results.Content(jsonResponse, "application/json");
                    }
                    case FailedInteractionRequestProcessorResult failedResult:
                        logger.LogWarning("Failed to process interaction request: {ErrorMessage}",
                            failedResult.ErrorMessage);
                        return Results.Problem(failedResult.ErrorMessage);
                    default:
                        logger.LogError("Unexpected interaction request result type: {ResultType}",
                            interactionRequestResult.GetType());

                        return Results.Problem();
                }
            }
            catch (Exception exception)
            {
                logger.LogError(exception, "Failed to process interaction request");
                return Results.Problem("Failed to process interaction request");
            }
        });

        // Register commands on startup
        using var scope = webApplication.Services.CreateScope();
        var commandRegisterer = scope.ServiceProvider.GetRequiredService<ICommandRegistrar>();
        var applicationLifetime = scope.ServiceProvider.GetRequiredService<IHostApplicationLifetime>();
        var commandAssemblies = CommandAssemblyAttribute.GetCommandAssemblies();

        foreach (var commandAssembly in commandAssemblies)
        {
            var commandAttributes = commandAssembly.CustomAttributes.Where(attribute =>
                attribute.AttributeType == typeof(CommandAssemblyAttribute));

            foreach (var attribute in commandAttributes)
            {
                var guildId = attribute.ConstructorArguments.SingleOrDefault().Value as Snowflake?;
                
                await commandRegisterer.RegisterCommandsAsync(commandAssembly, guildId,
                    applicationLifetime.ApplicationStopping);
            }
        }
    }
}