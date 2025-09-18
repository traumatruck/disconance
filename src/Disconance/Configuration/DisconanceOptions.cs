using System.ComponentModel.DataAnnotations;

namespace Disconance.Configuration;

/// <summary>
///     Represents configuration options for the Disconance library.
/// </summary>
public sealed record DisconanceOptions
{
    public const string ConfigurationSectionName = "Disconance";

    /// <summary>
    ///     The unique identifier of the Discord application.
    /// </summary>
    [Required]
    public required ulong ApplicationId { get; init; }

    /// <summary>
    ///     The authentication token for the Discord bot. It is recommended to save this as a secret.
    /// </summary>
    [Required]
    public required string BotToken { get; init; }

    /// <summary>
    ///     The public key associated with the Discord application, used to validate interaction signatures.
    /// </summary>
    [Required]
    public required string PublicKey { get; init; }
}