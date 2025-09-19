namespace Disconance.Interactions.Commands;

/// <summary>
///     Represents a subcommand.
/// </summary>
/// <typeparam name="T">
///     The generic type parameter that must inherit from <see cref="BaseCommand{T}" />. This associates the subcommand
///     with its base command.
/// </typeparam>
// ReSharper disable once UnusedTypeParameter
public interface ISubcommand<out T> : ICommand, ICommandBehavior where T : BaseCommand<T>;

/// <summary>
///     Represents a subcommand that belongs to a subcommand group.
/// </summary>
/// <typeparam name="TBaseCommand">
///     The type of the base command associated with the subcommand. This must inherit from <see cref="BaseCommand{T}" />
///     to associate it with the relevant command structure.
/// </typeparam>
/// <typeparam name="TSubcommandGroup">
///     The type of the subcommand group to which this subcommand belongs. This must implement
///     <see cref="ISubcommandGroup{TBaseCommand}" /> to define the group of related subcommands.
/// </typeparam>
// ReSharper disable once UnusedTypeParameter
public interface ISubcommand<TBaseCommand, TSubcommandGroup> : ICommand, ICommandBehavior
    where TBaseCommand : BaseCommand<TBaseCommand>
    where TSubcommandGroup : ISubcommandGroup<TBaseCommand>;