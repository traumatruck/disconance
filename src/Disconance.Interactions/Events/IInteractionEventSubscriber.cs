namespace Disconance.Interactions.Events;

/// <summary>
///     Implement to receive notifications for every inbound interaction request.
/// </summary>
public interface IInteractionEventSubscriber
{
    /// <summary>
    ///     Handles an interaction asynchronously when it is received.
    /// </summary>
    /// <param name="context">The interaction context containing details about the received interaction.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    Task OnInteractionAsync(InteractionReceivedContext context, CancellationToken cancellationToken = default);
}