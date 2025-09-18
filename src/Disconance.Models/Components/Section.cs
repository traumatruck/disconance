namespace Disconance.Models.Components;

/// <summary>
///     A Section is a top-level layout component that allows you to contextually associate content with an accessory component.
///     https://discord.com/developers/docs/interactions/message-components#section
/// </summary>
public class Section : IComponent
{
    /// <summary>
    ///     Type of the component.
    /// </summary>
    public ComponentType Type => ComponentType.Section;

    /// <summary>
    ///     Optional identifier for the component.
    /// </summary>
    public int? Id { get; set; }

    /// <summary>
    ///     One to three child components representing the content of the section.
    /// </summary>
    public List<IComponent> Components { get; set; } = new();

    /// <summary>
    ///     A component that is contextually associated to the content of the section.
    /// </summary>
    public IComponent? Accessory { get; set; }
}
