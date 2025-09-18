using System.Text.Json;
using System.Text.Json.Serialization;
using Disconance.Models.Channels;
using Disconance.Models.Entitlements;
using Disconance.Models.Guilds;
using Disconance.Models.Interactions;
using Disconance.Models.Messages;
using Disconance.Models.Users;

namespace Disconance.Models.JsonConverters;

/// <summary>
///     Custom JSON converter for Interaction objects that handles deserialization of IInteractionData based on
///     InteractionType.
/// </summary>
public class InteractionJsonConverter : JsonConverter<Interaction>
{
    public override Interaction Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        using var doc = JsonDocument.ParseValue(ref reader);
        var root = doc.RootElement;

        var interaction = new Interaction();

        if (root.TryGetProperty("id", out var idElement))
        {
            interaction.Id = idElement.Deserialize<Snowflake>(options)!;
        }

        if (root.TryGetProperty("application_id", out var appIdElement))
        {
            interaction.ApplicationId = appIdElement.Deserialize<Snowflake>(options)!;
        }

        if (root.TryGetProperty("type", out var typeElement))
        {
            interaction.Type = typeElement.Deserialize<InteractionType>(options);
        }

        if (root.TryGetProperty("guild", out var guildElement))
        {
            interaction.Guild = guildElement.Deserialize<Guild>(options);
        }

        if (root.TryGetProperty("guild_id", out var guildIdElement))
        {
            interaction.GuildId = guildIdElement.Deserialize<Snowflake>(options);
        }

        if (root.TryGetProperty("channel", out var channelElement))
        {
            interaction.Channel = channelElement.Deserialize<Channel>(options);
        }

        if (root.TryGetProperty("channel_id", out var channelIdElement))
        {
            interaction.ChannelId = channelIdElement.Deserialize<Snowflake>(options);
        }

        if (root.TryGetProperty("member", out var memberElement))
        {
            interaction.Member = memberElement.Deserialize<GuildMember>(options);
        }

        if (root.TryGetProperty("user", out var userElement))
        {
            interaction.User = userElement.Deserialize<User>(options);
        }

        if (root.TryGetProperty("token", out var tokenElement))
        {
            interaction.Token = tokenElement.GetString() ?? string.Empty;
        }

        if (root.TryGetProperty("version", out var versionElement))
        {
            interaction.Version = versionElement.GetInt32();
        }

        if (root.TryGetProperty("message", out var messageElement))
        {
            interaction.Message = messageElement.Deserialize<Message>(options);
        }

        if (root.TryGetProperty("app_permissions", out var appPermElement))
        {
            interaction.AppPermissions = appPermElement.GetString() ?? string.Empty;
        }

        if (root.TryGetProperty("locale", out var localeElement))
        {
            interaction.Locale = localeElement.GetString();
        }

        if (root.TryGetProperty("guild_locale", out var guildLocaleElement))
        {
            interaction.GuildLocale = guildLocaleElement.GetString();
        }

        if (root.TryGetProperty("entitlements", out var entitlementsElement))
        {
            interaction.Entitlements =
                entitlementsElement.Deserialize<List<Entitlement>>(options) ?? new List<Entitlement>();
        }

        if (root.TryGetProperty("authorizing_integration_owners", out var authIntElement))
        {
            interaction.AuthorizingIntegrationOwners =
                authIntElement.Deserialize<Dictionary<string, string>>(options) ?? new Dictionary<string, string>();
        }

        if (root.TryGetProperty("context", out var contextElement))
        {
            interaction.Context = contextElement.Deserialize<InteractionContextType>(options);
        }

        if (root.TryGetProperty("attachment_size_limit", out var attachLimitElement))
        {
            interaction.AttachmentSizeLimit = attachLimitElement.GetInt32();
        }

        if (root.TryGetProperty("data", out var dataElement) && dataElement.ValueKind != JsonValueKind.Null)
        {
            interaction.Data = interaction.Type switch
            {
                InteractionType.ApplicationCommand => dataElement.Deserialize<ApplicationCommandData>(options),
                InteractionType.ApplicationCommandAutocomplete => dataElement.Deserialize<ApplicationCommandData>(
                    options), // Assuming same structure
                InteractionType.MessageComponent => dataElement.Deserialize<MessageComponentData>(options),
                InteractionType.ModalSubmit => dataElement.Deserialize<ModalSubmitData>(options),
                _ => null
            };
        }

        return interaction;
    }

    public override void Write(Utf8JsonWriter writer, Interaction value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(writer, value, options);
    }
}