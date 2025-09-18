namespace Disconance.Models.Components;

/// <summary>
///     A File is a top-level content component that allows you to display an uploaded file as an attachment.
///     https://discord.com/developers/docs/interactions/message-components#file
/// </summary>
public class FileComponent : IComponent
{
    /// <summary>
    ///     Type of the component.
    /// </summary>
    public ComponentType Type => ComponentType.File;

    /// <summary>
    ///     Optional identifier for the component.
    /// </summary>
    public int? Id { get; set; }

    /// <summary>
    ///     This unfurled media item is unique in that it only supports attachment references using the attachment:// syntax.
    /// </summary>
    public UnfurledMediaItem File { get; set; } = new();

    /// <summary>
    ///     Whether the media should be a spoiler (or blurred out). Defaults to false.
    /// </summary>
    public bool? Spoiler { get; set; }

    /// <summary>
    ///     The name of the file.
    /// </summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    ///     The size of the file in bytes.
    /// </summary>
    public long Size { get; set; }
}
