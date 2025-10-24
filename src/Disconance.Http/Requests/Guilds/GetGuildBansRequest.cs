using Disconance.Models;
using Disconance.Models.Guilds;

namespace Disconance.Http.Requests.Guilds;

/// <summary>
///     Returns a list of ban objects for the users banned from this guild. Requires the BAN_MEMBERS permission.
/// </summary>
/// <param name="GuildId">The ID of the guild.</param>
public record GetGuildBansRequest(Snowflake GuildId) : IRequest<List<Ban>>
{
    /// <summary>
    ///     Consider only users after given user id.
    /// </summary>
    public Snowflake? After { get; set; }

    /// <summary>
    ///     Consider only users before given user id.
    /// </summary>
    public Snowflake? Before { get; set; }

    /// <summary>
    ///     Number of users to return (up to maximum 1000). Default 1000.
    /// </summary>
    public int? Limit { get; set; }

    public HttpMethod Method => HttpMethod.Get;

    public string Path => $"guilds/{GuildId}/bans";
}