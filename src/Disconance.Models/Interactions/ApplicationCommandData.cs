namespace Disconance.Models.Interactions;

/// <summary>
///     Interaction data for application command interactions.
///     https://discord.com/developers/docs/interactions/receiving-and-responding#interaction-object-application-command-data-structure
/// </summary>
public class ApplicationCommandData : IInteractionData
{
    /// <summary>
    ///     ID of the invoked command.
    /// </summary>
    public Snowflake Id { get; set; }

    /// <summary>
    ///     Name of the invoked command.
    /// </summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    ///     Type of the invoked command.
    /// </summary>
    public ApplicationCommandType Type { get; set; }

    /// <summary>
    ///     Converted users + roles + channels + attachments.
    /// </summary>
    public ResolvedData? Resolved { get; set; }

    /// <summary>
    ///     Params + values from the user.
    /// </summary>
    public IEnumerable<ApplicationCommandInteractionDataOption>? Options { get; set; }

    /// <summary>
    ///     ID of the guild the command is registered to.
    /// </summary>
    public Snowflake? GuildId { get; set; }

    /// <summary>
    ///     ID of the user or message targeted by a user or message command.
    /// </summary>
    public Snowflake? TargetId { get; set; }
}
