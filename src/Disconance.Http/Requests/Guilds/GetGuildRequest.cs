using Disconance.Models;
using Disconance.Models.Guilds;

namespace Disconance.Http.Requests.Guilds;

/// <summary>
///     Returns the guild object for the given id. If with_counts is set to true, this endpoint will also return
///     approximate_member_count and approximate_presence_count for the guild.
/// </summary>
/// <param name="GuildId">The ID of the guild to retrieve.</param>
public record GetGuildRequest(Snowflake GuildId) : IRequest<Guild>
{
    public HttpMethod Method => HttpMethod.Get;

    public string Path => $"guilds/{GuildId}";

    /// <summary>
    ///     When true, will return approximate member and presence counts for the guild.
    /// </summary>
    public bool? WithCounts { get; set; }
}