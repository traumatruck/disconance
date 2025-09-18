namespace Disconance.Models.Interactions;

/// <summary>
///     Represents the response from an interaction callback.
/// </summary>
public class InteractionCallbackResponse
{
    /// <summary>
    ///     The interaction object associated with the interaction response.
    /// </summary>
    public required InteractionCallback Interaction { get; set; }

    /// <summary>
    ///     The resource that was created by the interaction response.
    /// </summary>
    public InteractionCallbackResource? Resource { get; set; }
}