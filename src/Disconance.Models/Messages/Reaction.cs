using Disconance.Models.Emojis;

namespace Disconance.Models.Messages;

/// <summary>
///     Represents a reaction to a message.
/// </summary>
public class Reaction
{
    /// <summary>
    ///     Total number of times this emoji has been used to react (including super reacts).
    /// </summary>
    public int Count { get; set; }

    /// <summary>
    ///     Breakdown of normal and super reaction counts for the associated emoji.
    /// </summary>
    public ReactionCountDetails CountDetails { get; set; } = null!;

    /// <summary>
    ///     Whether the current user reacted using this emoji.
    /// </summary>
    public bool Me { get; set; }

    /// <summary>
    ///     Whether the current user super-reacted using this emoji.
    /// </summary>
    public bool MeBurst { get; set; }

    /// <summary>
    ///     Emoji information.
    /// </summary>
    public Emoji Emoji { get; set; } = null!;

    /// <summary>
    ///     HEX colors used for super reaction.
    /// </summary>
    public List<string>? BurstColors { get; set; }
}
