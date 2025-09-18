namespace Disconance.Models.Components;

/// <summary>
///     Represents a component in Discord.
///     https://discord.com/developers/docs/interactions/message-components#component-object
/// </summary>
public interface IComponent
{
    /// <summary>
    ///     Type of the component.
    /// </summary>
    ComponentType Type { get; }

    /// <summary>
    ///     Optional identifier for the component.
    /// </summary>
    int? Id { get; set; }
}
