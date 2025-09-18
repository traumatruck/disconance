using Disconance.Models.Guilds;

namespace Disconance.Models.Channels;

/// <summary>
///     Contains information about a user that has joined a thread.
/// </summary>
public class ThreadMember
{
    /// <summary>
    ///     ID of the thread.
    /// </summary>
    public Snowflake? Id { get; set; }

    /// <summary>
    ///     ID of the user.
    /// </summary>
    public Snowflake? UserId { get; set; }

    /// <summary>
    ///     Time the user last joined the thread.
    /// </summary>
    public DateTimeOffset JoinTimestamp { get; set; }

    /// <summary>
    ///     Any user-thread settings, currently only used for notifications.
    /// </summary>
    public int Flags { get; set; }

    /// <summary>
    ///     Additional information about the user (guild member object).
    /// </summary>
    public GuildMember? Member { get; set; }
}
