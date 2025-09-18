using System.Text.Json;
using System.Text.Json.Serialization;

namespace Disconance.Models.JsonConverters;

/// <summary>
///     A custom JSON converter for handling nullable Snowflake objects during serialization and deserialization. This
///     converter provides support for converting valid JSON tokens (e.g., strings, numbers, or null values) to and from
///     the Snowflake? type.
/// </summary>
public class NullableSnowflakeJsonConverter : JsonConverter<Snowflake?>
{
    public override Snowflake? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        if (reader.TokenType == JsonTokenType.Null)
        {
            return null;
        }

        return reader.TokenType switch
        {
            JsonTokenType.String => new Snowflake(reader.GetString()!),
            JsonTokenType.Number => new Snowflake(reader.GetUInt64()),
            _ => throw new JsonException($"Cannot convert {reader.TokenType} to Snowflake")
        };
    }

    public override void Write(Utf8JsonWriter writer, Snowflake? value, JsonSerializerOptions options)
    {
        if (value.HasValue)
        {
            writer.WriteStringValue(value.Value.Value.ToString());
        }
        else
        {
            writer.WriteNullValue();
        }
    }
}