namespace Disconance.Models.Components;

/// <summary>
///     A Separator is a top-level layout component that adds vertical padding and visual division between other components.
///     https://discord.com/developers/docs/interactions/message-components#separator
/// </summary>
public class Separator : IComponent
{
    /// <summary>
    ///     Type of the component.
    /// </summary>
    public ComponentType Type => ComponentType.Separator;

    /// <summary>
    ///     Optional identifier for the component.
    /// </summary>
    public int? Id { get; set; }

    /// <summary>
    ///     Whether a visual divider should be displayed in the component. Defaults to true.
    /// </summary>
    public bool? Divider { get; set; } = true;

    /// <summary>
    ///     Size of separator padding—1 for small padding, 2 for large padding. Defaults to 1.
    /// </summary>
    public int? Spacing { get; set; } = 1;
}
