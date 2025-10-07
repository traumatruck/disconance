using Disconance.Models;
using Disconance.Models.Messages;

namespace Disconance.Http.Requests.Messages;

/// <summary>
///     Retrieves the messages in a channel. Returns an array of message objects from newest to oldest. If operating on a
///     guild channel, this endpoint requires the VIEW_CHANNEL permission. If the current user is missing the
///     READ_MESSAGE_HISTORY permission in the channel, then no messages will be
///     returned.
/// </summary>
/// <param name="ChannelId">The ID of the channel to retrieve messages from.</param>
public record GetChannelMessagesRequest(Snowflake ChannelId) : IRequest<List<Message>>
{
    /// <summary>
    ///     Get messages after this message ID.
    ///     The before, after, and around parameters are mutually exclusive, only one may be passed at a time.
    /// </summary>
    public Snowflake? After { get; set; }

    /// <summary>
    ///     Get messages around this message ID.
    ///     The before, after, and around parameters are mutually exclusive, only one may be passed at a time.
    /// </summary>
    public Snowflake? Around { get; set; }

    /// <summary>
    ///     Get messages before this message ID.
    ///     The before, after, and around parameters are mutually exclusive, only one may be passed at a time.
    /// </summary>
    public Snowflake? Before { get; set; }

    /// <summary>
    ///     Max number of messages to return (1-100). Default 50.
    /// </summary>
    public int? Limit { get; set; }

    public HttpMethod Method => HttpMethod.Get;

    public string Path => $"channels/{ChannelId}/messages";
}