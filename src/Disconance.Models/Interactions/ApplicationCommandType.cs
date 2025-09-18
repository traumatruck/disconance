namespace Disconance.Models.Interactions;

/// <summary>
///     Type of application command.
/// </summary>
public enum ApplicationCommandType
{
    /// <summary>
    ///     Slash commands; a text-based command that shows up when a user types /
    /// </summary>
    ChatInput = 1,

    /// <summary>
    ///     A UI-based command that shows up when you right click or tap on a user
    /// </summary>
    User = 2,

    /// <summary>
    ///     A UI-based command that shows up when you right click or tap on a message
    /// </summary>
    Message = 3,

    /// <summary>
    ///     A UI-based command that represents the primary way to invoke an app's Activity
    /// </summary>
    PrimaryEntryPoint = 4
}