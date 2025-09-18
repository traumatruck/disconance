namespace Disconance.Models.Components;

/// <summary>
///     Text Input is an interactive component that allows users to enter free-form text responses in modals.
///     https://discord.com/developers/docs/interactions/message-components#text-input
/// </summary>
public class TextInput : IComponent
{
    /// <summary>
    ///     Type of the component.
    /// </summary>
    public ComponentType Type => ComponentType.TextInput;

    /// <summary>
    ///     Optional identifier for the component.
    /// </summary>
    public int? Id { get; set; }

    /// <summary>
    ///     Developer-defined identifier for the input; max 100 characters.
    /// </summary>
    public string CustomId { get; set; } = string.Empty;

    /// <summary>
    ///     The Text Input Style.
    /// </summary>
    public TextInputStyle Style { get; set; }

    /// <summary>
    ///     Minimum input length for a text input; min 0, max 4000.
    /// </summary>
    public int? MinLength { get; set; }

    /// <summary>
    ///     Maximum input length for a text input; min 1, max 4000.
    /// </summary>
    public int? MaxLength { get; set; }

    /// <summary>
    ///     Whether this component is required to be filled (defaults to true).
    /// </summary>
    public bool? Required { get; set; }

    /// <summary>
    ///     Pre-filled value for this component; max 4000 characters.
    /// </summary>
    public string? Value { get; set; }

    /// <summary>
    ///     Custom placeholder text if the input is empty; max 100 characters.
    /// </summary>
    public string? Placeholder { get; set; }
}
