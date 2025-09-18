namespace Disconance.Models.Messages;

/// <summary>
///     Minimal subset of fields in a forwarded message.
/// </summary>
public class MessageSnapshot
{
    /// <summary>
    ///     Minimal subset of fields in the forwarded message.
    /// </summary>
    public Message Message { get; set; } = null!;
}
