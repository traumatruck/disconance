namespace Disconance.Models.Interactions;

/// <summary>
///     Represents an option for an application command.
/// </summary>
public class ApplicationCommandOption
{
    /// <summary>
    ///     Type of option.
    /// </summary>
    public ApplicationCommandOptionType Type { get; set; }

    /// <summary>
    ///     1-32 character name.
    /// </summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    ///     Localization dictionary for the name field.
    /// </summary>
    public Dictionary<string, string>? NameLocalizations { get; set; }

    /// <summary>
    ///     1-100 character description.
    /// </summary>
    public string Description { get; set; } = string.Empty;

    /// <summary>
    ///     Localization dictionary for the description field.
    /// </summary>
    public Dictionary<string, string>? DescriptionLocalizations { get; set; }

    /// <summary>
    ///     Whether the parameter is required or optional, default false.
    /// </summary>
    public bool? Required { get; set; }

    /// <summary>
    ///     Choices for the user to pick from, max 25.
    /// </summary>
    public List<ApplicationCommandOptionChoice>? Choices { get; set; }

    /// <summary>
    ///     Nested options for subcommands or subcommand groups, up to 25.
    /// </summary>
    public List<ApplicationCommandOption>? Options { get; set; }

    /// <summary>
    ///     The channels shown will be restricted to these types.
    /// </summary>
    public List<int>? ChannelTypes { get; set; }

    /// <summary>
    ///     The minimum value permitted (integer or double).
    /// </summary>
    public double? MinValue { get; set; }

    /// <summary>
    ///     The maximum value permitted (integer or double).
    /// </summary>
    public double? MaxValue { get; set; }

    /// <summary>
    ///     The minimum allowed length (minimum of 0, maximum of 6000).
    /// </summary>
    public int? MinLength { get; set; }

    /// <summary>
    ///     The maximum allowed length (minimum of 1, maximum of 6000).
    /// </summary>
    public int? MaxLength { get; set; }

    /// <summary>
    ///     If autocomplete interactions are enabled for this option.
    /// </summary>
    public bool? Autocomplete { get; set; }
}