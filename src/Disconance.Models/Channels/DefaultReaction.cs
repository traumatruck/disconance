namespace Disconance.Models.Channels;

/// <summary>
///     Specifies the emoji to use as the default way to react to a forum post.
/// </summary>
public class DefaultReaction
{
    /// <summary>
    ///     The id of a guild's custom emoji.
    /// </summary>
    public Snowflake? EmojiId { get; set; }

    /// <summary>
    ///     The unicode character of the emoji.
    /// </summary>
    public string? EmojiName { get; set; }
}
