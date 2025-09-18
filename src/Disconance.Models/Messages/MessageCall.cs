namespace Disconance.Models.Messages;

/// <summary>
///     Represents a call associated with a message in a private channel.
/// </summary>
public class MessageCall
{
    /// <summary>
    ///     Array of user IDs that participated in the call.
    /// </summary>
    public List<Snowflake> Participants { get; set; } = new();

    /// <summary>
    ///     Time when call ended.
    /// </summary>
    public DateTimeOffset? EndedTimestamp { get; set; }
}
