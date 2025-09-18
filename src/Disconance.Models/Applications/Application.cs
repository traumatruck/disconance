using Disconance.Models.Users;

namespace Disconance.Models.Applications;

/// <summary>
///     Represents a Discord application.
/// </summary>
public class Application
{
    /// <summary>
    ///     The ID of the app.
    /// </summary>
    public Snowflake Id { get; set; }

    /// <summary>
    ///     The name of the app.
    /// </summary>
    public required string Name { get; set; }

    /// <summary>
    ///     The icon hash of the app.
    /// </summary>
    public string? Icon { get; set; }

    /// <summary>
    ///     The description of the app.
    /// </summary>
    public string? Description { get; set; }

    /// <summary>
    ///     An array of RPC origin URLs, if RPC is enabled.
    /// </summary>
    public List<string>? RpcOrigins { get; set; }

    /// <summary>
    ///     When false only app owner can join the app's bot to guilds.
    /// </summary>
    public bool? BotPublic { get; set; }

    /// <summary>
    ///     When true the app's bot will only join upon completion of the full OAuth2 code grant flow.
    /// </summary>
    public bool? BotRequireCodeGrant { get; set; }

    /// <summary>
    ///     The url of the app's terms of service.
    /// </summary>
    public string? TermsOfServiceUrl { get; set; }

    /// <summary>
    ///     The url of the app's privacy policy.
    /// </summary>
    public string? PrivacyPolicyUrl { get; set; }

    /// <summary>
    ///     Partial user object containing info on the owner of the application.
    /// </summary>
    public User? Owner { get; set; }

    /// <summary>
    ///     If this application is a game sold on Discord, this field will be the summary field for the store page of its primary SKU.
    /// </summary>
    public string? Summary { get; set; }

    /// <summary>
    ///     The hex encoded key for verification in interactions and the GameSDK's GetTicket.
    /// </summary>
    public required string VerifyKey { get; set; }

    /// <summary>
    ///     If the application belongs to a team, this will be a list of the members of that team.
    /// </summary>
    public object? Team { get; set; } // TODO: Create Team model if needed

    /// <summary>
    ///     If this application is a game sold on Discord, this field will be the guild to which it has been linked.
    /// </summary>
    public Snowflake? GuildId { get; set; }

    /// <summary>
    ///     If this application is a game sold on Discord, this field will be the ID of the "Game SKU" that is created, if exists.
    /// </summary>
    public Snowflake? PrimarySkuId { get; set; }

    /// <summary>
    ///     If this application is a game sold on Discord, this field will be the URL slug that links to the store page.
    /// </summary>
    public string? Slug { get; set; }

    /// <summary>
    ///     The application's default rich presence invite cover image hash.
    /// </summary>
    public string? CoverImage { get; set; }

    /// <summary>
    ///     The application's public flags.
    /// </summary>
    public ApplicationFlags? Flags { get; set; }

    /// <summary>
    ///     The application's approximate guild count.
    /// </summary>
    public int? ApproximateGuildCount { get; set; }

    /// <summary>
    ///     The application's redirect URIs.
    /// </summary>
    public List<string>? RedirectUris { get; set; }

    /// <summary>
    ///     The interactions endpoint URL for the application.
    /// </summary>
    public string? InteractionsEndpointUrl { get; set; }

    /// <summary>
    ///     The role connection verification URL for the application.
    /// </summary>
    public string? RoleConnectionsVerificationUrl { get; set; }

    /// <summary>
    ///     The event webhooks URL for the application.
    /// </summary>
    public string? EventWebhooksUrl { get; set; }

    /// <summary>
    ///     The event webhooks status for the application.
    /// </summary>
    public string? EventWebhooksStatus { get; set; }

    /// <summary>
    ///     The event webhooks types for the application.
    /// </summary>
    public List<string>? EventWebhooksTypes { get; set; }

    /// <summary>
    ///     Up to 20 tags describing the content and functionality of the application.
    /// </summary>
    public List<string>? Tags { get; set; }

    /// <summary>
    ///     Settings for the application's default in-app authorization link, if enabled.
    /// </summary>
    public InstallParams? InstallParams { get; set; }

    /// <summary>
    ///     The application's default custom authorization link, if enabled.
    /// </summary>
    public string? CustomInstallUrl { get; set; }
}
