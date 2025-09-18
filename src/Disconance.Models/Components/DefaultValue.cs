namespace Disconance.Models.Components;

/// <summary>
///     Select Default Value Structure.
///     https://discord.com/developers/docs/interactions/message-components#user-select-select-default-value-structure
/// </summary>
public class DefaultValue
{
    /// <summary>
    ///     ID of a user, role, or channel.
    /// </summary>
    public ulong Id { get; set; }

    /// <summary>
    ///     Type of value that id represents. Either "user", "role", or "channel".
    /// </summary>
    public string Type { get; set; } = string.Empty;
}
