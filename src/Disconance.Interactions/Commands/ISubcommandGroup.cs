namespace Disconance.Interactions.Commands;

/// <summary>
///     Represents a command group containing subcommands. This interface extends the ICommand interface and is designed to
///     define a logical grouping of related subcommands.
/// </summary>
public interface ISubcommandGroup : ICommand;

/// <summary>
///     Defines a grouping of related subcommands within a command structure. This interface extends the ICommand
///     interface, enabling logical organization of subcommands that share a common purpose or behavior.
/// </summary>
// ReSharper disable once UnusedTypeParameter
public interface ISubcommandGroup<out TBaseCommand> : ISubcommandGroup;