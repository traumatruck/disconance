using Disconance.Models.Users;

namespace Disconance.Models.Guilds;

/// <summary>
///     Represents a ban object.
/// </summary>
public class Ban
{
    /// <summary>
    ///     The reason for the ban.
    /// </summary>
    public string? Reason { get; set; }

    /// <summary>
    ///     The banned user.
    /// </summary>
    public required User User { get; set; }
}