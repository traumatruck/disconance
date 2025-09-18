namespace Disconance.Models.Applications;

/// <summary>
///     Application flags.
/// </summary>
[Flags]
public enum ApplicationFlags
{
    /// <summary>
    ///     Indicates if an app uses the Auto Moderation API.
    /// </summary>
    AutoModerationRuleCreateBadge = 1 << 6,

    /// <summary>
    ///     Intent required for bots in 100 or more servers to receive presence_update events.
    /// </summary>
    GatewayPresence = 1 << 12,

    /// <summary>
    ///     Intent required for bots in 100 or more servers to receive member-related events like guild_member_add.
    /// </summary>
    GatewayPresenceLimited = 1 << 13,

    /// <summary>
    ///     Intent required for bots in 100 or more servers to receive message events.
    /// </summary>
    GatewayGuildMembers = 1 << 14,

    /// <summary>
    ///     Intent required for bots in 100 or more servers to receive message events.
    /// </summary>
    GatewayGuildMembersLimited = 1 << 15,

    /// <summary>
    ///     Indicates unusual growth of an app that prevents verification.
    /// </summary>
    GatewayMessageContent = 1 << 18,

    /// <summary>
    ///     Indicates unusual growth of an app that prevents verification.
    /// </summary>
    GatewayMessageContentLimited = 1 << 19,

    /// <summary>
    ///     Indicates if an app is embedded within the Discord client.
    /// </summary>
    Embedded = 1 << 17,

    /// <summary>
    ///     Intent required for bots in 100 or more servers to receive message events.
    /// </summary>
    MessageContent = 1 << 18,

    /// <summary>
    ///     Intent required for bots in 100 or more servers to receive message events.
    /// </summary>
    MessageContentLimited = 1 << 19
}