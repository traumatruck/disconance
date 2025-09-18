namespace Disconance.Models.Users;

/// <summary>
///     Represents a user on Discord.
/// </summary>
public class User
{
    /// <summary>
    ///     The user's id.
    /// </summary>
    public Snowflake Id { get; set; }

    /// <summary>
    ///     The user's username, not unique across the platform.
    /// </summary>
    public string Username { get; set; } = string.Empty;

    /// <summary>
    ///     The user's display name, if it is set.
    /// </summary>
    public string? DisplayName { get; set; }

    /// <summary>
    ///     The user's avatar hash.
    /// </summary>
    public string? Avatar { get; set; }

    /// <summary>
    ///     Whether the user belongs to an OAuth2 application.
    /// </summary>
    public bool? Bot { get; set; }

    /// <summary>
    ///     Whether the user is an Official Discord System user (part of the urgent message system).
    /// </summary>
    public bool? System { get; set; }

    /// <summary>
    ///     Whether the user has two factor enabled on their account.
    /// </summary>
    public bool? MfaEnabled { get; set; }

    /// <summary>
    ///     The user's banner hash.
    /// </summary>
    public string? Banner { get; set; }

    /// <summary>
    ///     The user's banner color encoded as an integer representation of hexadecimal color code.
    /// </summary>
    public int? AccentColor { get; set; }

    /// <summary>
    ///     The user's chosen language option.
    /// </summary>
    public string? Locale { get; set; }

    /// <summary>
    ///     Whether the email on this account has been verified.
    /// </summary>
    public bool? Verified { get; set; }

    /// <summary>
    ///     The user's email.
    /// </summary>
    public string? Email { get; set; }

    /// <summary>
    ///     The flags on a user's account.
    /// </summary>
    public int? Flags { get; set; }

    /// <summary>
    ///     The type of Nitro subscription on a user's account.
    /// </summary>
    public int? PremiumType { get; set; }

    /// <summary>
    ///     The public flags on a user's account.
    /// </summary>
    public int? PublicFlags { get; set; }
}