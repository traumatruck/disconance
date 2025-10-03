using System.Text.Json.Serialization;
using Disconance.Models.Components;
using Disconance.Models.JsonConverters;
using Disconance.Models.Messages;
using Disconance.Models.Polls;

namespace Disconance.Models.Interactions;

/// <summary>
///     Represents the callback data for message-based interaction responses.
///     https://discord.com/developers/docs/interactions/receiving-and-responding#interaction-callback-data-structure
/// </summary>
public record InteractionMessageCallbackData : IInteractionCallbackData
{
    /// <summary>
    ///     Whether the response is TTS.
    /// </summary>
    public bool? Tts { get; init; }

    /// <summary>
    ///     Message content.
    /// </summary>
    public string? Content { get; init; }

    /// <summary>
    ///     Supports up to 10 embeds.
    /// </summary>
    public IEnumerable<Embed>? Embeds { get; init; }

    /// <summary>
    ///     Allowed mentions object.
    /// </summary>
    public AllowedMentions? AllowedMentions { get; init; }

    /// <summary>
    ///     Message flags combined as a bitfield.
    /// </summary>
    public MessageFlags? Flags { get; init; }

    /// <summary>
    ///     Message components.
    /// </summary>
    [JsonConverter(typeof(ComponentCollectionJsonConverter))]
    public IEnumerable<IComponent>? Components { get; set; }

    /// <summary>
    ///     Attachment objects with filename and description.
    /// </summary>
    public IEnumerable<Attachment>? Attachments { get; init; }

    /// <summary>
    ///     Details about the poll.
    /// </summary>
    public Poll? Poll { get; init; }
}
