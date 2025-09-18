namespace Disconance.Models.Messages;

/// <summary>
///     Breakdown of normal and super reaction counts for the associated emoji.
/// </summary>
public class ReactionCountDetails
{
    /// <summary>
    ///     Count of super reactions.
    /// </summary>
    public int Burst { get; set; }

    /// <summary>
    ///     Count of normal reactions.
    /// </summary>
    public int Normal { get; set; }
}
