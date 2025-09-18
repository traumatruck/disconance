namespace Disconance.Models.Guilds;

/// <summary>
///     Represents a Discord guild.
///     https://discord.com/developers/docs/resources/guild#guild-object
/// </summary>
public class Guild
{
    /// <summary>
    ///     Guild ID.
    /// </summary>
    public Snowflake Id { get; set; }

    /// <summary>
    ///     Guild name (2-100 characters, excluding trailing and leading whitespace).
    /// </summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    ///     Icon hash.
    /// </summary>
    public string? Icon { get; set; }

    /// <summary>
    ///     Icon hash, returned when in the template object.
    /// </summary>
    public string? IconHash { get; set; }

    /// <summary>
    ///     Splash hash.
    /// </summary>
    public string? Splash { get; set; }

    /// <summary>
    ///     Discovery splash hash; only present for guilds with the "DISCOVERABLE" feature.
    /// </summary>
    public string? DiscoverySplash { get; set; }

    /// <summary>
    ///     True if the user is the owner of the guild.
    /// </summary>
    public bool? Owner { get; set; }

    /// <summary>
    ///     ID of owner.
    /// </summary>
    public Snowflake OwnerId { get; set; }

    /// <summary>
    ///     Total permissions for the user in the guild (excludes overwrites and implicit permissions).
    /// </summary>
    public string? Permissions { get; set; }

    /// <summary>
    ///     Voice region ID for the guild (deprecated).
    /// </summary>
    public string? Region { get; set; }

    /// <summary>
    ///     ID of AFK channel.
    /// </summary>
    public Snowflake? AfkChannelId { get; set; }

    /// <summary>
    ///     AFK timeout in seconds.
    /// </summary>
    public int AfkTimeout { get; set; }

    /// <summary>
    ///     True if the server widget is enabled.
    /// </summary>
    public bool? WidgetEnabled { get; set; }

    /// <summary>
    ///     The channel ID that the widget will generate an invite to, or null if set to no invite.
    /// </summary>
    public Snowflake? WidgetChannelId { get; set; }

    /// <summary>
    ///     Verification level required for the guild.
    /// </summary>
    public int VerificationLevel { get; set; }

    /// <summary>
    ///     Default message notifications level.
    /// </summary>
    public int DefaultMessageNotifications { get; set; }

    /// <summary>
    ///     Explicit content filter level.
    /// </summary>
    public int ExplicitContentFilter { get; set; }

    /// <summary>
    ///     Roles in the guild.
    /// </summary>
    public List<object> Roles { get; set; } = new(); // TODO: Role objects

    /// <summary>
    ///     Custom guild emojis.
    /// </summary>
    public List<object> Emojis { get; set; } = new(); // TODO: Emoji objects

    /// <summary>
    ///     Enabled guild features.
    /// </summary>
    public List<string> Features { get; set; } = new();

    /// <summary>
    ///     Required MFA level for the guild.
    /// </summary>
    public int MfaLevel { get; set; }

    /// <summary>
    ///     Application ID of the guild creator if it is bot-created.
    /// </summary>
    public Snowflake? ApplicationId { get; set; }

    /// <summary>
    ///     The ID of the channel where guild notices such as welcome messages and boost events are posted.
    /// </summary>
    public Snowflake? SystemChannelId { get; set; }

    /// <summary>
    ///     System channel flags.
    /// </summary>
    public int SystemChannelFlags { get; set; }

    /// <summary>
    ///     The ID of the channel where Community guilds can display rules and/or guidelines.
    /// </summary>
    public Snowflake? RulesChannelId { get; set; }

    /// <summary>
    ///     The maximum number of presences for the guild (null is always returned, apart from the largest of guilds).
    /// </summary>
    public int? MaxPresences { get; set; }

    /// <summary>
    ///     The maximum number of members for the guild.
    /// </summary>
    public int? MaxMembers { get; set; }

    /// <summary>
    ///     The vanity URL code for the guild.
    /// </summary>
    public string? VanityUrlCode { get; set; }

    /// <summary>
    ///     The description of a guild.
    /// </summary>
    public string? Description { get; set; }

    /// <summary>
    ///     Banner hash.
    /// </summary>
    public string? Banner { get; set; }

    /// <summary>
    ///     Premium tier (Server Boost level).
    /// </summary>
    public int PremiumTier { get; set; }

    /// <summary>
    ///     The number of boosts this guild currently has.
    /// </summary>
    public int? PremiumSubscriptionCount { get; set; }

    /// <summary>
    ///     The preferred locale of a Community guild; used in server discovery and notices from Discord, and sent in interactions. Defaults to "en-US".
    /// </summary>
    public string PreferredLocale { get; set; } = "en-US";

    /// <summary>
    ///     The ID of the channel where admins and moderators of Community guilds receive notices from Discord.
    /// </summary>
    public Snowflake? PublicUpdatesChannelId { get; set; }

    /// <summary>
    ///     The maximum amount of users in a video channel.
    /// </summary>
    public int? MaxVideoChannelUsers { get; set; }

    /// <summary>
    ///     The maximum amount of users in a stage video channel.
    /// </summary>
    public int? MaxStageVideoChannelUsers { get; set; }

    /// <summary>
    ///     Approximate number of members in this guild.
    /// </summary>
    public int? ApproximateMemberCount { get; set; }

    /// <summary>
    ///     Approximate number of non-offline members in this guild.
    /// </summary>
    public int? ApproximatePresenceCount { get; set; }

    /// <summary>
    ///     The welcome screen of a Community guild, shown to new members, returned in an Invite's guild object.
    /// </summary>
    public object? WelcomeScreen { get; set; } // TODO: Welcome screen object

    /// <summary>
    ///     Guild NSFW level.
    /// </summary>
    public int NsfwLevel { get; set; }

    /// <summary>
    ///     Custom guild stickers.
    /// </summary>
    public List<object> Stickers { get; set; } = new(); // TODO: Sticker objects

    /// <summary>
    ///     Whether the guild has the boost progress bar enabled.
    /// </summary>
    public bool PremiumProgressBarEnabled { get; set; }

    /// <summary>
    ///     The ID of the channel where admins and moderators of Community guilds receive safety alerts from Discord.
    /// </summary>
    public Snowflake? SafetyAlertsChannelId { get; set; }
}
