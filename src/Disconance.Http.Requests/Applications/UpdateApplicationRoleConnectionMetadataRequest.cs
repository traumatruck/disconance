using Disconance.Models.Applications;

namespace Disconance.Http.Requests.Applications;

/// <summary>
///     Updates and returns a list of application role connection metadata objects for the given application.
/// </summary>
public record UpdateApplicationRoleConnectionMetadataRequest : IRequest<List<ApplicationRoleConnectionMetadata>>
{
    /// <summary>
    ///     The metadata to update.
    /// </summary>
    public required List<ApplicationRoleConnectionMetadata> Metadata { get; init; }

    public HttpMethod Method => HttpMethod.Put;

    public string Path => "applications/@me/role-connections/metadata";
}