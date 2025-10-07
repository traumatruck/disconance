namespace Disconance.Models.Guilds;

/// <summary>
///     Represents a channel position modification request.
/// </summary>
public class ChannelPositionModification
{
    /// <summary>
    ///     Channel id.
    /// </summary>
    public required Snowflake Id { get; set; }

    /// <summary>
    ///     Syncs the permission overwrites with the new parent, if moving to a new category.
    /// </summary>
    public bool? LockPermissions { get; set; }

    /// <summary>
    ///     The new parent ID for the channel that is moved.
    /// </summary>
    public Snowflake? ParentId { get; set; }

    /// <summary>
    ///     Sorting position of the channel.
    /// </summary>
    public int? Position { get; set; }
}