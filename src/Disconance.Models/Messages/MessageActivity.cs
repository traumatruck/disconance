namespace Disconance.Models.Messages;

/// <summary>
///     Represents activity information for a message (Rich Presence, etc).
/// </summary>
public class MessageActivity
{
    /// <summary>
    ///     party_id from a Rich Presence event.
    /// </summary>
    public string? PartyId { get; set; }

    /// <summary>
    ///     Type of message activity.
    /// </summary>
    public MessageActivityType Type { get; set; }
}