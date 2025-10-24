using Disconance.Models;
using Disconance.Models.Components;
using Disconance.Models.Messages;

namespace Disconance.Http.Requests.Messages;

/// <summary>
///     Edit a previously sent message. The fields content, embeds, flags and components can be edited by the original
///     message author. Other users can only edit flags and only if they have the MANAGE_MESSAGES permission in the
///     corresponding channel. When specifying flags, ensure to include all previously set flags/bits in addition to ones
///     that you are modifying. Returns a message object. Fires a Message Update Gateway event.
/// </summary>
/// <param name="ChannelId">The ID of the channel the message is in.</param>
/// <param name="MessageId">The ID of the message to edit.</param>
public record EditMessageRequest(Snowflake ChannelId, Snowflake MessageId) : IRequest<Message>
{
    /// <summary>
    ///     Allowed mentions for the message.
    /// </summary>
    public AllowedMentions? AllowedMentions { get; set; }

    /// <summary>
    ///     Attached files to keep and possible descriptions for new files.
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
    ///     Edit the flags of a message (SUPPRESS_EMBEDS and IS_COMPONENTS_V2 only).
    /// </summary>
    public MessageFlags? Flags { get; set; }

    public HttpMethod Method => HttpMethod.Patch;

    public string Path => $"channels/{ChannelId}/messages/{MessageId}";
}