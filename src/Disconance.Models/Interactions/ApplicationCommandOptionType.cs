namespace Disconance.Models.Interactions;

/// <summary>
///     Type of application command option.
/// </summary>
public enum ApplicationCommandOptionType
{
    /// <summary>Sub command</summary>
    SubCommand = 1,

    /// <summary>Sub command group</summary>
    SubCommandGroup = 2,

    /// <summary>String value</summary>
    String = 3,

    /// <summary>Integer value</summary>
    Integer = 4,

    /// <summary>Boolean value</summary>
    Boolean = 5,

    /// <summary>User</summary>
    User = 6,

    /// <summary>Channel</summary>
    Channel = 7,

    /// <summary>Role</summary>
    Role = 8,

    /// <summary>Mentionable (users and roles)</summary>
    Mentionable = 9,

    /// <summary>Number (double)</summary>
    Number = 10,

    /// <summary>Attachment object</summary>
    Attachment = 11
}