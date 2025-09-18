namespace Disconance.Models.Messages;

/// <summary>
///     Field information for an embed.
/// </summary>
public class EmbedField
{
    /// <summary>
    ///     Name of the field.
    /// </summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    ///     Value of the field.
    /// </summary>
    public string Value { get; set; } = string.Empty;

    /// <summary>
    ///     Whether or not this field should display inline.
    /// </summary>
    public bool? Inline { get; set; }
}
