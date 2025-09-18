namespace Disconance.Models.Components;

/// <summary>
///     Button style.
///     https://discord.com/developers/docs/interactions/message-components#button-button-styles
/// </summary>
public enum ButtonStyle
{
    /// <summary>
    ///     Primary - The most important or recommended action in a group of options.
    /// </summary>
    Primary = 1,

    /// <summary>
    ///     Secondary - Alternative or supporting actions.
    /// </summary>
    Secondary = 2,

    /// <summary>
    ///     Success - Positive confirmation or completion actions.
    /// </summary>
    Success = 3,

    /// <summary>
    ///     Danger - An action with irreversible consequences.
    /// </summary>
    Danger = 4,

    /// <summary>
    ///     Link - Navigates to a URL.
    /// </summary>
    Link = 5,

    /// <summary>
    ///     Premium - Purchase.
    /// </summary>
    Premium = 6
}
