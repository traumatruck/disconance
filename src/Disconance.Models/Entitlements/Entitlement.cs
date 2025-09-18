namespace Disconance.Models.Entitlements;

/// <summary>
///     Represents an entitlement.
///     https://discord.com/developers/docs/monetization/entitlements#entitlement-object
/// </summary>
public class Entitlement
{
    /// <summary>
    ///     ID of the entitlement.
    /// </summary>
    public Snowflake Id { get; set; }

    /// <summary>
    ///     ID of the SKU.
    /// </summary>
    public Snowflake SkuId { get; set; }

    /// <summary>
    ///     ID of the user that is granted access to the entitlement's sku.
    /// </summary>
    public Snowflake UserId { get; set; }

    /// <summary>
    ///     ID of the guild that is granted access to the entitlement's sku.
    /// </summary>
    public Snowflake? GuildId { get; set; }

    /// <summary>
    ///     ID of the parent application.
    /// </summary>
    public Snowflake ApplicationId { get; set; }

    /// <summary>
    ///     Type of entitlement.
    /// </summary>
    public int Type { get; set; }

    /// <summary>
    ///     Whether the entitlement has been consumed.
    /// </summary>
    public bool Deleted { get; set; }

    /// <summary>
    ///     Start date at which the entitlement is valid. Not present when using test entitlements.
    /// </summary>
    public DateTimeOffset? StartsAt { get; set; }

    /// <summary>
    ///     Date at which the entitlement is no longer valid. Not present when using test entitlements.
    /// </summary>
    public DateTimeOffset? EndsAt { get; set; }
}
