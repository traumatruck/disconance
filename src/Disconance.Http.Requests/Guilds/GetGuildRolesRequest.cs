using Disconance.Models;
using Disconance.Models.Guilds;

namespace Disconance.Http.Requests.Guilds;

/// <summary>
///     Returns a list of role objects for the guild.
/// </summary>
/// <param name="GuildId">The ID of the guild.</param>
public record GetGuildRolesRequest(Snowflake GuildId) : IRequest<List<Role>>
{
    public HttpMethod Method => HttpMethod.Get;

    public string Path => $"guilds/{GuildId}/roles";
}