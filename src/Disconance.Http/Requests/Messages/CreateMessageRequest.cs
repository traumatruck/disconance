using Disconance.Models;
using Disconance.Models.Components;
using Disconance.Models.Messages;
using Disconance.Models.Polls;

namespace Disconance.Http.Requests.Messages;

/// <summary>
///     Post a message to a guild text or DM channel. Returns a message object.
///     Fires a Message Create Gateway event.
/// </summary>
/// <param name="ChannelId">The ID of the channel to send the message in.</param>
public record CreateMessageRequest(Snowflake ChannelId) : IRequest<Message>
{
    /// <summary>
    ///     Allowed mentions for the message.
    /// </summary>
    public AllowedMentions? AllowedMentions { get; set; }

    /// <summary>
    ///     Attachment objects with filename and description.
    ///     See Uploading Files for details.
    /// </summary>
    public List<Attachment>? Attachments { get; set; }

    /// <summary>
    ///     Components to include with the message.
    /// </summary>
    public List<IComponent>? Components { get; set; }

    /// <summary>
    ///     Message contents (up to 2000 characters).
    /// </summary>
    public string? Content { get; set; }

    /// <summary>
    ///     Up to 10 rich embeds (up to 6000 characters).
    /// </summary>
    public List<Embed>? Embeds { get; set; }

    /// <summary>
    ///     If true and nonce is present, it will be checked for uniqueness in the past few minutes.
    ///     If another message was created by the same author with the same nonce,
    ///     that message will be returned and no new message will be created.
    /// </summary>
    public bool? EnforceNonce { get; set; }

    /// <summary>
    ///     Message flags combined as a bitfield
    ///     (only SUPPRESS_EMBEDS, SUPPRESS_NOTIFICATIONS, IS_VOICE_MESSAGE, and IS_COMPONENTS_V2 can be set).
    /// </summary>
    public MessageFlags? Flags { get; set; }

    /// <summary>
    ///     Include to make your message a reply or a forward.
    /// </summary>
    public MessageReference? MessageReference { get; set; }

    public HttpMethod Method => HttpMethod.Post;

    /// <summary>
    ///     Can be used to verify a message was sent (up to 25 characters).
    ///     Value will appear in the Message Create event.
    /// </summary>
    public object? Nonce { get; set; }

    public string Path => $"channels/{ChannelId}/messages";

    /// <summary>
    ///     A poll!
    /// </summary>
    public Poll? Poll { get; set; }

    /// <summary>
    ///     IDs of up to 3 stickers in the server to send in the message.
    /// </summary>
    public List<Snowflake>? StickerIds { get; set; }

    /// <summary>
    ///     true if this is a TTS message.
    /// </summary>
    public bool? Tts { get; set; }
}