using System.Text.Json;
using System.Text.Json.Serialization;

namespace Disconance.Models.JsonConverters;

/// <summary>
///     Provides a custom JSON converter for the <see cref="Snowflake" /> type. The converter allows serialization and
///     deserialization of Snowflake values in JSON.
/// </summary>
public class SnowflakeJsonConverter : JsonConverter<Snowflake>
{
    public override Snowflake Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        // ReSharper disable once SwitchExpressionHandlesSomeKnownEnumValuesWithExceptionInDefault
        return reader.TokenType switch
        {
            JsonTokenType.String => new Snowflake(reader.GetString()!),
            JsonTokenType.Number => new Snowflake(reader.GetUInt64()),

            _ => throw new JsonException($"Cannot convert {reader.TokenType} to Snowflake")
        };
    }

    public override void Write(Utf8JsonWriter writer, Snowflake value, JsonSerializerOptions options)
    {
        writer.WriteStringValue(value.Value.ToString());
    }
}