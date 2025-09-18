namespace Disconance.Models.Interactions;

/// <summary>
///     All options have names, and an option can either be a parameter and input value--in which case value will be
///     set--or it can denote a subcommand or group--in which case it will contain a top-level key and another array of
///     options.
///     https://discord.com/developers/docs/interactions/receiving-and-responding#interaction-object-application-command-interaction-data-option-structure
/// </summary>
public class ApplicationCommandInteractionDataOption
{
    /// <summary>
    ///     Name of the parameter.
    /// </summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    ///     Value of application command option type.
    /// </summary>
    public ApplicationCommandOptionType Type { get; set; }

    /// <summary>
    ///     Value of the option resulting from user input.
    /// </summary>
    public object? Value { get; set; }

    /// <summary>
    ///     Present if this option is a group or subcommand.
    /// </summary>
    public IEnumerable<ApplicationCommandInteractionDataOption> Options { get; set; }

    /// <summary>
    ///     True if this option is the currently focused option for autocomplete.
    /// </summary>
    public bool? Focused { get; set; }
}