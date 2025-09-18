namespace Disconance.Models.Interactions;

/// <summary>
///     Interaction data for message component interactions.
///     https://discord.com/developers/docs/interactions/receiving-and-responding#interaction-object-message-component-data-structure
/// </summary>
public class MessageComponentData : IInteractionData
{
    /// <summary>
    ///     Custom ID of the component.
    /// </summary>
    public string CustomId { get; set; } = string.Empty;

    /// <summary>
    ///     Type of the component.
    /// </summary>
    public int ComponentType { get; set; }

    /// <summary>
    ///     Values the user selected in a select menu component.
    /// </summary>
    public List<string>? Values { get; set; }

    /// <summary>
    ///     Resolved entities from selected options.
    /// </summary>
    public ResolvedData? Resolved { get; set; }
}
