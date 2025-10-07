using Disconance.Models;
using Disconance.Models.Channels;

namespace Disconance.Http.Requests.Guilds;

/// <summary>
///     Returns a list of guild channel objects. Does not include threads.
/// </summary>
/// <param name="GuildId">The ID of the guild to get channels from.</param>
public record GetGuildChannelsRequest(Snowflake GuildId) : IRequest<List<Channel>>
{
    public HttpMethod Method => HttpMethod.Get;

    public string Path => $"guilds/{GuildId}/channels";
}