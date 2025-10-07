using Disconance.Models;

namespace Disconance.Http.Requests.Guilds;

/// <summary>
///     Remove a member from a guild. Requires KICK_MEMBERS permission.
///     Returns a 204 empty response on success. Fires a Guild Member Remove Gateway event.
/// </summary>
/// <param name="GuildId">The ID of the guild.</param>
/// <param name="UserId">The ID of the member to remove.</param>
public record RemoveGuildMemberRequest(Snowflake GuildId, Snowflake UserId) : IRequest<object>
{
    public HttpMethod Method => HttpMethod.Delete;

    public string Path => $"guilds/{GuildId}/members/{UserId}";
}