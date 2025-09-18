namespace Disconance.Models.Stickers;

/// <summary>
///     Represents a sticker in a message.
/// </summary>
public class Sticker
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
