using Disconance.Models;

namespace Disconance.Http.Requests.Guilds;

/// <summary>
///     Delete a guild role. Requires the MANAGE_ROLES permission. Returns a 204 empty response on success. Fires a Guild
///     Role Delete Gateway event.
/// </summary>
/// <param name="GuildId">The ID of the guild.</param>
/// <param name="RoleId">The ID of the role to delete.</param>
public record DeleteGuildRoleRequest(Snowflake GuildId, Snowflake RoleId) : IRequest<object>
{
    public HttpMethod Method => HttpMethod.Delete;

    public string Path => $"guilds/{GuildId}/roles/{RoleId}";
}