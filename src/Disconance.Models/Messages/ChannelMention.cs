using Disconance.Models.Channels;

namespace Disconance.Models.Messages;

/// <summary>
///     Represents a channel mention in a message.
/// </summary>
public class ChannelMention
{
    /// <summary>
    ///     ID of the channel.
    /// </summary>
    public Snowflake Id { get; set; }

    /// <summary>
    ///     ID of the guild containing the channel.
    /// </summary>
    public Snowflake GuildId { get; set; }

    /// <summary>
    ///     Type of channel.
    /// </summary>
    public ChannelType Type { get; set; }

    /// <summary>
    ///     Name of the channel.
    /// </summary>
    public string Name { get; set; } = string.Empty;
}
