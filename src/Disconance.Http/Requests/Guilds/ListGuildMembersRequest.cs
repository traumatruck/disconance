using Disconance.Models;
using Disconance.Models.Guilds;

namespace Disconance.Http.Requests.Guilds;

/// <summary>
///     Returns a list of guild member objects that are members of the guild. This endpoint is restricted according to
///     whether the GUILD_MEMBERS Privileged Intent is enabled for your application.
/// </summary>
/// <param name="GuildId">The ID of the guild.</param>
public record ListGuildMembersRequest(Snowflake GuildId) : IRequest<List<GuildMember>>
{
    /// <summary>
    ///     The highest user id in the previous page. Default 0.
    /// </summary>
    public Snowflake? After { get; set; }

    /// <summary>
    ///     Max number of members to return (1-1000). Default 1.
    /// </summary>
    public int? Limit { get; set; }

    public HttpMethod Method => HttpMethod.Get;

    public string Path => $"guilds/{GuildId}/members";
}