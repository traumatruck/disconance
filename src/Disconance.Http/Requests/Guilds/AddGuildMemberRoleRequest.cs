using Disconance.Models;

namespace Disconance.Http.Requests.Guilds;

/// <summary>
///     Adds a role to a guild member. Requires the MANAGE_ROLES permission. Returns a 204 empty response on success. Fires
///     a Guild Member Update Gateway event.
/// </summary>
/// <param name="GuildId">The ID of the guild.</param>
/// <param name="UserId">The ID of the member.</param>
/// <param name="RoleId">The ID of the role to add.</param>
public record AddGuildMemberRoleRequest(Snowflake GuildId, Snowflake UserId, Snowflake RoleId) : IRequest<object>
{
    public HttpMethod Method => HttpMethod.Put;

    public string Path => $"guilds/{GuildId}/members/{UserId}/roles/{RoleId}";
}