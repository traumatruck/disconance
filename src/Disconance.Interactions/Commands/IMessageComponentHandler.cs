using Disconance.Models.Interactions;

namespace Disconance.Interactions.Commands;

/// <summary>
///     Defines a handler responsible for processing message components in interaction requests.
/// </summary>
public interface IMessageComponentHandler
{
    /// <summary>
    ///     Processes an interaction request for a message component and returns a corresponding interaction response.
    /// </summary>
    /// <param name="interaction">The interaction object containing data for the message component to be processed.</param>
    /// <param name="cancellationToken">A cancellation token that can be used to cancel the asynchronous operation.</param>
    /// <returns>
    ///     A task representing the asynchronous operation. The task result contains the interaction response generated
    ///     after processing the message component.
    /// </returns>
    Task<InteractionResponse> HandleAsync(Interaction interaction, CancellationToken cancellationToken = default);
}