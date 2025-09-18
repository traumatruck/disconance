namespace Disconance.Models.Messages;

/// <summary>
///     Image information for an embed.
/// </summary>
public class EmbedImage
{
    /// <summary>
    ///     Source URL of image (only supports http(s) and attachments).
    /// </summary>
    public string? Url { get; set; }

    /// <summary>
    ///     A proxied URL of the image.
    /// </summary>
    public string? ProxyUrl { get; set; }

    /// <summary>
    ///     Height of image.
    /// </summary>
    public int? Height { get; set; }

    /// <summary>
    ///     Width of image.
    /// </summary>
    public int? Width { get; set; }
}
