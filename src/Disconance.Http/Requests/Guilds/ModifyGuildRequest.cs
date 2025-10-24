using Disconance.Models;
using Disconance.Models.Guilds;

namespace Disconance.Http.Requests.Guilds;

/// <summary>
///     Modify a guild's settings. Requires the MANAGE_GUILD permission.
///     Returns the updated guild object on success. Fires a Guild Update Gateway event.
///     All parameters to this endpoint are optional.
/// </summary>
/// <param name="GuildId">The ID of the guild to modify.</param>
public record ModifyGuildRequest(Snowflake GuildId) : IRequest<Guild>
{
    /// <summary>
    ///     ID for afk channel.
    /// </summary>
    public Snowflake? AfkChannelId { get; set; }

    /// <summary>
    ///     AFK timeout in seconds, can be set to: 60, 300, 900, 1800, 3600.
    /// </summary>
    public int? AfkTimeout { get; set; }

    /// <summary>
    ///     Base64 16:9 png/jpeg image for the guild banner (when the server has the BANNER feature).
    /// </summary>
    public string? Banner { get; set; }

    /// <summary>
    ///     Default message notification level.
    /// </summary>
    public int? DefaultMessageNotifications { get; set; }

    /// <summary>
    ///     The description for the guild.
    /// </summary>
    public string? Description { get; set; }

    /// <summary>
    ///     Base64 16:9 png/jpeg image for the guild discovery splash (when the server has the DISCOVERABLE feature).
    /// </summary>
    public string? DiscoverySplash { get; set; }

    /// <summary>
    ///     Explicit content filter level.
    /// </summary>
    public int? ExplicitContentFilter { get; set; }

    /// <summary>
    ///     Enabled guild features.
    /// </summary>
    public List<string>? Features { get; set; }

    /// <summary>
    ///     Base64 1024x1024 png/jpeg/gif image for the guild icon (can be animated gif when the server has the ANIMATED_ICON
    ///     feature).
    /// </summary>
    public string? Icon { get; set; }

    public HttpMethod Method => HttpMethod.Patch;

    /// <summary>
    ///     Guild name.
    /// </summary>
    public string? Name { get; set; }

    /// <summary>
    ///     The ID of the owner to transfer guild ownership to (bot must be owner).
    /// </summary>
    public Snowflake? OwnerId { get; set; }

    public string Path => $"guilds/{GuildId}";

    /// <summary>
    ///     The preferred locale of a Community guild used in server discovery and notices from Discord; defaults to "en-US".
    /// </summary>
    public string? PreferredLocale { get; set; }

    /// <summary>
    ///     Whether the guild's boost progress bar should be enabled.
    /// </summary>
    public bool? PremiumProgressBarEnabled { get; set; }

    /// <summary>
    ///     The ID of the channel where admins and moderators of Community guilds receive notices from Discord.
    /// </summary>
    public Snowflake? PublicUpdatesChannelId { get; set; }

    /// <summary>
    ///     Guild voice region id (deprecated).
    /// </summary>
    public string? Region { get; set; }

    /// <summary>
    ///     The ID of the channel where Community guilds display rules and/or guidelines.
    /// </summary>
    public Snowflake? RulesChannelId { get; set; }

    /// <summary>
    ///     The ID of the channel where admins and moderators of Community guilds receive safety alerts from Discord.
    /// </summary>
    public Snowflake? SafetyAlertsChannelId { get; set; }

    /// <summary>
    ///     Base64 16:9 png/jpeg image for the guild splash (when the server has the INVITE_SPLASH feature).
    /// </summary>
    public string? Splash { get; set; }

    /// <summary>
    ///     System channel flags.
    /// </summary>
    public int? SystemChannelFlags { get; set; }

    /// <summary>
    ///     The ID of the channel where guild notices such as welcome messages and boost events are posted.
    /// </summary>
    public Snowflake? SystemChannelId { get; set; }

    /// <summary>
    ///     Verification level.
    /// </summary>
    public int? VerificationLevel { get; set; }
}