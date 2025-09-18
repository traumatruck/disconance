namespace Disconance.Models.Components;

/// <summary>
///     Media Gallery Item Structure.
///     https://discord.com/developers/docs/interactions/message-components#media-gallery-media-gallery-item-structure
/// </summary>
public class MediaGalleryItem
{
    /// <summary>
    ///     A url or attachment provided as an unfurled media item.
    /// </summary>
    public UnfurledMediaItem Media { get; set; } = new();

    /// <summary>
    ///     Alt text for the media, max 1024 characters.
    /// </summary>
    public string? Description { get; set; }

    /// <summary>
    ///     Whether the media should be a spoiler (or blurred out). Defaults to false.
    /// </summary>
    public bool? Spoiler { get; set; }
}
