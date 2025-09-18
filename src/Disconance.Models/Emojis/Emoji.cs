using Disconance.Models.Users;

namespace Disconance.Models.Emojis;

/// <summary>
///     Represents an emoji used in reactions and elsewhere.
/// </summary>
public class Emoji
{
    /// <summary>
    ///     Emoji ID (null for unicode emoji).
    /// </summary>
    public Snowflake? Id { get; set; }

    /// <summary>
    ///     Emoji name (can be null for custom emoji).
    /// </summary>
    public string? Name { get; set; }

    /// <summary>
    ///     Roles allowed to use this emoji.
    /// </summary>
    public List<Snowflake>? Roles { get; set; }

    /// <summary>
    ///     User that created this emoji.
    /// </summary>
    public User? User { get; set; }

    /// <summary>
    ///     Whether this emoji must be wrapped in colons.
    /// </summary>
    public bool? RequireColons { get; set; }

    /// <summary>
    ///     Whether this emoji is managed.
    /// </summary>
    public bool? Managed { get; set; }

    /// <summary>
    ///     Whether this emoji is animated.
    /// </summary>
    public bool? Animated { get; set; }

    /// <summary>
    ///     Whether this emoji can be used, may be false due to loss of Server Boosts.
    /// </summary>
    public bool? Available { get; set; }
}