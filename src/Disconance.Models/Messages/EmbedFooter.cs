namespace Disconance.Models.Messages;

/// <summary>
///     Footer information for an embed.
/// </summary>
public class EmbedFooter
{
    /// <summary>
    ///     Footer text.
    /// </summary>
    public string Text { get; set; } = string.Empty;

    /// <summary>
    ///     URL of footer icon (only supports http(s) and attachments).
    /// </summary>
    public string? IconUrl { get; set; }

    /// <summary>
    ///     A proxied URL of footer icon.
    /// </summary>
    public string? ProxyIconUrl { get; set; }
}
