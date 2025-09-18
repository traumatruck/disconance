using Disconance.Models;
using Disconance.Models.Interactions;

namespace Disconance.Http.Requests.Applications;

/// <summary>
///     Edit a global command. Updates will be available in all guilds after 1 hour. Returns 200 and an application command
///     object.
/// </summary>
/// <param name="ApplicationId"></param>
/// <param name="CommandId"></param>
public record EditGlobalApplicationCommandRequest(Snowflake ApplicationId, Snowflake CommandId)
    : IRequest<ApplicationCommand>
{
    /// <summary>
    ///     Name of command, 1-32 characters.
    /// </summary>
    public string? Name { get; init; }

    /// <summary>
    ///     Localization dictionary for the name field. Values follow the same restrictions as name.
    /// </summary>
    public Dictionary<string, string>? NameLocalizations { get; set; }

    /// <summary>
    ///     1-100 character description for CHAT_INPUT commands.
    /// </summary>
    public string? Description { get; set; }

    /// <summary>
    ///     Localization dictionary for the description field. Values follow the same restrictions as description.
    /// </summary>
    public Dictionary<string, string>? DescriptionLocalizations { get; set; }

    /// <summary>
    ///     Parameters for the command, max of 25.
    /// </summary>
    public List<ApplicationCommandOption>? Options { get; set; }

    /// <summary>
    ///     Set of permissions represented as a bit set.
    /// </summary>
    public string? DefaultMemberPermissions { get; set; }

    /// <summary>
    ///     Replaced by default_member_permissions and will be deprecated in the future. Indicates whether the command is
    ///     enabled by default when the app is added to a guild. Defaults to true.
    /// </summary>
    public bool? DefaultPermission { get; set; }

    /// <summary>
    ///     Indicates whether the command is age-restricted.
    /// </summary>
    public bool? Nsfw { get; set; }

    /// <summary>
    ///     Installation context(s) where the command is available, only for globally-scoped commands.
    /// </summary>
    public List<ApplicationIntegrationTypes>? IntegrationTypes { get; set; }

    /// <summary>
    ///     Interaction context(s) where the command can be used, only for globally-scoped commands.
    /// </summary>
    public List<InteractionContextType>? Contexts { get; set; }

    public HttpMethod Method => HttpMethod.Patch;

    public string Path => $"applications/{ApplicationId}/commands/{CommandId}";
}