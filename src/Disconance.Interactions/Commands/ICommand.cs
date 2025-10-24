using Disconance.Models.Interactions;

namespace Disconance.Interactions.Commands;

public interface ICommand
{
    string Description { get; }

    string Name { get; }

    ApplicationCommandType Type { get; }
}