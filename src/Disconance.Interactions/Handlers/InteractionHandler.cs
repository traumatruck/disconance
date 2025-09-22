using System.Text;
using System.Text.Json;
using Disconance.Core.Configuration;
using Disconance.Http.Json;
using Disconance.Interactions.Processors;
using Disconance.Interactions.Processors.Results;
using Disconance.Interactions.Security;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Disconance.Interactions.Handlers;

public class InteractionHandler(
    IInteractionRequestProcessor interactionRequestProcessor,
    IInteractionSecurityHandler securityHandler,
    ILogger<InteractionHandler> logger,
    IOptions<DisconanceOptions> disconanceOptions,
    IOptions<DiscordJsonOptions> jsonOptions
) : IInteractionHandler
{
    public async Task<IResult> HandleInteractionAsync(HttpRequest interactionRequest)
    {
        logger.LogTrace("Processing interaction request");

        var signature = interactionRequest.Headers["X-Signature-Ed25519"].FirstOrDefault();
        var timestamp = interactionRequest.Headers["X-Signature-Timestamp"].FirstOrDefault();

        var bodyBytes = new byte[interactionRequest.ContentLength ?? 0];
        await interactionRequest.Body.ReadExactlyAsync(bodyBytes);
        var requestBody = Encoding.UTF8.GetString(bodyBytes);

        if (signature == null || timestamp == null)
        {
            logger.LogWarning("Received interaction request without required headers");
            return Results.BadRequest();
        }

        if (!securityHandler.ValidateInteractionSignature(requestBody, signature, timestamp,
                disconanceOptions.Value.PublicKey))
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
    }
}