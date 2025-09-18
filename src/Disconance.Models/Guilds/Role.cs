namespace Disconance.Models.Guilds;

/// <summary>
///     Represents a Discord role.
///     https://discord.com/developers/docs/topics/permissions#role-object
/// </summary>
public class Role
{
    /// <summary>
    ///     Role ID.
    /// </summary>
    public Snowflake Id { get; set; }

    /// <summary>
    ///     Role name.
    /// </summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    ///     Integer representation of hexadecimal color code.
    /// </summary>
    public int Color { get; set; }

    /// <summary>
    ///     If this role is pinned in the user listing.
    /// </summary>
    public bool Hoist { get; set; }

    /// <summary>
    ///     Role icon hash.
    /// </summary>
    public string? Icon { get; set; }

    /// <summary>
    ///     Role unicode emoji.
    /// </summary>
    public string? UnicodeEmoji { get; set; }

    /// <summary>
    ///     Position of this role.
    /// </summary>
    public int Position { get; set; }

    /// <summary>
    ///     Permission bit set.
    /// </summary>
    public string Permissions { get; set; } = string.Empty;

    /// <summary>
    ///     Whether this role is managed by an integration.
    /// </summary>
    public bool Managed { get; set; }

    /// <summary>
    ///     Whether this role is mentionable.
    /// </summary>
    public bool Mentionable { get; set; }

    /// <summary>
    ///     The tags this role has.
    /// </summary>
    public object? Tags { get; set; } // TODO: Role tags object
}
