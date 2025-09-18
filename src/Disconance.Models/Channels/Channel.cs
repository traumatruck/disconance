using Disconance.Models.Users;

namespace Disconance.Models.Channels;

/// <summary>
///     Represents a guild or DM channel within Discord.
/// </summary>
public class Channel
{
    /// <summary>
    ///     The id of this channel.
    /// </summary>
    public Snowflake Id { get; set; }

    /// <summary>
    ///     The type of channel.
    /// </summary>
    public ChannelType Type { get; set; }

    /// <summary>
    ///     The id of the guild (may be missing for some channel objects received over gateway guild dispatches).
    /// </summary>
    public Snowflake? GuildId { get; set; }

    /// <summary>
    ///     Sorting position of the channel (channels with the same position are sorted by id).
    /// </summary>
    public int? Position { get; set; }

    /// <summary>
    ///     Explicit permission overwrites for members and roles.
    /// </summary>
    public List<Overwrite>? PermissionOverwrites { get; set; }

    /// <summary>
    ///     The name of the channel (1-100 characters).
    /// </summary>
    public string? Name { get; set; }

    /// <summary>
    ///     The channel topic (0-4096 characters for GUILD_FORUM and GUILD_MEDIA channels, 0-1024 characters for all others).
    /// </summary>
    public string? Topic { get; set; }

    /// <summary>
    ///     Whether the channel is nsfw.
    /// </summary>
    public bool? Nsfw { get; set; }

    /// <summary>
    ///     The id of the last message sent in this channel (or thread for GUILD_FORUM or GUILD_MEDIA channels).
    /// </summary>
    public Snowflake? LastMessageId { get; set; }

    /// <summary>
    ///     The bitrate (in bits) of the voice channel.
    /// </summary>
    public int? Bitrate { get; set; }

    /// <summary>
    ///     The user limit of the voice channel.
    /// </summary>
    public int? UserLimit { get; set; }

    /// <summary>
    ///     Amount of seconds a user has to wait before sending another message (0-21600).
    /// </summary>
    public int? RateLimitPerUser { get; set; }

    /// <summary>
    ///     The recipients of the DM.
    /// </summary>
    public List<User>? Recipients { get; set; }

    /// <summary>
    ///     Icon hash of the group DM.
    /// </summary>
    public string? Icon { get; set; }

    /// <summary>
    ///     Id of the creator of the group DM or thread.
    /// </summary>
    public Snowflake? OwnerId { get; set; }

    /// <summary>
    ///     Application id of the group DM creator if it is bot-created.
    /// </summary>
    public Snowflake? ApplicationId { get; set; }

    /// <summary>
    ///     For group DM channels: whether the channel is managed by an application via the gdm.join OAuth2 scope.
    /// </summary>
    public bool? Managed { get; set; }

    /// <summary>
    ///     For guild channels: id of the parent category for a channel (each parent category can contain up to 50 channels), for threads: id of the text channel this thread was created.
    /// </summary>
    public Snowflake? ParentId { get; set; }

    /// <summary>
    ///     When the last pinned message was pinned. This may be null in events such as GUILD_CREATE when a message is not pinned.
    /// </summary>
    public DateTimeOffset? LastPinTimestamp { get; set; }

    /// <summary>
    ///     Voice region id for the voice channel, automatic when set to null.
    /// </summary>
    public string? RtcRegion { get; set; }

    /// <summary>
    ///     The camera video quality mode of the voice channel, 1 when not present.
    /// </summary>
    public VideoQualityMode? VideoQualityMode { get; set; }

    /// <summary>
    ///     Number of messages (not including the initial message or deleted messages) in a thread.
    /// </summary>
    public int? MessageCount { get; set; }

    /// <summary>
    ///     An approximate count of users in a thread, stops counting at 50.
    /// </summary>
    public int? MemberCount { get; set; }

    /// <summary>
    ///     Thread-specific fields not needed by other channels.
    /// </summary>
    public ThreadMetadata? ThreadMetadata { get; set; }

    /// <summary>
    ///     Thread member object for the current user, if they have joined the thread, only included on certain API endpoints.
    /// </summary>
    public ThreadMember? Member { get; set; }

    /// <summary>
    ///     Default duration, copied onto newly created threads, in minutes.
    /// </summary>
    public int? DefaultAutoArchiveDuration { get; set; }

    /// <summary>
    ///     Computed permissions for the invoking user in the channel, including overwrites, only included when part of the resolved data received on a slash command interaction.
    /// </summary>
    public string? Permissions { get; set; }

    /// <summary>
    ///     Channel flags combined as a bitfield.
    /// </summary>
    public int? Flags { get; set; }

    /// <summary>
    ///     Number of messages ever sent in a thread, it's similar to message_count on message creation, but will not decrement the number when a message is deleted.
    /// </summary>
    public int? TotalMessageSent { get; set; }

    /// <summary>
    ///     The set of tags that can be used in a GUILD_FORUM or a GUILD_MEDIA channel.
    /// </summary>
    public List<ForumTag>? AvailableTags { get; set; }

    /// <summary>
    ///     The IDs of the set of tags that have been applied to a thread in a GUILD_FORUM or a GUILD_MEDIA channel.
    /// </summary>
    public List<Snowflake>? AppliedTags { get; set; }

    /// <summary>
    ///     The emoji to show in the add reaction button on a thread in a GUILD_FORUM or a GUILD_MEDIA channel.
    /// </summary>
    public DefaultReaction? DefaultReactionEmoji { get; set; }

    /// <summary>
    ///     The initial rate_limit_per_user to set on newly created threads in a channel. This field is copied to the thread at creation time and does not live update.
    /// </summary>
    public int? DefaultThreadRateLimitPerUser { get; set; }

    /// <summary>
    ///     The default sort order type used to order posts in GUILD_FORUM and GUILD_MEDIA channels. Defaults to null, which indicates a preferred sort order hasn't been set by a channel admin.
    /// </summary>
    public int? DefaultSortOrder { get; set; }

    /// <summary>
    ///     The default forum layout view used to display posts in GUILD_FORUM channels. Defaults to 0, which indicates a layout view has not been set by a channel admin.
    /// </summary>
    public int? DefaultForumLayout { get; set; }
}
