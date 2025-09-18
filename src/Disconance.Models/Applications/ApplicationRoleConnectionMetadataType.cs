namespace Disconance.Models.Applications;

/// <summary>
///     The type of role connection metadata.
/// </summary>
public enum ApplicationRoleConnectionMetadataType
{
    /// <summary>
    ///     The metadata value (integer) is less than or equal to the guild's configured value (integer).
    /// </summary>
    IntegerLessThanOrEqual = 1,

    /// <summary>
    ///     The metadata value (integer) is greater than or equal to the guild's configured value (integer).
    /// </summary>
    IntegerGreaterThanOrEqual = 2,

    /// <summary>
    ///     The metadata value (integer) is equal to the guild's configured value (integer).
    /// </summary>
    IntegerEqual = 3,

    /// <summary>
    ///     The metadata value (integer) is not equal to the guild's configured value (integer).
    /// </summary>
    IntegerNotEqual = 4,

    /// <summary>
    ///     The metadata value (date) is less than or equal to the guild's configured value (date).
    /// </summary>
    DatetimeLessThanOrEqual = 5,

    /// <summary>
    ///     The metadata value (date) is greater than or equal to the guild's configured value (date).
    /// </summary>
    DatetimeGreaterThanOrEqual = 6,

    /// <summary>
    ///     The metadata value (integer) is equal to the guild's configured value (integer).
    /// </summary>
    BooleanEqual = 7,

    /// <summary>
    ///     The metadata value (integer) is not equal to the guild's configured value (integer).
    /// </summary>
    BooleanNotEqual = 8
}