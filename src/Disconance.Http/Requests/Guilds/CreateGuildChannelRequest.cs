using Disconance.Models;
using Disconance.Models.Channels;

namespace Disconance.Http.Requests.Guilds;

/// <summary>
///     Create a new channel object for the guild. Requires the MANAGE_CHANNELS permission. Returns the new channel object
///     on success. Fires a Channel Create Gateway event. All parameters to this endpoint are optional and nullable
///     excluding name.
/// </summary>
/// <param name="GuildId">The ID of the guild to create the channel in.</param>
public record CreateGuildChannelRequest(Snowflake GuildId) : IRequest<Channel>
{
    /// <summary>
    ///     Set of tags that can be used in a GUILD_FORUM or GUILD_MEDIA channel.
    /// </summary>
    public List<ForumTag>? AvailableTags { get; set; }

    /// <summary>
    ///     The bitrate (in bits) of the voice or stage channel; min 8000.
    /// </summary>
    public int? Bitrate { get; set; }

    /// <summary>
    ///     The default duration for newly created threads in the channel, in minutes, to automatically archive after recent
    ///     activity.
    /// </summary>
    public int? DefaultAutoArchiveDuration { get; set; }

    /// <summary>
    ///     The default forum layout view used to display posts in GUILD_FORUM channels.
    /// </summary>
    public int? DefaultForumLayout { get; set; }

    /// <summary>
    ///     Emoji to show in the add reaction button on a thread in a GUILD_FORUM or GUILD_MEDIA channel.
    /// </summary>
    public DefaultReaction? DefaultReactionEmoji { get; set; }

    /// <summary>
    ///     The default sort order type used to order posts in GUILD_FORUM and GUILD_MEDIA channels.
    /// </summary>
    public int? DefaultSortOrder { get; set; }

    /// <summary>
    ///     The initial rate_limit_per_user to set on newly created threads in a channel.
    /// </summary>
    public int? DefaultThreadRateLimitPerUser { get; set; }

    public HttpMethod Method => HttpMethod.Post;

    /// <summary>
    ///     Channel name (1-100 characters).
    /// </summary>
    public required string Name { get; init; }

    /// <summary>
    ///     Whether the channel is nsfw.
    /// </summary>
    public bool? Nsfw { get; set; }

    /// <summary>
    ///     ID of the parent category for a channel.
    /// </summary>
    public Snowflake? ParentId { get; set; }

    public string Path => $"guilds/{GuildId}/channels";

    /// <summary>
    ///     The channel's permission overwrites.
    /// </summary>
    public List<Overwrite>? PermissionOverwrites { get; set; }

    /// <summary>
    ///     Sorting position of the channel.
    /// </summary>
    public int? Position { get; set; }

    /// <summary>
    ///     Amount of seconds a user has to wait before sending another message (0-21600).
    /// </summary>
    public int? RateLimitPerUser { get; set; }

    /// <summary>
    ///     Channel voice region id of the voice or stage channel, automatic when set to null.
    /// </summary>
    public string? RtcRegion { get; set; }

    /// <summary>
    ///     Channel topic (0-1024 characters).
    /// </summary>
    public string? Topic { get; set; }

    /// <summary>
    ///     The type of channel.
    /// </summary>
    public ChannelType? Type { get; set; }

    /// <summary>
    ///     The user limit of the voice channel.
    /// </summary>
    public int? UserLimit { get; set; }

    /// <summary>
    ///     The camera video quality mode of the voice channel.
    /// </summary>
    public VideoQualityMode? VideoQualityMode { get; set; }
}