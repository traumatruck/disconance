namespace Disconance.Models.Channels;

/// <summary>
///     Represents channel flags as a bitfield.
/// </summary>
[Flags]
public enum ChannelFlags
{
    None = 0,
    Pinned = 1 << 1,
    RequireTag = 1 << 4,
    HideMediaDownloadOptions = 1 << 15
}
