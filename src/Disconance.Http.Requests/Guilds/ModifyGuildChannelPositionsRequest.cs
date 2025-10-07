using Disconance.Models;
using Disconance.Models.Guilds;

namespace Disconance.Http.Requests.Guilds;

/// <summary>
///     Modify the positions of a set of channel objects for the guild. Requires MANAGE_CHANNELS permission. Returns a 204
///     empty response on success. Fires multiple Channel Update Gateway events. Only channels to be modified are required.
/// </summary>
/// <param name="GuildId">The ID of the guild to modify channel positions in.</param>
public record ModifyGuildChannelPositionsRequest(Snowflake GuildId) : IRequest<object>
{
    /// <summary>
    ///     Array of channel position modifications.
    /// </summary>
    public required List<ChannelPositionModification> Channels { get; set; }

    public HttpMethod Method => HttpMethod.Patch;

    public string Path => $"guilds/{GuildId}/channels";
}