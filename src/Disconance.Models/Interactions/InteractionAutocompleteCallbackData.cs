namespace Disconance.Models.Interactions;

/// <summary>
///     Represents the callback data for autocomplete interaction responses.
///     https://discord.com/developers/docs/interactions/receiving-and-responding#interaction-callback-data-structure
/// </summary>
public record InteractionAutocompleteCallbackData : IInteractionCallbackData
{
    /// <summary>
    ///     Autocomplete choices (max of 25 choices).
    /// </summary>
    public IEnumerable<ApplicationCommandOptionChoice> Choices { get; init; } = new List<ApplicationCommandOptionChoice>();
}
