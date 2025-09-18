using Disconance.Models.Emojis;

namespace Disconance.Models.Components;

/// <summary>
///     Select option structure.
///     https://discord.com/developers/docs/interactions/message-components#string-select-select-option-structure
/// </summary>
public class SelectOption
{
    /// <summary>
    ///     User-facing name of the option; max 100 characters.
    /// </summary>
    public string Label { get; set; } = string.Empty;

    /// <summary>
    ///     Dev-defined value of the option; max 100 characters.
    /// </summary>
    public string Value { get; set; } = string.Empty;

    /// <summary>
    ///     Additional description of the option; max 100 characters.
    /// </summary>
    public string? Description { get; set; }

    /// <summary>
    ///     Emoji object.
    /// </summary>
    public Emoji? Emoji { get; set; }

    /// <summary>
    ///     Will show this option as selected by default.
    /// </summary>
    public bool? Default { get; set; }
}
