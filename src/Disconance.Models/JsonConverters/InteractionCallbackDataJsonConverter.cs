using System.Text.Json;
using System.Text.Json.Serialization;
using Disconance.Models.Interactions;

namespace Disconance.Models.JsonConverters;

/// <summary>
///     Custom JSON converter for IInteractionCallbackData that handles serialization of different callback data types.
/// </summary>
public class InteractionCallbackDataJsonConverter : JsonConverter<IInteractionCallbackData>
{
    public override IInteractionCallbackData Read(ref Utf8JsonReader reader, Type typeToConvert,
        JsonSerializerOptions options)
    {
        using var doc = JsonDocument.ParseValue(ref reader);
        var root = doc.RootElement;

        if (root.ValueKind == JsonValueKind.Null)
        {
            return null!;
        }

        // Determine the type based on the JSON structure
        if (root.TryGetProperty("choices", out _))
        {
            // Has choices property - InteractionAutocompleteCallbackData
            return JsonSerializer.Deserialize<InteractionAutocompleteCallbackData>(root.GetRawText(), options)!;
        }

        if (root.TryGetProperty("custom_id", out _) && root.TryGetProperty("title", out _))
        {
            // Has custom_id and title - Modal
            return JsonSerializer.Deserialize<Modal>(root.GetRawText(), options)!;
        }

        // Default - InteractionMessageCallbackData
        return JsonSerializer.Deserialize<InteractionMessageCallbackData>(root.GetRawText(), options)!;
    }

    public override void Write(Utf8JsonWriter writer, IInteractionCallbackData value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(writer, value, value.GetType(), options);
    }
}