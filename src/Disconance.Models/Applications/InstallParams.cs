namespace Disconance.Models.Applications;

/// <summary>
///     Settings for the application's default in-app authorization link, if enabled.
/// </summary>
public class InstallParams
{
    /// <summary>
    ///     The scopes to add the application to the server with.
    /// </summary>
    public required List<string> Scopes { get; set; }

    /// <summary>
    ///     The permissions to request for the bot role.
    /// </summary>
    public required string Permissions { get; set; }
}