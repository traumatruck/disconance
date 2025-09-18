using System.Text.Json;
using System.Text.Json.Serialization;
using Disconance.Models.Components;

namespace Disconance.Models.JsonConverters;

/// <summary>
///     Custom JSON converter for collections of IComponent.
/// </summary>
public class ComponentCollectionJsonConverter : JsonConverter<IEnumerable<IComponent>>
{
    public override IEnumerable<IComponent> Read(ref Utf8JsonReader reader, Type typeToConvert,
        JsonSerializerOptions options)
    {
        using var doc = JsonDocument.ParseValue(ref reader);
        var root = doc.RootElement;

        if (root.ValueKind != JsonValueKind.Array)
        {
            throw new JsonException("Expected an array of components.");
        }

        return root.EnumerateArray().Select(element => element.GetRawText())
            .Select(componentJson => JsonSerializer.Deserialize<IComponent>(componentJson, options))
            .OfType<IComponent>().ToList();
    }

    public override void Write(Utf8JsonWriter writer, IEnumerable<IComponent> value, JsonSerializerOptions options)
    {
        writer.WriteStartArray();
        foreach (var component in value)
        {
            JsonSerializer.Serialize(writer, component, component.GetType(), options);
        }

        writer.WriteEndArray();
    }
}