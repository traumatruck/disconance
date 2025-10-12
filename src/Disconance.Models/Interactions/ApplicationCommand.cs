namespace Disconance.Models.Interactions;

/// <summary>
///     Represents an application command object.
/// </summary>
public class ApplicationCommand
{
    /// <summary>
    ///     ID of the parent application.
    /// </summary>
    public Snowflake ApplicationId { get; set; }

    /// <summary>
    ///     Interaction context(s) where the command can be used, only for globally-scoped commands.
    /// </summary>
    public List<InteractionContextType>? Contexts { get; set; }

    /// <summary>
    ///     Set of permissions represented as a bit set.
    /// </summary>
    public string? DefaultMemberPermissions { get; set; }

    /// <summary>
    ///     Replaced by default_member_permissions and will be deprecated in the future. Indicates whether the command is
    ///     enabled by default when the app is added to a guild. Defaults to true
    /// </summary>
    public bool? DefaultPermission { get; set; }
    
    /// <inheritdoc />
    public string Description { get; set; } = string.Empty;

    /// <summary>
    ///     Localization dictionary for description field. Values follow the same restrictions as description.
    /// </summary>
    public Dictionary<string, string>? DescriptionLocalizations { get; set; }

    /// <summary>
    ///     Deprecated (use contexts instead); Indicates whether the command is available in DMs with the app, only for
    ///     globally-scoped commands. By default, commands are visible.
    /// </summary>
    public bool? DmPermission { get; set; }

    /// <summary>
    ///     Guild ID of the command, if not global.
    /// </summary>
    public Snowflake? GuildId { get; set; }

    /// <summary>
    ///     Determines whether the interaction is handled by the app's interactions handler or by Discord.
    ///     Only for PRIMARY_ENTRY_POINT.
    /// </summary>
    public EntryPointCommandHandlerType? Handler { get; set; }

    /// <summary>
    ///     Unique ID of command.
    /// </summary>
    public Snowflake Id { get; set; }

    /// <summary>
    ///     Installation contexts where the command is available, only for globally-scoped commands.
    /// </summary>
    public List<ApplicationIntegrationTypes>? IntegrationTypes { get; set; }
    
    /// <inheritdoc />
    public string Name { get; set; } = string.Empty;

    /// <summary>
    ///     Localization dictionary for the name field. Values follow the same restrictions as name.
    /// </summary>
    public Dictionary<string, string>? NameLocalizations { get; set; }

    /// <summary>
    ///     Indicates whether the command is age-restricted, defaults to false.
    /// </summary>
    public bool? Nsfw { get; set; }

    /// <summary>
    ///     Parameters for the command, max of 25. Only for CHAT_INPUT.
    /// </summary>
    public List<ApplicationCommandOption>? Options { get; set; }

    /// <summary>
    ///     Type of command, defaults to 1.
    /// </summary>
    public ApplicationCommandType? Type { get; set; }

    /// <summary>
    ///     Autoincrementing version identifier updated during substantial record changes.
    /// </summary>
    public Snowflake Version { get; set; }
}