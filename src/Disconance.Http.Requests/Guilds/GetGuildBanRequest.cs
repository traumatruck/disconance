using Disconance.Models;
using Disconance.Models.Guilds;

namespace Disconance.Http.Requests.Guilds;

/// <summary>
///     Returns a ban object for the given user or a 404 not found if the ban cannot be found. Requires the BAN_MEMBERS
///     permission.
/// </summary>
/// <param name="GuildId">The ID of the guild.</param>
/// <param name="UserId">The ID of the banned user.</param>
public record GetGuildBanRequest(Snowflake GuildId, Snowflake UserId) : IRequest<Ban>
{
    public HttpMethod Method => HttpMethod.Get;

    public string Path => $"guilds/{GuildId}/bans/{UserId}";
}