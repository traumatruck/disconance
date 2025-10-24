using Disconance.Models;
using Disconance.Models.Messages;

namespace Disconance.Http.Requests.Messages;

/// <summary>
///     Retrieves a specific message in the channel. Returns a message object. If operating on a guild channel, this
///     endpoint requires the VIEW_CHANNEL and READ_MESSAGE_HISTORY permissions. If the channel is a voice channel, the
///     CONNECT permission is also required.
/// </summary>
/// <param name="ChannelId">The ID of the channel the message is in.</param>
/// <param name="MessageId">The ID of the message to retrieve.</param>
public record GetChannelMessageRequest(Snowflake ChannelId, Snowflake MessageId) : IRequest<Message>
{
    public HttpMethod Method => HttpMethod.Get;

    public string Path => $"channels/{ChannelId}/messages/{MessageId}";
}