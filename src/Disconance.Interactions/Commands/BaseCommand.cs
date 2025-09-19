namespace Disconance.Interactions.Commands;

/// <summary>
///     Represents the base class for defining a command with associated subcommands and subcommand groups. This class
///     establishes injecting the subcommands and subcommand groups into the derived command.
/// </summary>
/// <typeparam name="T">
///     Type parameter constrained to the derived command type.
/// </typeparam>
public abstract class BaseCommand<T>(
    IEnumerable<ISubcommand<T>> subcommands,
    IEnumerable<ISubcommandGroup<T>> subcommandGroups
) : IBaseCommand where T : BaseCommand<T>
{
    /// <inheritdoc />
    public abstract string Name { get; }

    /// <inheritdoc />
    public abstract string Description { get; }

    /// <inheritdoc />
    public IEnumerable<ICommand> Subcommands => subcommands;

    /// <inheritdoc />
    public IEnumerable<ISubcommandGroup> SubcommandGroups => subcommandGroups;
}