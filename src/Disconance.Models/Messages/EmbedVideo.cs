namespace Disconance.Models.Messages;

/// <summary>
///     Video information for an embed.
/// </summary>
public class EmbedVideo
{
    /// <summary>
    ///     Source URL of video.
    /// </summary>
    public string? Url { get; set; }

    /// <summary>
    ///     A proxied URL of the video.
    /// </summary>
    public string? ProxyUrl { get; set; }

    /// <summary>
    ///     Height of video.
    /// </summary>
    public int? Height { get; set; }

    /// <summary>
    ///     Width of video.
    /// </summary>
    public int? Width { get; set; }
}
