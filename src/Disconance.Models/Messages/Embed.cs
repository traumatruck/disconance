namespace Disconance.Models.Messages;

/// <summary>
///     Represents an embed in a message.
/// </summary>
public class Embed
{
    /// <summary>
    ///     Title of embed.
    /// </summary>
    public string? Title { get; set; }

    /// <summary>
    ///     Type of embed (always "rich" for webhook embeds).
    /// </summary>
    public string? Type { get; set; }

    /// <summary>
    ///     Description of embed.
    /// </summary>
    public string? Description { get; set; }

    /// <summary>
    ///     URL of embed.
    /// </summary>
    public string? Url { get; set; }

    /// <summary>
    ///     Timestamp of embed content.
    /// </summary>
    public DateTimeOffset? Timestamp { get; set; }

    /// <summary>
    ///     Color code of the embed.
    /// </summary>
    public int? Color { get; set; }

    /// <summary>
    ///     Footer information.
    /// </summary>
    public EmbedFooter? Footer { get; set; }

    /// <summary>
    ///     Image information.
    /// </summary>
    public EmbedImage? Image { get; set; }

    /// <summary>
    ///     Thumbnail information.
    /// </summary>
    public EmbedThumbnail? Thumbnail { get; set; }

    /// <summary>
    ///     Video information.
    /// </summary>
    public EmbedVideo? Video { get; set; }

    /// <summary>
    ///     Provider information.
    /// </summary>
    public EmbedProvider? Provider { get; set; }

    /// <summary>
    ///     Author information.
    /// </summary>
    public EmbedAuthor? Author { get; set; }

    /// <summary>
    ///     Fields information, max of 25.
    /// </summary>
    public List<EmbedField>? Fields { get; set; }
}
