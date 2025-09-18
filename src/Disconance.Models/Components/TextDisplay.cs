namespace Disconance.Models.Components;

/// <summary>
///     A Text Display is a content component that allows you to add markdown formatted text.
///     https://discord.com/developers/docs/interactions/message-components#text-display
/// </summary>
public class TextDisplay : IComponent
{
    /// <summary>
    ///     Type of the component.
    /// </summary>
    public ComponentType Type => ComponentType.TextDisplay;

    /// <summary>
    ///     Optional identifier for the component.
    /// </summary>
    public int? Id { get; set; }

    /// <summary>
    ///     Text that will be displayed similar to a message.
    /// </summary>
    public string Content { get; set; } = string.Empty;
}
