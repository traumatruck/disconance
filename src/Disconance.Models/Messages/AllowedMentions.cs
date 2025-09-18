namespace Disconance.Models.Messages;

/// <summary>
///     Represents allowed mentions in a message.
///     https://discord.com/developers/docs/resources/message#allowed-mentions-object
/// </summary>
public class AllowedMentions
{
    /// <summary>
    ///     An array of allowed mention types to parse from the content.
    /// </summary>
    public IEnumerable<string>? Parse { get; set; }

    /// <summary>
    ///     Array of role_ids to mention (Max size of 100).
    /// </summary>
    public IEnumerable<Snowflake>? Roles { get; set; }

    /// <summary>
    ///     Array of user_ids to mention (Max size of 100).
    /// </summary>
    public IEnumerable<Snowflake>? Users { get; set; }

    /// <summary>
    ///     For replies, whether to mention the author of the message being replied to (default false).
    /// </summary>
    public bool? RepliedUser { get; set; }
}
