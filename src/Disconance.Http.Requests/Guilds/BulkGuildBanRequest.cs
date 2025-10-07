using Disconance.Models;
using Disconance.Models.Guilds;

namespace Disconance.Http.Requests.Guilds;

/// <summary>
///     Ban up to 200 users from a guild, and optionally delete previous messages sent by the banned users. Requires both
///     the BAN_MEMBERS and MANAGE_GUILD permissions. Returns a 200 response on success, including the fields banned_users
///     and failed_users.
/// </summary>
/// <param name="GuildId">The ID of the guild.</param>
public record BulkGuildBanRequest(Snowflake GuildId) : IRequest<BulkBanResponse>
{
    /// <summary>
    ///     Number of seconds to delete messages for, between 0 and 604800 (7 days).
    /// </summary>
    public int? DeleteMessageSeconds { get; set; }

    public HttpMethod Method => HttpMethod.Post;

    public string Path => $"guilds/{GuildId}/bulk-ban";

    /// <summary>
    ///     List of user ids to ban (max 200).
    /// </summary>
    public required List<Snowflake> UserIds { get; set; }
}