using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Json.Serialization;
using Disconance.Models;

namespace Disconance.Http.Json;

/// <summary>
///     Provides configuration options for JSON serialization and deserialization specific to Discord-related data
///     handling.
/// </summary>
public class DiscordJsonOptions
{
    private static readonly JsonSerializerOptions DefaultSerializerOptions =
        new(JsonSerializerDefaults.General)
        {
            Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
            PropertyNamingPolicy = JsonNamingPolicy.SnakeCaseLower,
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingDefault
        };

    static DiscordJsonOptions()
    {
        var modelsAssembly = typeof(Snowflake).Assembly;

        var converterTypes = modelsAssembly.GetTypes()
            .Where(type => typeof(JsonConverter).IsAssignableFrom(type) && !type.IsAbstract).ToList();

        foreach (var converterType in converterTypes)
        {
            if (Activator.CreateInstance(converterType) is JsonConverter converter)
            {
                DefaultSerializerOptions.Converters.Add(converter);
            }
        }
    }

    /// <summary>
    ///     Gets the <see cref="JsonSerializerOptions" />.
    /// </summary>
    public JsonSerializerOptions SerializerOptions { get; } =
        new(DefaultSerializerOptions); // Use a copy so the defaults are not modified.
}