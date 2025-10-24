using Disconance.Models.Applications;

namespace Disconance.Http.Requests.Applications;

/// <summary>
///     Returns the application object associated with the requesting bot user. This endpoint requires a bot token.
/// </summary>
public class GetCurrentApplicationRequest : IRequest<Application>
{
    public HttpMethod Method => HttpMethod.Get;

    public string Path => "applications/@me";
}