using Disconance.Models;

namespace Disconance.Http.Requests.Messages;

/// <summary>
///     Delete multiple messages in a single request. This endpoint can only be used on guild channels
///     and requires the MANAGE_MESSAGES permission. Returns 204 No Content on success.
///     Fires a Message Delete Bulk Gateway event.
///     This endpoint will not delete messages older than 2 weeks, and will fail if any message provided is older than
///     that.
/// </summary>
/// <param name="ChannelId">The ID of the channel to delete messages from.</param>
public record BulkDeleteMessagesRequest(Snowflake ChannelId) : IRequest<object>
{
    /// <summary>
    ///     An array of message ids to delete (2-100).
    /// </summary>
    public required List<Snowflake> Messages { get; set; }

    public HttpMethod Method => HttpMethod.Post;

    public string Path => $"channels/{ChannelId}/messages/bulk-delete";
}