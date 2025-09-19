using System.Text.Json.Serialization;
using Disconance.Models.Components;
using Disconance.Models.JsonConverters;

namespace Disconance.Models.Interactions;

public record Modal : IInteractionCallbackData
{
    /// <summary>
    ///     Developer-defined identifier for the modal, max 100 characters.
    /// </summary>
    public string CustomId { get; set; }

    /// <summary>
    ///     Title of the popup modal, max 45 characters.
    /// </summary>
    public string Title { get; set; }

    /// <summary>
    ///     Between 1 and 5 (inclusive) components that make up the modal.
    /// </summary>
    [JsonConverter(typeof(ComponentCollectionJsonConverter))]
    public IEnumerable<IComponent> Components { get; set; }
}