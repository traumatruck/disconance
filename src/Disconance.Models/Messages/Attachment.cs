namespace Disconance.Models.Messages;

/// <summary>
///     Represents an attachment in a message.
/// </summary>
public class Attachment
{
    /// <summary>
    ///     Attachment ID.
    /// </summary>
    public Snowflake Id { get; set; }

    /// <summary>
    ///     Name of file attached.
    /// </summary>
    public string Filename { get; set; } = string.Empty;

    /// <summary>
    ///     Size of file in bytes.
    /// </summary>
    public int Size { get; set; }

    /// <summary>
    ///     Source URL of file.
    /// </summary>
    public string Url { get; set; } = string.Empty;

    /// <summary>
    ///     A proxied URL of file.
    /// </summary>
    public string ProxyUrl { get; set; } = string.Empty;

    /// <summary>
    ///     Height of file (if image).
    /// </summary>
    public int? Height { get; set; }

    /// <summary>
    ///     Width of file (if image).
    /// </summary>
    public int? Width { get; set; }

    /// <summary>
    ///     Whether this attachment is ephemeral.
    /// </summary>
    public bool? Ephemeral { get; set; }
}
