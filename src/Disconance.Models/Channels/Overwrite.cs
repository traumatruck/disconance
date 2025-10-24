namespace Disconance.Models.Channels;

/// <summary>
///     Represents an explicit permission overwrite for a channel.
/// </summary>
public class Overwrite
{
    /// <summary>
    ///     Permission bit set for allowed permissions.
    /// </summary>
    public string Allow { get; set; } = string.Empty;

    /// <summary>
    ///     Permission bit set for denied permissions.
    /// </summary>
    public string Deny { get; set; } = string.Empty;

    /// <summary>
    ///     Role or user id.
    /// </summary>
    public Snowflake Id { get; set; }

    /// <summary>
    ///     Either 0 (role) or 1 (member).
    /// </summary>
    public int Type { get; set; }
}