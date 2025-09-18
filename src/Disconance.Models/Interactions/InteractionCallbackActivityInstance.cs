namespace Disconance.Models.Interactions;

/// <summary>
///     Represents the Activity launched by this interaction.
/// </summary>
public class InteractionCallbackActivityInstance
{
    /// <summary>
    ///     Instance ID of the Activity if one was launched or joined.
    /// </summary>
    public required string Id { get; set; }
}