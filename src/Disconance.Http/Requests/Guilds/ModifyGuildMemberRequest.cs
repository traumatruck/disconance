using Disconance.Models;
using Disconance.Models.Guilds;

namespace Disconance.Http.Requests.Guilds;

/// <summary>
///     Modify attributes of a guild member. Returns a 200 OK with the guild member as the body. Fires a Guild Member
///     Update Gateway event. If the channel_id is set to null, this will force the target user to be disconnected from
///     voice. All parameters to this endpoint are optional and nullable.
/// </summary>
/// <param name="GuildId">The ID of the guild.</param>
/// <param name="UserId">The ID of the member to modify.</param>
public record ModifyGuildMemberRequest(Snowflake GuildId, Snowflake UserId) : IRequest<GuildMember>
{
    /// <summary>
    ///     ID of channel to move user to (if they are connected to voice). Requires MOVE_MEMBERS permission.
    /// </summary>
    public Snowflake? ChannelId { get; set; }

    /// <summary>
    ///     When the user's timeout will expire (up to 28 days in the future), set to null to remove timeout.
    ///     Requires MODERATE_MEMBERS permission.
    /// </summary>
    public DateTimeOffset? CommunicationDisabledUntil { get; set; }

    /// <summary>
    ///     Whether the user is deafened in voice channels. Requires DEAFEN_MEMBERS permission.
    /// </summary>
    public bool? Deaf { get; set; }

    /// <summary>
    ///     Guild member flags.
    /// </summary>
    public int? Flags { get; set; }

    public HttpMethod Method => HttpMethod.Patch;

    /// <summary>
    ///     Whether the user is muted in voice channels. Requires MUTE_MEMBERS permission.
    /// </summary>
    public bool? Mute { get; set; }

    /// <summary>
    ///     Value to set user's nickname to. Requires MANAGE_NICKNAMES permission.
    /// </summary>
    public string? Nick { get; set; }

    public string Path => $"guilds/{GuildId}/members/{UserId}";

    /// <summary>
    ///     Array of role ids the member is assigned. Requires MANAGE_ROLES permission.
    /// </summary>
    public List<Snowflake>? Roles { get; set; }
}