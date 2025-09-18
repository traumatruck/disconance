namespace Disconance.Models.Messages;

/// <summary>
///     Represents a reference to another message (for replies, crossposts, etc).
/// </summary>
public class MessageReference
{
    /// <summary>
    ///     Type of reference.
    /// </summary>
    public MessageReferenceType? Type { get; set; }

    /// <summary>
    ///     ID of the originating message.
    /// </summary>
    public Snowflake? MessageId { get; set; }

    /// <summary>
    ///     ID of the originating message's channel.
    /// </summary>
    public Snowflake? ChannelId { get; set; }

    /// <summary>
    ///     ID of the originating message's guild.
    /// </summary>
    public Snowflake? GuildId { get; set; }

    /// <summary>
    ///     When sending, whether to error if the referenced message doesn't exist instead of sending as a normal (non-reply) message, default true.
    /// </summary>
    public bool? FailIfNotExists { get; set; }
}
