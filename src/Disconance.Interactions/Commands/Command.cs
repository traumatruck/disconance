using Disconance.Models.Interactions;

namespace Disconance.Interactions.Commands;

public abstract class Command : ICommand
{
    public abstract Func<ApplicationCommand, IServiceProvider, Task> ConfigureAsync { get; }

    public abstract string Description { get; }

    public abstract string Name { get; }

    public abstract ApplicationCommandType Type { get; }
}