namespace Disconance.Models.Interactions;

/// <summary>
///     Represents a choice for an application command option.
/// </summary>
public class ApplicationCommandOptionChoice
{
    /// <summary>
    ///     1-100 character choice name.
    /// </summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    ///     Localization dictionary for the name field. Values follow the same restrictions as name.
    /// </summary>
    public Dictionary<string, string>? NameLocalizations { get; set; }

    /// <summary>
    ///     Value for the choice, up to 100 characters if string. Can be string, int, or double.
    /// </summary>
    public object Value { get; set; } = string.Empty;
}