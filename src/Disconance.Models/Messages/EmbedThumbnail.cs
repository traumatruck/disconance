namespace Disconance.Models.Messages;

/// <summary>
///     Thumbnail information for an embed.
/// </summary>
public class EmbedThumbnail
{
    /// <summary>
    ///     Source URL of thumbnail (only supports http(s) and attachments).
    /// </summary>
    public string? Url { get; set; }

    /// <summary>
    ///     A proxied URL of the thumbnail.
    /// </summary>
    public string? ProxyUrl { get; set; }

    /// <summary>
    ///     Height of thumbnail.
    /// </summary>
    public int? Height { get; set; }

    /// <summary>
    ///     Width of thumbnail.
    /// </summary>
    public int? Width { get; set; }
}
