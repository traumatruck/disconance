using Disconance.Models.Users;

namespace Disconance.Models.Messages;

/// <summary>
///     Represents metadata about a message interaction.
/// </summary>
public class MessageInteractionMetadata
{
    /// <summary>
    ///     ID of the interaction.
    /// </summary>
    public Snowflake Id { get; set; }

    /// <summary>
    ///     Type of interaction.
    /// </summary>
    public int Type { get; set; }

    /// <summary>
    ///     User who triggered the interaction.
    /// </summary>
    public User User { get; set; } = null!;

    /// <summary>
    ///     IDs for installation context(s) related to an interaction.
    /// </summary>
    public Dictionary<string, Snowflake> AuthorizingIntegrationOwners { get; set; } = new();

    /// <summary>
    ///     ID of the original response message, present only on follow-up messages.
    /// </summary>
    public Snowflake? OriginalResponseMessageId { get; set; }

    /// <summary>
    ///     The user the command was run on, present only on user command interactions.
    /// </summary>
    public User? TargetUser { get; set; }

    /// <summary>
    ///     The ID of the message the command was run on, present only on message command interactions.
    /// </summary>
    public Snowflake? TargetMessageId { get; set; }
}
