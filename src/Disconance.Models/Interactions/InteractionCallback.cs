namespace Disconance.Models.Interactions;

/// <summary>
///     The interaction object associated with the interaction response.
/// </summary>
public class InteractionCallback
{
    /// <summary>
    ///     ID of the interaction.
    /// </summary>
    public required Snowflake Id { get; set; }

    /// <summary>
    ///     Interaction type.
    /// </summary>
    public required InteractionType Type { get; set; }

    /// <summary>
    ///     Instance ID of the Activity if one was launched or joined.
    /// </summary>
    public string? ActivityInstanceId { get; set; }

    /// <summary>
    ///     ID of the message that was created by the interaction.
    /// </summary>
    public Snowflake? ResponseMessageId { get; set; }

    /// <summary>
    ///     Whether or not the message is in a loading state.
    /// </summary>
    public bool? ResponseMessageLoading { get; set; }

    /// <summary>
    ///     Whether or not the response message was ephemeral.
    /// </summary>
    public bool? ResponseMessageEphemeral { get; set; }
}