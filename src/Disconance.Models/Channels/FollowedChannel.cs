namespace Disconance.Models.Channels;

/// <summary>
///     Represents a followed channel object.
/// </summary>
public class FollowedChannel
{
    /// <summary>
    ///     Source channel id.
    /// </summary>
    public Snowflake ChannelId { get; set; }

    /// <summary>
    ///     Created target webhook id.
    /// </summary>
    public Snowflake WebhookId { get; set; }
}
