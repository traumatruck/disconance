using Disconance.Models.Interactions;

namespace Disconance.Interactions.Commands;

/// <summary>
///     Defines the behavior contract to execute a command interaction asynchronously.
/// </summary>
public interface ICommandBehavior
{
    /// <summary>
    ///     Executes a command interaction asynchronously.
    /// </summary>
    /// <param name="interaction">The interaction object containing details of the command to be executed.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>
    ///     A task representing the asynchronous operation, with an <see cref="InteractionResponse" /> containing the
    ///     result of the execution.
    /// </returns>
    Task<InteractionResponse> ExecuteAsync(Interaction interaction, CancellationToken cancellationToken = default);
}