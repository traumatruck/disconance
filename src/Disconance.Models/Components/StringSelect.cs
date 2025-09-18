namespace Disconance.Models.Components;

/// <summary>
///     A String Select is an interactive component that allows users to select one or more provided options.
///     https://discord.com/developers/docs/interactions/message-components#string-select
/// </summary>
public class StringSelect : IComponent
{
    /// <summary>
    ///     Type of the component.
    /// </summary>
    public ComponentType Type => ComponentType.StringSelect;

    /// <summary>
    ///     Optional identifier for the component.
    /// </summary>
    public int? Id { get; set; }

    /// <summary>
    ///     ID for the select menu; max 100 characters.
    /// </summary>
    public string CustomId { get; set; } = string.Empty;

    /// <summary>
    ///     Specified choices in a select menu; max 25.
    /// </summary>
    public List<SelectOption> Options { get; set; } = new();

    /// <summary>
    ///     Placeholder text if nothing is selected or default; max 150 characters.
    /// </summary>
    public string? Placeholder { get; set; }

    /// <summary>
    ///     Minimum number of items that must be chosen (defaults to 1); min 0, max 25.
    /// </summary>
    public int? MinValues { get; set; }

    /// <summary>
    ///     Maximum number of items that can be chosen (defaults to 1); max 25.
    /// </summary>
    public int? MaxValues { get; set; }

    /// <summary>
    ///     Whether the string select is required to answer in a modal (defaults to true).
    /// </summary>
    public bool? Required { get; set; }

    /// <summary>
    ///     Whether select menu is disabled in a message (defaults to false).
    /// </summary>
    public bool? Disabled { get; set; }
}
