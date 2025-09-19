using Disconance.Models.Interactions;

namespace Disconance.Interactions.Commands;

/// <summary>
///     Represents the interface for handling interactive message components within the system.
/// </summary>
public interface IMessageComponent
{
    /// <summary>
    ///     Gets the unique identifier associated with the message component.
    /// </summary>
    /// <remarks>
    ///     This identifier is used to match the component involved in an interaction to its corresponding handler.
    /// </remarks>
    string ComponentId { get; }

    /// <summary>
    ///     Handles the interaction for a message component received from Discord.
    /// </summary>
    /// <param name="interaction">The interaction object containing details about the event and its context.</param>
    /// <param name="cancellationToken">
    ///     A cancellation token used to propagate notification that the operation should be canceled.
    /// </param>
    /// <returns>An <see cref="InteractionResponse" /> representing the response to the interaction.</returns>
    Task<InteractionResponse> OnMessageComponentInteractionAsync(Interaction interaction,
        CancellationToken cancellationToken = default);
}