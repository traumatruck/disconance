namespace Disconance.Models.Messages;

/// <summary>
///     Represents a sticker item in a message.
/// </summary>
public class MessageStickerItem
{
    /// <summary>
    ///     ID of the sticker.
    /// </summary>
    public Snowflake Id { get; set; }

    /// <summary>
    ///     Name of the sticker.
    /// </summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    ///     Type of sticker.
    /// </summary>
    public int FormatType { get; set; }
}
