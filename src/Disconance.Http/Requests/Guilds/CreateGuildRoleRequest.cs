using Disconance.Models;
using Disconance.Models.Guilds;

namespace Disconance.Http.Requests.Guilds;

/// <summary>
///     Create a new role for the guild. Requires the MANAGE_ROLES permission. Returns the new role object on success.
///     Fires a Guild Role Create Gateway event. All JSON params are optional.
/// </summary>
/// <param name="GuildId">The ID of the guild.</param>
public record CreateGuildRoleRequest(Snowflake GuildId) : IRequest<Role>
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

    public HttpMethod Method => HttpMethod.Post;

    /// <summary>
    ///     Name of the role, max 100 characters. Default "new role".
    /// </summary>
    public string? Name { get; set; }

    public string Path => $"guilds/{GuildId}/roles";

    /// <summary>
    ///     Bitwise value of the enabled/disabled permissions.
    /// </summary>
    public string? Permissions { get; set; }

    /// <summary>
    ///     The role's unicode emoji (if the guild has the ROLE_ICONS feature).
    /// </summary>
    public string? UnicodeEmoji { get; set; }
}