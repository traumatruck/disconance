namespace Disconance.Interactions.Commands;

/// <summary>
///     Represents the base interface for a command containing subcommands and subcommand groups.
/// </summary>
public interface IBaseCommand : ICommand
{
    /// <summary>
    ///     Gets the collection of subcommands associated with the command.
    /// </summary>
    /// <remarks>
    ///     Subcommands represent distinct smaller commands within a parent command.
    ///     Each subcommand has its own name and behavior, allowing modular and organized
    ///     command structures.
    /// </remarks>
    IEnumerable<ICommand> Subcommands { get; }

    /// <summary>
    ///     Gets the collection of subcommand groups associated with the command.
    /// </summary>
    /// <remarks>
    ///     Subcommand groups are used to organize related subcommands into cohesive groups, providing a hierarchical structure
    ///     within command definitions. Each subcommand group may contain multiple subcommands that share a common context or
    ///     purpose.
    /// </remarks>
    IEnumerable<ISubcommandGroup> SubcommandGroups { get; }
}