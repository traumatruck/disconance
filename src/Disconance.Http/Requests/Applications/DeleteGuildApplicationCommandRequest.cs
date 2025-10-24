using Disconance.Models;

namespace Disconance.Http.Requests.Applications;

/// <summary>
///     Deletes a guild command. Returns 204 No Content on success.
/// </summary>
/// <param name="ApplicationId"></param>
/// <param name="GuildId"></param>
/// <param name="CommandId"></param>
public record DeleteGuildApplicationCommandRequest(Snowflake ApplicationId, Snowflake GuildId, Snowflake CommandId)
    : IRequest<object>
{
    public HttpMethod Method => HttpMethod.Delete;

    public string Path => $"applications/{ApplicationId}/guilds/{GuildId}/commands/{CommandId}";
}