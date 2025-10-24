namespace Disconance.Models.Stickers;

/// <summary>
///     Represents a sticker in a message.
/// </summary>
public class Sticker
{
    /// <summary>
    ///     Type of sticker.
    /// </summary>
    public int FormatType { get; set; }

    /// <summary>
    ///     ID of the sticker.
    /// </summary>
    public Snowflake Id { get; set; }

    /// <summary>
    ///     Name of the sticker.
    /// </summary>
    public string Name { get; set; } = string.Empty;
}