using Disconance.Models;
using Disconance.Models.Guilds;

namespace Disconance.Http.Requests.Guilds;

/// <summary>
///     Modify a guild role. Requires the MANAGE_ROLES permission.
///     Returns the updated role on success. Fires a Guild Role Update Gateway event.
/// </summary>
/// <param name="GuildId">The ID of the guild.</param>
/// <param name="RoleId">The ID of the role to modify.</param>
public record ModifyGuildRoleRequest(Snowflake GuildId, Snowflake RoleId) : IRequest<Role>
{
    /// <summary>
    ///     RGB color value.
    /// </summary>
    public int? Color { get; set; }

    /// <summary>
    ///     Whether the role should be displayed separately in the sidebar.
    /// </summary>
    public bool? Hoist { get; set; }

    /// <summary>
    ///     The role's icon image (if the guild has the ROLE_ICONS feature).
    /// </summary>
    public string? Icon { get; set; }

    /// <summary>
    ///     Whether the role should be mentionable.
    /// </summary>
    public bool? Mentionable { get; set; }

    public HttpMethod Method => HttpMethod.Patch;

    /// <summary>
    ///     Name of the role, max 100 characters.
    /// </summary>
    public string? Name { get; set; }

    public string Path => $"guilds/{GuildId}/roles/{RoleId}";

    /// <summary>
    ///     Bitwise value of the enabled/disabled permissions.
    /// </summary>
    public string? Permissions { get; set; }

    /// <summary>
    ///     The role's unicode emoji (if the guild has the ROLE_ICONS feature).
    /// </summary>
    public string? UnicodeEmoji { get; set; }
}