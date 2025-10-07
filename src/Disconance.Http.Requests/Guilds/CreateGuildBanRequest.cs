using Disconance.Models;

namespace Disconance.Http.Requests.Guilds;

/// <summary>
///     Create a guild ban, and optionally delete previous messages sent by the banned user. Requires the BAN_MEMBERS
///     permission. Returns a 204 empty response on success. Fires a Guild Ban Add Gateway event.
/// </summary>
/// <param name="GuildId">The ID of the guild.</param>
/// <param name="UserId">The ID of the user to ban.</param>
public record CreateGuildBanRequest(Snowflake GuildId, Snowflake UserId) : IRequest<object>
{
    /// <summary>
    ///     Number of days to delete messages for (0-7) (deprecated).
    /// </summary>
    public int? DeleteMessageDays { get; set; }

    /// <summary>
    ///     Number of seconds to delete messages for, between 0 and 604800 (7 days).
    /// </summary>
    public int? DeleteMessageSeconds { get; set; }

    public HttpMethod Method => HttpMethod.Put;

    public string Path => $"guilds/{GuildId}/bans/{UserId}";
}