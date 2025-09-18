using System.Text.Json.Serialization;
using Disconance.Models.JsonConverters;

namespace Disconance.Models.Components;

/// <summary>
///     A Label is a top-level layout component that wraps modal components with text as a label.
///     https://discord.com/developers/docs/interactions/message-components#label
/// </summary>
public class Label : IComponent
{
    /// <summary>
    ///     Type of the component.
    /// </summary>
    public ComponentType Type => ComponentType.Label;

    /// <summary>
    ///     Optional identifier for the component.
    /// </summary>
    public int? Id { get; set; }

    /// <summary>
    ///     The label text; max 45 characters.
    /// </summary>
    [JsonPropertyName("label")]
    public string LabelText { get; set; } = string.Empty;

    /// <summary>
    ///     An optional description text for the label; max 100 characters.
    /// </summary>
    public string? Description { get; set; }

    /// <summary>
    ///     The component within the label.
    /// </summary>
    [JsonConverter(typeof(ComponentJsonConverter))]
    public IComponent Component { get; set; } = new TextInput();
}
