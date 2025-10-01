namespace Disconance.Interactions.Commands;

/// <summary>
///     Represents a simple command that combines the basic properties of a command and the behavior for executing it
///     asynchronously. Simple commands are used to define commands that do not have subcommands or subcommand groups.
/// </summary>
/// <remarks>
///     The <see cref="ISimpleCommand" /> interface inherits from both <see cref="ICommand" />
///     for core command attributes such as name and description, and <see cref="ICommandBehavior" />
///     for defining the execution behavior of the command.
/// </remarks>
public interface ISimpleCommand : ICommand, ICommandBehavior;