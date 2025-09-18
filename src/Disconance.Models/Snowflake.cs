using System.Text.Json.Serialization;
using Disconance.Models.JsonConverters;

namespace Disconance.Models;

/// <summary>
///     Discord utilizes Twitter's snowflake format for uniquely identifiable descriptors (IDs). These IDs are guaranteed
///     to be unique across all of Discord, except in some unique scenarios in which child objects share their parent's ID.
///     Because Snowflake IDs are up to 64 bits in size (e.g. a uint64), they are always returned as strings in the HTTP
///     API to prevent integer overflows in some languages.
///     https://discord.com/developers/docs/reference#snowflakes
/// </summary>
[JsonConverter(typeof(SnowflakeJsonConverter))]
public readonly struct Snowflake : IEquatable<Snowflake>, IComparable<Snowflake>
{
    private const long DiscordEpoch = 1420070400000L;

    public readonly ulong Value;

    public Snowflake(ulong value)
    {
        Value = value;
    }

    public Snowflake(string value)
    {
        if (!ulong.TryParse(value, out var parsed))
        {
            throw new ArgumentException("Invalid snowflake format", nameof(value));
        }

        Value = parsed;
    }

    /// <summary>
    ///     Extracts the timestamp from the snowflake.
    ///     Milliseconds since Discord Epoch, the first second of 2015 or 1420070400000.
    /// </summary>
    public DateTimeOffset Timestamp =>
        DateTimeOffset.FromUnixTimeMilliseconds((long) (Value >> 22) + DiscordEpoch);

    /// <summary>
    ///     Extracts the worker ID from the snowflake.
    /// </summary>
    public byte WorkerId => (byte) ((Value & 0x3E0000) >> 17);

    /// <summary>
    ///     Extracts the process ID from the snowflake.
    /// </summary>
    public byte ProcessId => (byte) ((Value & 0x1F000) >> 12);

    /// <summary>
    ///     Extracts the increment from the snowflake.
    ///     For every ID that is generated on that process, this number is incremented.
    /// </summary>
    public ushort Increment => (ushort) (Value & 0xFFF);

    public static implicit operator ulong(Snowflake snowflake)
    {
        return snowflake.Value;
    }

    public static implicit operator Snowflake(ulong value)
    {
        return new Snowflake(value);
    }

    public static implicit operator Snowflake(string value)
    {
        return new Snowflake(value);
    }

    public bool Equals(Snowflake other)
    {
        return Value == other.Value;
    }

    public override bool Equals(object? obj)
    {
        return obj is Snowflake other && Equals(other);
    }

    public override int GetHashCode()
    {
        return Value.GetHashCode();
    }

    public int CompareTo(Snowflake other)
    {
        return Value.CompareTo(other.Value);
    }

    public override string ToString()
    {
        return Value.ToString();
    }

    public static bool operator ==(Snowflake left, Snowflake right)
    {
        return left.Equals(right);
    }

    public static bool operator !=(Snowflake left, Snowflake right)
    {
        return !left.Equals(right);
    }

    public static bool operator <(Snowflake left, Snowflake right)
    {
        return left.CompareTo(right) < 0;
    }

    public static bool operator >(Snowflake left, Snowflake right)
    {
        return left.CompareTo(right) > 0;
    }

    public static bool operator <=(Snowflake left, Snowflake right)
    {
        return left.CompareTo(right) <= 0;
    }

    public static bool operator >=(Snowflake left, Snowflake right)
    {
        return left.CompareTo(right) >= 0;
    }
}