namespace Disconance.Models.Applications;

/// <summary>
///     Application role connection metadata object.
/// </summary>
public class ApplicationRoleConnectionMetadata
{
    /// <summary>
    ///     Type of metadata value.
    /// </summary>
    public required ApplicationRoleConnectionMetadataType Type { get; set; }

    /// <summary>
    ///     Dictionary key for the metadata field (must be a-z, 0-9, or _ characters; 1-50 characters).
    /// </summary>
    public required string Key { get; set; }

    /// <summary>
    ///     Name of the metadata field (1-100 characters).
    /// </summary>
    public required string Name { get; set; }

    /// <summary>
    ///     Translations of the name.
    /// </summary>
    public Dictionary<string, string>? NameLocalizations { get; set; }

    /// <summary>
    ///     Description of the metadata field (1-200 characters).
    /// </summary>
    public required string Description { get; set; }

    /// <summary>
    ///     Translations of the description.
    /// </summary>
    public Dictionary<string, string>? DescriptionLocalizations { get; set; }
}