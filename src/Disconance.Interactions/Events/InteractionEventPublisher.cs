using System.Collections.Immutable;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Disconance.Interactions.Events;

/// <summary>
///     Default event publisher. Fans out to all subscribers using a per-publish scope and does not block the request
///     pipeline.
/// </summary>
public sealed class InteractionEventPublisher(
    IServiceScopeFactory scopeFactory,
    ILogger<InteractionEventPublisher> logger
) : IInteractionEventPublisher
{
    public Task PublishAsync(InteractionReceivedContext context, CancellationToken cancellationToken = default)
    {
        // Fire-and-forget background dispatch to avoid delaying the HTTP response
        _ = Task.Run(async () =>
        {
            using var scope = scopeFactory.CreateScope();
            var serviceProvider = scope.ServiceProvider;
            
            var subscribers = serviceProvider.GetServices<IInteractionEventSubscriber>().ToImmutableArray();
            var tasks = subscribers.Select(subscriber => NotifySubscriberAsync(subscriber, context, cancellationToken));
            
            await Task.WhenAll(tasks);
        }, CancellationToken.None);

        return Task.CompletedTask;
    }

    private async Task NotifySubscriberAsync(
        IInteractionEventSubscriber subscriber,
        InteractionReceivedContext context,
        CancellationToken cancellationToken)
    {
        try
        {
            await subscriber.OnInteractionAsync(context, cancellationToken);
        }
        catch (Exception exception)
        {
            // Never throw out of a subscriber; just log and continue.
            // This ensures one faulty subscriber doesn't break others.
            logger.LogError(exception, "Unhandled exception in interaction event subscriber: {SubscriberType}",
                subscriber.GetType().FullName);
        }
    }
}