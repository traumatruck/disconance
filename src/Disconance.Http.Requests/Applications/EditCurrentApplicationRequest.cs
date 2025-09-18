using Disconance.Models.Applications;

namespace Disconance.Http.Requests.Applications;

/// <summary>
///     Edit properties of the app associated with the requesting bot user. All parameters to this endpoint are optional.
/// </summary>
public record EditCurrentApplicationRequest : IRequest<Application>
{
    /// <summary>
    ///     The name of the app.
    /// </summary>
    public string? Name { get; init; }

    /// <summary>
    ///     The description of the app.
    /// </summary>
    public string? Description { get; init; }

    /// <summary>
    ///     An array of RPC origin URLs, if RPC is enabled.
    /// </summary>
    public List<string>? RpcOrigins { get; init; }

    /// <summary>
    ///     When false only app owner can join the app's bot to guilds.
    /// </summary>
    public bool? BotPublic { get; init; }

    /// <summary>
    ///     When true the app's bot will only join upon completion of the full OAuth2 code grant flow.
    /// </summary>
    public bool? BotRequireCodeGrant { get; init; }

    /// <summary>
    ///     The url of the app's terms of service.
    /// </summary>
    public string? TermsOfServiceUrl { get; init; }

    /// <summary>
    ///     The url of the app's privacy policy.
    /// </summary>
    public string? PrivacyPolicyUrl { get; init; }

    /// <summary>
    ///     The interactions endpoint URL for the application.
    /// </summary>
    public string? InteractionsEndpointUrl { get; init; }

    /// <summary>
    ///     The role connection verification URL for the application.
    /// </summary>
    public string? RoleConnectionsVerificationUrl { get; init; }

    /// <summary>
    ///     Up to 20 tags describing the content and functionality of the application.
    /// </summary>
    public List<string>? Tags { get; init; }

    /// <summary>
    ///     Settings for the application's default in-app authorization link, if enabled.
    /// </summary>
    public InstallParams? InstallParams { get; init; }

    /// <summary>
    ///     The application's default custom authorization link, if enabled.
    /// </summary>
    public string? CustomInstallUrl { get; init; }

    public HttpMethod Method => HttpMethod.Patch;

    public string Path => "applications/@me";
}