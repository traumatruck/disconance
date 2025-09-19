using System.Text.Json.Serialization;
using Disconance.Models.Components;
using Disconance.Models.JsonConverters;

namespace Disconance.Models.Interactions;

/// <summary>
///     Interaction data for modal submit interactions.
///     https://discord.com/developers/docs/interactions/receiving-and-responding#interaction-object-modal-submit-data-structure
/// </summary>
public class ModalSubmitData : IInteractionData
{
    /// <summary>
    ///     The custom ID provided for the modal.
    /// </summary>
    public string CustomId { get; set; }

    /// <summary>
    ///     Values submitted by the user.
    /// </summary>
    [JsonConverter(typeof(ComponentCollectionJsonConverter))]
    public IEnumerable<IComponent> Components { get; set; }
}
