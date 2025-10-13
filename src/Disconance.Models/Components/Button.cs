using Disconance.Models.Emojis;

namespace Disconance.Models.Components;

/// <summary>
///     A Button is an interactive component that can only be used in messages.
///     https://discord.com/developers/docs/interactions/message-components#button
/// </summary>
public class Button : IComponent
{
    /// <summary>
    ///     Type of the component.
    /// </summary>
    public ComponentType Type => ComponentType.Button;

    /// <summary>
    ///     Optional identifier for the component.
    /// </summary>
    public int? Id { get; set; }

    /// <summary>
    ///     A button style.
    /// </summary>
    public required ButtonStyle Style { get; init; }

    /// <summary>
    ///     Text that appears on the button; max 80 characters.
    /// </summary>
    public string? Label { get; set; }

    /// <summary>
    ///     Emoji object.
    /// </summary>
    public Emoji? Emoji { get; set; }

    /// <summary>
    ///     Developer-defined identifier for the button; max 100 characters.
    /// </summary>
    public string CustomId { get; set; } = string.Empty;

    /// <summary>
    ///     Identifier for a purchasable SKU, only available when using premium-style buttons.
    /// </summary>
    public ulong? SkuId { get; set; }

    /// <summary>
    ///     URL for link-style buttons; max 512 characters.
    /// </summary>
    public string? Url { get; set; }

    /// <summary>
    ///     Whether the button is disabled (defaults to false).
    /// </summary>
    public bool? Disabled { get; set; }
}
