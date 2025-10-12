using Disconance.Models.Interactions;

namespace Disconance.Interactions.Commands.Components;

public abstract class MessageComponent<T> : IMessageComponent where T : class, IMessageComponent
{
    public abstract Func<T, IServiceProvider, Task> ConfigureAsync { get; }

    public abstract string Name { get; }

    public abstract Task<InteractionResponse> ExecuteAsync(Interaction interaction,
        CancellationToken cancellationToken = default);
}