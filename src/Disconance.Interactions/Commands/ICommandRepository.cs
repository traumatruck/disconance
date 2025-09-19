namespace Disconance.Interactions.Commands;

/// <summary>
///     Represents a repository for managing various types of commands, including simple commands, base commands,
///     subcommand groups, and individual subcommands.
/// </summary>
public interface ICommandRepository
{
    /// <summary>
    ///     Retrieves all commands, including simple commands, base commands,
    ///     subcommand groups, and individual subcommands.
    /// </summary>
    /// <returns>An enumerable collection of all commands available in the repository.</returns>
    IEnumerable<ICommand> GetAllCommands();

    /// <summary>
    ///     Retrieves all simple commands available in the repository.
    /// </summary>
    /// <returns>An enumerable collection of simple commands.</returns>
    IEnumerable<ISimpleCommand> GetSimpleCommands();

    /// <summary>
    ///     Retrieves all base commands available in the repository. Base commands are the foundational units that may contain
    ///     subcommands or subcommand groups.
    /// </summary>
    /// <returns>An enumerable collection of base commands.</returns>
    IEnumerable<IBaseCommand> GetBaseCommands();

    /// <summary>
    ///     Retrieves all subcommand groups available in the repository.
    /// </summary>
    /// <returns>An enumerable collection of subcommand groups.</returns>
    IEnumerable<ICommand> GetSubcommandGroups();

    /// <summary>
    ///     Retrieves all subcommands available in the repository, including those associated with subcommand groups and those
    ///     without groups.
    /// </summary>
    /// <returns>An enumerable collection of subcommands available in the repository.</returns>
    IEnumerable<ICommand> GetSubcommands();
}