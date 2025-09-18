using Disconance.Models.Messages;

namespace Disconance.Models.Interactions;

/// <summary>
///     The resource that was created by the interaction response.
/// </summary>
public class InteractionCallbackResource
{
    /// <summary>
    ///     Interaction callback type.
    /// </summary>
    public required InteractionCallbackType Type { get; set; }

    /// <summary>
    ///     Represents the Activity launched by this interaction.
    /// </summary>
    public InteractionCallbackActivityInstance? ActivityInstance { get; set; }

    /// <summary>
    ///     Message created by the interaction.
    /// </summary>
    public Message? Message { get; set; }
}