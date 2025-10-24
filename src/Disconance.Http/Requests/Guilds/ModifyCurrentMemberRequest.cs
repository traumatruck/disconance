using Disconance.Models;
using Disconance.Models.Guilds;

namespace Disconance.Http.Requests.Guilds;

/// <summary>
///     Modifies the current member in a guild. Returns a 200 OK with the guild member as the body. Fires a Guild Member
///     Update Gateway event.
/// </summary>
/// <param name="GuildId">The ID of the guild.</param>
public record ModifyCurrentMemberRequest(Snowflake GuildId) : IRequest<GuildMember>
{
    public HttpMethod Method => HttpMethod.Patch;

    /// <summary>
    ///     Value to set the current user's nickname to. Requires CHANGE_NICKNAME permission.
    /// </summary>
    public string? Nick { get; set; }

    public string Path => $"guilds/{GuildId}/members/@me";
}