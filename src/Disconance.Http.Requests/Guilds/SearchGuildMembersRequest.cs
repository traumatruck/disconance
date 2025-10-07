using Disconance.Models;
using Disconance.Models.Guilds;

namespace Disconance.Http.Requests.Guilds;

/// <summary>
///     Returns a list of guild member objects whose username or nickname starts with a provided string.
/// </summary>
/// <param name="GuildId">The ID of the guild.</param>
public record SearchGuildMembersRequest(Snowflake GuildId) : IRequest<List<GuildMember>>
{
    /// <summary>
    ///     Max number of members to return (1-1000). Default 1.
    /// </summary>
    public int? Limit { get; set; }

    public HttpMethod Method => HttpMethod.Get;

    public string Path => $"guilds/{GuildId}/members/search";

    /// <summary>
    ///     Query string to match username(s) and nickname(s) against.
    /// </summary>
    public required string Query { get; set; }
}