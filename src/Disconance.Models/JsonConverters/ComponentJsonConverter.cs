using System.Text.Json;
using System.Text.Json.Serialization;
using Disconance.Models.Components;

namespace Disconance.Models.JsonConverters;

/// <summary>
///     Custom JSON converter for IComponent and collections of IComponent.
/// </summary>
public class ComponentJsonConverter : JsonConverter<IComponent>
{
    public override IComponent Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        using var doc = JsonDocument.ParseValue(ref reader);
        var root = doc.RootElement;

        if (!root.TryGetProperty("type", out var typeElement))
        {
            throw new JsonException("Component JSON must have a 'type' property.");
        }

        var componentType = (ComponentType) typeElement.GetInt32();

        return componentType switch
        {
            ComponentType.ActionRow => JsonSerializer.Deserialize<ActionRow>(root.GetRawText(), options)!,
            ComponentType.Button => JsonSerializer.Deserialize<Button>(root.GetRawText(), options)!,
            ComponentType.StringSelect => JsonSerializer.Deserialize<StringSelect>(root.GetRawText(), options)!,
            ComponentType.TextInput => JsonSerializer.Deserialize<TextInput>(root.GetRawText(), options)!,
            ComponentType.UserSelect => JsonSerializer.Deserialize<UserSelect>(root.GetRawText(), options)!,
            ComponentType.RoleSelect => JsonSerializer.Deserialize<RoleSelect>(root.GetRawText(), options)!,
            ComponentType.MentionableSelect => JsonSerializer.Deserialize<MentionableSelect>(root.GetRawText(), options)!,
            ComponentType.ChannelSelect => JsonSerializer.Deserialize<ChannelSelect>(root.GetRawText(), options)!,
            ComponentType.Section => JsonSerializer.Deserialize<Section>(root.GetRawText(), options)!,
            ComponentType.TextDisplay => JsonSerializer.Deserialize<TextDisplay>(root.GetRawText(), options)!,
            ComponentType.Thumbnail => JsonSerializer.Deserialize<Thumbnail>(root.GetRawText(), options)!,
            ComponentType.MediaGallery => JsonSerializer.Deserialize<MediaGallery>(root.GetRawText(), options)!,
            ComponentType.File => JsonSerializer.Deserialize<FileComponent>(root.GetRawText(), options)!,
            ComponentType.Separator => JsonSerializer.Deserialize<Separator>(root.GetRawText(), options)!,
            ComponentType.Container => JsonSerializer.Deserialize<Container>(root.GetRawText(), options)!,
            ComponentType.Label => JsonSerializer.Deserialize<Label>(root.GetRawText(), options)!,
            _ => throw new JsonException($"Unknown component type: {componentType}")
        };
    }

    public override void Write(Utf8JsonWriter writer, IComponent value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(writer, value, value.GetType(), options);
    }
}