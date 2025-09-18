namespace Disconance.Models.Components;

/// <summary>
///     A Media Gallery is a top-level content component that allows you to display 1-10 media attachments.
///     https://discord.com/developers/docs/interactions/message-components#media-gallery
/// </summary>
public class MediaGallery : IComponent
{
    /// <summary>
    ///     Type of the component.
    /// </summary>
    public ComponentType Type => ComponentType.MediaGallery;

    /// <summary>
    ///     Optional identifier for the component.
    /// </summary>
    public int? Id { get; set; }

    /// <summary>
    ///     1 to 10 media gallery items.
    /// </summary>
    public List<MediaGalleryItem> Items { get; set; } = new();
}
