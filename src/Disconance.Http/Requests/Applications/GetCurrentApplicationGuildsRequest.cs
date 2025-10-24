using Disconance.Models;
using Disconance.Models.Guilds;

namespace Disconance.Http.Requests.Applications;

/// <summary>
///     Returns a list of guilds the application is in. This endpoint is only available to bots.
/// </summary>
public class GetCurrentApplicationGuildsRequest : IRequest<List<Guild>>
{
    /// <summary>
    ///     The maximum number of guilds to return. Default 200, minimum 1, maximum 200.
    /// </summary>
    public int? Limit { get; set; }

    /// <summary>
    ///     Guild ID to start after. Used for pagination.
    /// </summary>
    public Snowflake? After { get; set; }

    public HttpMethod Method => HttpMethod.Get;

    public string Path => "applications/@me/guilds";
}