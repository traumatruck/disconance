namespace Disconance.Models.Interactions;

/// <summary>
///     Context in Discord where an interaction can be used, or where it was triggered from.
///     https://discord.com/developers/docs/interactions/receiving-and-responding#interaction-object-interaction-context-types
/// </summary>
public enum InteractionContextType
{
    /// <summary>
    ///     Interaction can be used within servers
    /// </summary>
    // GUILD
    Guild = 0,

    /// <summary>
    ///     Interaction can be used within DMs with the app's bot user
    /// </summary>
    // BOT_DM
    BotDm = 1,

    /// <summary>
    ///     Interaction can be used within Group DMs and DMs other than the app's bot user
    /// </summary>
    // PRIVATE_CHANNEL
    PrivateChannel = 2
}