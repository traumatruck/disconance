namespace Disconance.Models.Interactions;

/// <summary>
///     Represents an interaction response.
/// </summary>
public class InteractionResponse
{
    /// <summary>
    ///     Type of response.
    /// </summary>
    public required InteractionCallbackType Type { get; set; }

    /// <summary>
    ///     An optional response message.
    /// </summary>
    public IInteractionCallbackData? Data { get; set; }
}