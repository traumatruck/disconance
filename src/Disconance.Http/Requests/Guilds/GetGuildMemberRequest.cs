using Disconance.Models;
using Disconance.Models.Guilds;

namespace Disconance.Http.Requests.Guilds;

/// <summary>
///     Returns a guild member object for the specified user.
/// </summary>
/// <param name="GuildId">The ID of the guild.</param>
/// <param name="UserId">The ID of the user.</param>
public record GetGuildMemberRequest(Snowflake GuildId, Snowflake UserId) : IRequest<GuildMember>
{
    public HttpMethod Method => HttpMethod.Get;

    public string Path => $"guilds/{GuildId}/members/{UserId}";
}