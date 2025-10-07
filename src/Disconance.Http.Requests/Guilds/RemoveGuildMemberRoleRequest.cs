using Disconance.Models;

namespace Disconance.Http.Requests.Guilds;

/// <summary>
///     Removes a role from a guild member. Requires the MANAGE_ROLES permission.
///     Returns a 204 empty response on success. Fires a Guild Member Update Gateway event.
/// </summary>
/// <param name="GuildId">The ID of the guild.</param>
/// <param name="UserId">The ID of the member.</param>
/// <param name="RoleId">The ID of the role to remove.</param>
public record RemoveGuildMemberRoleRequest(Snowflake GuildId, Snowflake UserId, Snowflake RoleId) : IRequest<object>
{
    public HttpMethod Method => HttpMethod.Delete;

    public string Path => $"guilds/{GuildId}/members/{UserId}/roles/{RoleId}";
}