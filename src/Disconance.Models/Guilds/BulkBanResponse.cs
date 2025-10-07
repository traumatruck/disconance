namespace Disconance.Models.Guilds;

/// <summary>
///     Response for the bulk ban operation.
/// </summary>
public class BulkBanResponse
{
    /// <summary>
    ///     List of user ids that were successfully banned.
    /// </summary>
    public required List<Snowflake> BannedUsers { get; set; }

    /// <summary>
    ///     List of user ids that were not banned.
    /// </summary>
    public required List<Snowflake> FailedUsers { get; set; }
}