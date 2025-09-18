namespace Disconance.Models.Interactions;

/// <summary>
///     Handler type for entry point commands.
/// </summary>
public enum EntryPointCommandHandlerType
{
    /// <summary>The app handles the interaction using an interaction token</summary>
    AppHandler = 1,

    /// <summary>
    ///     Discord handles the interaction by launching an Activity and sending a follow-up message without coordinating
    ///     with the app
    /// </summary>
    DiscordLaunchActivity = 2
}