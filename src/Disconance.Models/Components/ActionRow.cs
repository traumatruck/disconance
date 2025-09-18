using System.Text.Json.Serialization;
using Disconance.Models.JsonConverters;

namespace Disconance.Models.Components;

/// <summary>
///     An Action Row is a top-level layout component.
///     https://discord.com/developers/docs/interactions/message-components#action-row
/// </summary>
public class ActionRow : IComponent
{
    /// <summary>
    ///     Up to 5 interactive button components or a single select component.
    /// </summary>
    [JsonConverter(typeof(ComponentCollectionJsonConverter))]
    public IEnumerable<IComponent> Components { get; set; } = [];

    /// <summary>
    ///     Type of the component.
    /// </summary>
    public ComponentType Type => ComponentType.ActionRow;

    /// <summary>
    ///     Optional identifier for the component.
    /// </summary>
    public int? Id { get; set; }
}