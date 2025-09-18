namespace Disconance.Models.Components;

/// <summary>
///     A Thumbnail is a content component that displays visual media in a small form-factor.
///     https://discord.com/developers/docs/interactions/message-components#thumbnail
/// </summary>
public class Thumbnail : IComponent
{
    /// <summary>
    ///     Type of the component.
    /// </summary>
    public ComponentType Type => ComponentType.Thumbnail;

    /// <summary>
    ///     Optional identifier for the component.
    /// </summary>
    public int? Id { get; set; }

    /// <summary>
    ///     A url or attachment provided as an unfurled media item.
    /// </summary>
    public UnfurledMediaItem Media { get; set; } = new();

    /// <summary>
    ///     Alt text for the media, max 1024 characters.
    /// </summary>
    public string? Description { get; set; }

    /// <summary>
    ///     Whether the thumbnail should be a spoiler (or blurred out). Defaults to false.
    /// </summary>
    public bool? Spoiler { get; set; }
}
