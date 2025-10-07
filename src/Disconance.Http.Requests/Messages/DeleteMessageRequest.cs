using Disconance.Models;

namespace Disconance.Http.Requests.Messages;

/// <summary>
///     Delete a message. If operating on a guild channel and trying to delete a message that was not sent by the current
///     user, this endpoint requires the MANAGE_MESSAGES permission. Returns 204 No Content on success. Fires a Message
///     Delete Gateway event.
/// </summary>
/// <param name="ChannelId">The ID of the channel the message is in.</param>
/// <param name="MessageId">The ID of the message to delete.</param>
public record DeleteMessageRequest(Snowflake ChannelId, Snowflake MessageId) : IRequest<object>
{
    public HttpMethod Method => HttpMethod.Delete;

    public string Path => $"channels/{ChannelId}/messages/{MessageId}";
}