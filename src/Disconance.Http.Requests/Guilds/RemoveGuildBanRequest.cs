using Disconance.Models;

namespace Disconance.Http.Requests.Guilds;

/// <summary>
///     Remove the ban for a user. Requires the BAN_MEMBERS permission.
///     Returns a 204 empty response on success. Fires a Guild Ban Remove Gateway event.
/// </summary>
/// <param name="GuildId">The ID of the guild.</param>
/// <param name="UserId">The ID of the user to unban.</param>
public record RemoveGuildBanRequest(Snowflake GuildId, Snowflake UserId) : IRequest<object>
{
    public HttpMethod Method => HttpMethod.Delete;

    public string Path => $"guilds/{GuildId}/bans/{UserId}";
}