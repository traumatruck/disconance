using Disconance.Models.Interactions;

namespace Disconance.Interactions.Commands;

/// <summary>
///     Represents a modal form that can be submitted via a Modal message response. Implementations of this interface
///     define a modal by its unique identifier and handle the behavior upon submission of the modal.
/// </summary>
public interface IModalForm
{
    /// <summary>
    ///     Gets the unique identifier for the modal form. This identifier is used to match modal submissions to their
    ///     corresponding modal implementation.
    /// </summary>
    string ModalId { get; }

    /// <summary>
    ///     Handles the submission of a modal within the interaction framework and returns a response. This method is invoked
    ///     when a modal is submitted, allowing for custom handling of its data.
    /// </summary>
    /// <param name="interaction">The interaction object that encapsulates the submitted modal data.</param>
    /// <param name="cancellationToken">A token for propagating cancellation notification.</param>
    /// <returns>A task that represents the result of the modal form submission as an <see cref="InteractionResponse" />.</returns>
    Task<InteractionResponse> OnModalSubmitAsync(Interaction interaction,
        CancellationToken cancellationToken = default);
}