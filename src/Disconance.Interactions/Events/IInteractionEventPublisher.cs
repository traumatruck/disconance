namespace Disconance.Interactions.Events;

/// <summary>
///     Publishes interaction events to all subscribers.
/// </summary>
public interface IInteractionEventPublisher
{
    /// <summary>
    ///     Publish an interaction event to all subscribers. Non-blocking by default in the default implementation.
    /// </summary>
    Task PublishAsync(InteractionReceivedContext context, CancellationToken cancellationToken = default);
}