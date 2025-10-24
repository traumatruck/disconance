using Disconance.Models.Applications;

namespace Disconance.Http.Requests.Applications;

/// <summary>
///     Returns a list of application role connection metadata objects for the given application.
/// </summary>
public class GetApplicationRoleConnectionMetadataRequest : IRequest<List<ApplicationRoleConnectionMetadata>>
{
    public HttpMethod Method => HttpMethod.Get;

    public string Path => "applications/@me/role-connections/metadata";
}