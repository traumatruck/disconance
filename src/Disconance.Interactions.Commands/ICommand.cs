namespace Disconance.Interactions.Commands;

/// <summary>
///     Represents a command interface used to define basic properties of a command.
/// </summary>
public interface ICommand
{
    /// <summary>
    ///     Represents the unique name of a command. This property is used to identify and differentiate commands. It is
    ///     expected to provide a string representation that uniquely identifies the implementing command within its context.
    /// </summary>
    string Name { get; }

    /// <summary>
    ///     Provides a detailed, human-readable description of the command. This property is used to explain the functionality
    ///     or purpose of the command within its context, aiding users in understanding its behavior.
    /// </summary>
    string Description { get; }
}