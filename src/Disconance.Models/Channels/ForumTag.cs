namespace Disconance.Models.Channels;

/// <summary>
///     Represents a tag that can be applied to a thread in a GUILD_FORUM or a GUILD_MEDIA channel.
/// </summary>
public class ForumTag
{
    /// <summary>
    ///     The id of the tag.
    /// </summary>
    public Snowflake Id { get; set; }

    /// <summary>
    ///     The name of the tag (0-20 characters).
    /// </summary>
    public string Name { get; set; } = string.Empty;
}
