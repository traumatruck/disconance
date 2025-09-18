namespace Disconance.Models.Components;

/// <summary>
///     A Role Select is an interactive component that allows users to select one or more roles in a message.
///     https://discord.com/developers/docs/interactions/message-components#role-select
/// </summary>
public class RoleSelect : IComponent
{
    /// <summary>
    ///     Type of the component.
    /// </summary>
    public ComponentType Type => ComponentType.RoleSelect;

    /// <summary>
    ///     Optional identifier for the component.
    /// </summary>
    public int? Id { get; set; }

    /// <summary>
    ///     ID for the select menu; max 100 characters.
    /// </summary>
    public string CustomId { get; set; } = string.Empty;

    /// <summary>
    ///     Placeholder text if nothing is selected; max 150 characters.
    /// </summary>
    public string? Placeholder { get; set; }

    /// <summary>
    ///     List of default values for auto-populated select menu components.
    /// </summary>
    public List<DefaultValue>? DefaultValues { get; set; }

    /// <summary>
    ///     Minimum number of items that must be chosen (defaults to 1); min 0, max 25.
    /// </summary>
    public int? MinValues { get; set; }

    /// <summary>
    ///     Maximum number of items that can be chosen (defaults to 1); max 25.
    /// </summary>
    public int? MaxValues { get; set; }

    /// <summary>
    ///     Whether select menu is disabled (defaults to false).
    /// </summary>
    public bool? Disabled { get; set; }
}
