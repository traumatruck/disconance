using Disconance.Models.Channels;
using Disconance.Models.Guilds;
using Disconance.Models.Messages;
using Disconance.Models.Users;

namespace Disconance.Models;

/// <summary>
///     Represents resolved data for users, members, channels, roles, messages, and attachments.
///     https://discord.com/developers/docs/interactions/receiving-and-responding#interaction-object-resolved-data-structure
/// </summary>
public class ResolvedData
{
    /// <summary>
    ///     IDs and User objects.
    /// </summary>
    public Dictionary<Snowflake, User>? Users { get; set; }

    /// <summary>
    ///     IDs and partial Member objects.
    /// </summary>
    public Dictionary<Snowflake, GuildMember>? Members { get; set; }

    /// <summary>
    ///     IDs and Role objects.
    /// </summary>
    public Dictionary<Snowflake, Role>? Roles { get; set; }

    /// <summary>
    ///     IDs and partial Channel objects.
    /// </summary>
    public Dictionary<Snowflake, Channel>? Channels { get; set; }

    /// <summary>
    ///     IDs and partial Message objects.
    /// </summary>
    public Dictionary<Snowflake, Message>? Messages { get; set; }

    /// <summary>
    ///     IDs and attachment objects.
    /// </summary>
    public Dictionary<Snowflake, Attachment>? Attachments { get; set; }
}