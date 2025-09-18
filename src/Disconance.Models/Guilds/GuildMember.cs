using Disconance.Models.Users;

namespace Disconance.Models.Guilds;

/// <summary>
///     Represents a member of a guild.
/// </summary>
public class GuildMember
{
    /// <summary>
    ///     The user this guild member represents.
    /// </summary>
    public User? User { get; set; }

    /// <summary>
    ///     This user's guild nickname.
    /// </summary>
    public string? Nick { get; set; }

    /// <summary>
    ///     The member's guild avatar hash.
    /// </summary>
    public string? Avatar { get; set; }

    /// <summary>
    ///     Array of role object ids.
    /// </summary>
    public List<Snowflake> Roles { get; set; } = new();

    /// <summary>
    ///     When the user joined the guild.
    /// </summary>
    public DateTimeOffset JoinedAt { get; set; }

    /// <summary>
    ///     When the user started boosting the guild.
    /// </summary>
    public DateTimeOffset? PremiumSince { get; set; }

    /// <summary>
    ///     Whether the user is deafened in voice channels.
    /// </summary>
    public bool Deaf { get; set; }

    /// <summary>
    ///     Whether the user is muted in voice channels.
    /// </summary>
    public bool Mute { get; set; }

    /// <summary>
    ///     Guild member flags represented as a bit set.
    /// </summary>
    public int? Flags { get; set; }

    /// <summary>
    ///     Whether the user has not yet passed the guild's Membership Screening requirements.
    /// </summary>
    public bool? Pending { get; set; }

    /// <summary>
    ///     Total permissions of the member in the channel, including overwrites.
    /// </summary>
    public string? Permissions { get; set; }
}