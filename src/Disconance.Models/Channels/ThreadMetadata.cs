namespace Disconance.Models.Channels;

/// <summary>
///     Contains thread-specific channel fields that are not needed by other channel types.
/// </summary>
public class ThreadMetadata
{
    /// <summary>
    ///     Whether the thread is archived.
    /// </summary>
    public bool Archived { get; set; }

    /// <summary>
    ///     The thread will stop showing in the channel list after this many minutes of inactivity.
    /// </summary>
    public int AutoArchiveDuration { get; set; }

    /// <summary>
    ///     Timestamp when the thread's archive status was last changed, used for calculating recent activity.
    /// </summary>
    public DateTimeOffset ArchiveTimestamp { get; set; }

    /// <summary>
    ///     Whether the thread is locked; when a thread is locked, only users with MANAGE_THREADS can unarchive it.
    /// </summary>
    public bool Locked { get; set; }

    /// <summary>
    ///     Whether non-moderators can add other non-moderators to a thread; only available on private threads.
    /// </summary>
    public bool? Invitable { get; set; }

    /// <summary>
    ///     Timestamp when the thread was created; only populated for threads created after 2022-01-09.
    /// </summary>
    public DateTimeOffset? CreateTimestamp { get; set; }
}
