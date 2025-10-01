using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using Disconance.Core.Configuration;
using Disconance.Http.Json;
using Disconance.Interactions.Processors.Results;
using Disconance.Interactions.Security;
using Disconance.Models.Interactions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Disconance.Interactions.Processors;

/// <summary>
///     Processes interaction requests received from the application.
/// </summary>
public class InteractionRequestProcessor(
    IOptions<DisconanceOptions> disconanceOptions,
    IOptions<DiscordJsonOptions> discordJsonOptions,
    IInteractionHandler interactionHandler,
    IInteractionSecurityHandler interactionSecurityHandler,
    ILogger<InteractionRequestProcessor> logger
) : IInteractionRequestProcessor
{
    /// <inheritdoc />
    public async Task<IInteractionRequestProcessorResult> ProcessInteractionRequestAsync(HttpRequest interactionRequest)
    {
        logger.LogTrace("Processing interaction request...");

        var signature = interactionRequest.Headers["X-Signature-Ed25519"].FirstOrDefault();
        var timestamp = interactionRequest.Headers["X-Signature-Timestamp"].FirstOrDefault();
        var bodyBytes = new byte[interactionRequest.ContentLength ?? 0];
        await interactionRequest.Body.ReadExactlyAsync(bodyBytes);

        if (signature == null || timestamp == null)
        {
            const string errorMessage = "Received interaction request without required headers.";
            logger.LogWarning(errorMessage);

            return new FailedInteractionRequestProcessorResult
            {
                ErrorMessage = errorMessage
            };
        }

        var requestBody = Encoding.UTF8.GetString(bodyBytes);

        if (!interactionSecurityHandler.ValidateInteractionSignature(requestBody, signature, timestamp,
                disconanceOptions.Value.PublicKey))
        {
            const string errorMessage = "Received interaction request with invalid signature.";
            logger.LogWarning(errorMessage);
            
            return new UnauthorizedInteractionRequestProcessorResult
            {
                ErrorMessage = errorMessage
            };
        }

        logger.LogDebug("Received interaction request data: {RequestBody}", requestBody);

        var serializerOptions = discordJsonOptions.Value.SerializerOptions;
        var interaction = JsonSerializer.Deserialize<Interaction>(requestBody, serializerOptions);

        if (interaction == null)
        {
            const string errorMessage = "Failed to deserialize interaction request.";
            logger.LogError(errorMessage);
            
            return new FailedInteractionRequestProcessorResult
            {
                ErrorMessage = errorMessage
            };
        }

        InteractionResponse interactionResponse;

        if (interaction.Type == InteractionType.Ping)
        {
            interactionResponse = new InteractionResponse
            {
                Type = InteractionCallbackType.Pong
            };
        }
        else
        {
            interactionResponse = await interactionHandler.HandleInteractionAsync(interaction);
        }

        var serializedInteractionResponse = JsonSerializer.Serialize(interactionResponse, serializerOptions);

        return new SuccessfulInteractionRequestProcessorResult
        {
            InteractionResponse = interactionResponse,
            SerializedInteractionResponse = serializedInteractionResponse
        };
    }
}