namespace Disconance.Models.Components;

/// <summary>
///     An Unfurled Media Item is a piece of media, represented by a URL.
///     https://discord.com/developers/docs/interactions/message-components#unfurled-media-item
/// </summary>
public class UnfurledMediaItem
{
    /// <summary>
    ///     Supports arbitrary urls and attachment:// references.
    /// </summary>
    public string Url { get; set; } = string.Empty;

    /// <summary>
    ///     The proxied url of the media item.
    /// </summary>
    public string? ProxyUrl { get; set; }

    /// <summary>
    ///     The height of the media item.
    /// </summary>
    public int? Height { get; set; }

    /// <summary>
    ///     The width of the media item.
    /// </summary>
    public int? Width { get; set; }

    /// <summary>
    ///     The media type of the content.
    /// </summary>
    public string? ContentType { get; set; }

    /// <summary>
    ///     The id of the uploaded attachment.
    /// </summary>
    public ulong? AttachmentId { get; set; }
}
