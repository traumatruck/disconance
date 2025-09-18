namespace Disconance.Models.Messages;

/// <summary>
///     Author information for an embed.
/// </summary>
public class EmbedAuthor
{
    /// <summary>
    ///     Name of author.
    /// </summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    ///     URL of author (only supports http(s)).
    /// </summary>
    public string? Url { get; set; }

    /// <summary>
    ///     URL of author icon (only supports http(s) and attachments).
    /// </summary>
    public string? IconUrl { get; set; }

    /// <summary>
    ///     A proxied URL of author icon.
    /// </summary>
    public string? ProxyIconUrl { get; set; }
}
