using Disconance.Models.Interactions;

namespace Disconance.Interactions.Commands;

/// <summary>
///     Represents a handler that processes modal submit interactions within the Discord application.
/// </summary>
public interface IModalSubmitHandler
{
    /// <summary>
    ///     Handles a modal submit interaction and processes it to generate an interaction response.
    /// </summary>
    /// <param name="interaction">The interaction instance containing the details of the modal submission.</param>
    /// <param name="cancellationToken">
    ///     A cancellation token that can be used to signal the cancellation of the asynchronous operation.
    /// </param>
    /// <returns>
    ///     A task that represents the asynchronous operation, containing the generated <see cref="InteractionResponse" />.
    /// </returns>
    Task<InteractionResponse> HandleAsync(Interaction interaction, CancellationToken cancellationToken = default);
}