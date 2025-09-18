using System.Text.Json.Serialization;
using Disconance.Models.Channels;
using Disconance.Models.Entitlements;
using Disconance.Models.Guilds;
using Disconance.Models.JsonConverters;
using Disconance.Models.Messages;
using Disconance.Models.Users;

namespace Disconance.Models.Interactions;

/// <summary>
///     Represents an interaction received from Discord.
///     https://discord.com/developers/docs/interactions/receiving-and-responding#interaction-object
/// </summary>
[JsonConverter(typeof(InteractionJsonConverter))]
public class Interaction
{
    /// <summary>
    ///     ID of the interaction.
    /// </summary>
    public Snowflake Id { get; set; }

    /// <summary>
    ///     ID of the application this interaction is for.
    /// </summary>
    public Snowflake ApplicationId { get; set; }

    /// <summary>
    ///     Type of interaction.
    /// </summary>
    public InteractionType Type { get; set; }

    /// <summary>
    ///     Interaction data payload.
    /// </summary>
    public IInteractionData? Data { get; set; }

    /// <summary>
    ///     Guild that the interaction was sent from.
    /// </summary>
    public Guild? Guild { get; set; }

    /// <summary>
    ///     Guild that the interaction was sent from.
    /// </summary>
    public Snowflake? GuildId { get; set; }

    /// <summary>
    ///     Channel that the interaction was sent from.
    /// </summary>
    public Channel? Channel { get; set; }

    /// <summary>
    ///     Channel that the interaction was sent from.
    /// </summary>
    public Snowflake? ChannelId { get; set; }

    /// <summary>
    ///     Guild member data for the invoking user, including permissions.
    /// </summary>
    public GuildMember? Member { get; set; }

    /// <summary>
    ///     User object for the invoking user, if invoked in a DM.
    /// </summary>
    public User? User { get; set; }

    /// <summary>
    ///     Continuation token for responding to the interaction.
    /// </summary>
    public string Token { get; set; } = string.Empty;

    /// <summary>
    ///     Read-only property, always 1.
    /// </summary>
    public int Version { get; set; } = 1;

    /// <summary>
    ///     For components or modals triggered by components, the message they were attached to.
    /// </summary>
    public Message? Message { get; set; }

    /// <summary>
    ///     Bitwise set of permissions the app has in the source location of the interaction.
    /// </summary>
    public string AppPermissions { get; set; } = string.Empty;

    /// <summary>
    ///     Selected language of the invoking user.
    /// </summary>
    public string? Locale { get; set; }

    /// <summary>
    ///     Guild's preferred locale, if invoked in a guild.
    /// </summary>
    public string? GuildLocale { get; set; }

    /// <summary>
    ///     For monetized apps, any entitlements for the invoking user.
    /// </summary>
    public List<Entitlement> Entitlements { get; set; } = new();

    /// <summary>
    ///     Mapping of installation contexts that the interaction was authorized for to related user or guild IDs.
    /// </summary>
    public Dictionary<string, string> AuthorizingIntegrationOwners { get; set; } = new();

    /// <summary>
    ///     Context where the interaction was triggered from.
    /// </summary>
    public InteractionContextType? Context { get; set; }

    /// <summary>
    ///     Attachment size limit in bytes.
    /// </summary>
    public int AttachmentSizeLimit { get; set; }
}
