using Disconance.Models;
using Disconance.Models.Guilds;

namespace Disconance.Http.Requests.Guilds;

/// <summary>
///     Adds a user to the guild, provided you have a valid oauth2 access token for the user with the guilds.join scope.
///     Returns a 201 Created with the guild member as the body, or 204 No Content if the user is already a member of the
///     guild. Fires a Guild Member Add Gateway event. The Authorization header must be a Bot token, and the bot must be a
///     member of the guild with CREATE_INSTANT_INVITE permission.
/// </summary>
/// <param name="GuildId">The ID of the guild.</param>
/// <param name="UserId">The ID of the user to add.</param>
public record AddGuildMemberRequest(Snowflake GuildId, Snowflake UserId) : IRequest<GuildMember>
{
    /// <summary>
    ///     An oauth2 access token granted with the guilds.join scope to the bot's application for the user you want to
    ///     add to the guild.
    /// </summary>
    public required string AccessToken { get; set; }

    /// <summary>
    ///     Whether the user is deafened in voice channels. Requires DEAFEN_MEMBERS permission.
    /// </summary>
    public bool? Deaf { get; set; }

    public HttpMethod Method => HttpMethod.Put;

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