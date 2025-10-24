using Disconance.Models;

namespace Disconance.Http.Requests.Applications;

/// <summary>
///     Deletes a global command. Returns 204 No Content on success.
/// </summary>
/// <param name="ApplicationId"></param>
/// <param name="CommandId"></param>
public record DeleteGlobalApplicationCommandRequest(Snowflake ApplicationId, Snowflake CommandId) : IRequest<object>
{
    public HttpMethod Method => HttpMethod.Delete;

    public string Path => $"applications/{ApplicationId}/commands/{CommandId}";
}