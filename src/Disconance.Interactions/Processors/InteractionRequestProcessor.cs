using System.Text.Json;
using Disconance.Http.Json;
using Disconance.Interactions.Commands;
using Disconance.Interactions.Processors.Results;
using Disconance.Models.Interactions;
using Microsoft.Extensions.Options;

namespace Disconance.Interactions.Processors;

/// <summary>
///     Processes interaction requests received from the application.
/// </summary>
public class InteractionRequestProcessor(
    ICommandProcessor commandProcessor,
    IOptions<DiscordJsonOptions> jsonOptions,
    IModalSubmitHandler modalSubmitHandler,
    IMessageComponentHandler messageComponentHandler
) : IInteractionRequestProcessor
{
    /// <inheritdoc />
    public async Task<IInteractionRequestProcessorResult> ProcessInteractionRequestAsync(string requestData)
    {
        var interactionRequest =
            JsonSerializer.Deserialize<Interaction>(requestData, jsonOptions.Value.SerializerOptions);

        if (interactionRequest == null)
        {
            return new FailedInteractionRequestProcessorResult
            {
                ErrorMessage = "Failed to deserialize interaction request."
            };
        }

        var interactionRequestType = interactionRequest.Type;

        var interactionResponse =
            await ProcessInteractionRequestByTypeAsync(interactionRequestType, interactionRequest);

        if (interactionResponse == null)
        {
            return new FailedInteractionRequestProcessorResult
            {
                ErrorMessage = $"Failed to process interaction request of type {interactionRequestType}."
            };
        }

        return new SuccessfulInteractionRequestProcessorResult
        {
            InteractionResponse = interactionResponse
        };
    }

    private async Task<InteractionResponse?> ProcessInteractionRequestByTypeAsync(
        InteractionType interactionCallbackType, Interaction interaction)
    {
        return interactionCallbackType switch
        {
            InteractionType.Ping => new InteractionResponse
            {
                Type = InteractionCallbackType.Pong
            },
            InteractionType.ApplicationCommand => await commandProcessor.ProcessCommandAsync(interaction),
            InteractionType.MessageComponent => await messageComponentHandler.HandleAsync(interaction),
            InteractionType.ModalSubmit => await modalSubmitHandler.HandleAsync(interaction),
            _ => null
        };
    }
}