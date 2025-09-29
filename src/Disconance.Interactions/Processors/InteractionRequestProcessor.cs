using System.Text.Json;
using Disconance.Http.Json;
using Disconance.Interactions.Commands;
using Disconance.Interactions.Middleware;
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
    IMessageComponentHandler messageComponentHandler,
    IInteractionMiddlewarePipeline interactionMiddlewarePipeline
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

        // Execute middleware pipeline
        var context = new InteractionReceivedContext
        {
            Interaction = interactionRequest
        };
        
        try
        {
            var interactionResponse = await interactionMiddlewarePipeline.InvokeAsync(context,
                async () => await ProcessInteractionRequestByTypeAsync(interactionRequest.Type, interactionRequest) ??
                            throw new InvalidOperationException("Interaction response cannot be null"));

            return new SuccessfulInteractionRequestProcessorResult
            {
                InteractionResponse = interactionResponse
            };
        }
        catch (Exception)
        {
            return new FailedInteractionRequestProcessorResult
            {
                ErrorMessage = $"Failed to process interaction request of type {interactionRequest.Type}."
            };
        }
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