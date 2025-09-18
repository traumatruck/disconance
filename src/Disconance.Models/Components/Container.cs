namespace Disconance.Models.Components;

/// <summary>
///     A Container is a top-level layout component that offers the ability to visually encapsulate a collection of components.
///     https://discord.com/developers/docs/interactions/message-components#container
/// </summary>
public class Container : IComponent
{
    /// <summary>
    ///     Type of the component.
    /// </summary>
    public ComponentType Type => ComponentType.Container;

    /// <summary>
    ///     Optional identifier for the component.
    /// </summary>
    public int? Id { get; set; }

    /// <summary>
    ///     Child components that are encapsulated within the Container.
    /// </summary>
    public List<IComponent> Components { get; set; } = new();

    /// <summary>
    ///     Color for the accent on the container as RGB from 0x000000 to 0xFFFFFF.
    /// </summary>
    public int? AccentColor { get; set; }

    /// <summary>
    ///     Whether the container should be a spoiler (or blurred out). Defaults to false.
    /// </summary>
    public bool? Spoiler { get; set; }
}
