namespace Disconance.Interactions.Commands;

/// <summary>
///     Represents a group of subcommands that belong to a base command. This class provides an abstract base for defining
///     and organizing subcommands under a specified group.
/// </summary>
/// <typeparam name="TBaseCommand">
///     The type of the base command to which this subcommand group belongs. Must inherit from
///     <see cref="BaseCommand{T}" />.
/// </typeparam>
/// <typeparam name="TSubcommandGroup">
///     The specific type of the subcommand group extending this class. Must implement
///     <see cref="ISubcommandGroup{TBaseCommand}" />.
/// </typeparam>
public abstract class SubcommandGroup<TBaseCommand, TSubcommandGroup>(
    IEnumerable<ISubcommand<TBaseCommand, TSubcommandGroup>> subcommands)
    : ISubcommandGroup<TBaseCommand>
    where TBaseCommand : BaseCommand<TBaseCommand>
    where TSubcommandGroup : ISubcommandGroup<TBaseCommand>
{
    /// <summary>
    ///     Represents a collection of subcommands associated with this subcommand group.
    /// </summary>
    public IEnumerable<ISubcommand<TBaseCommand, TSubcommandGroup>> Subcommands { get; } = subcommands;

    /// <inheritdoc />
    public abstract string Name { get; }

    /// <inheritdoc />
    public abstract string Description { get; }
}