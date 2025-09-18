using Disconance.Models;
using Disconance.Models.Interactions;

namespace Disconance.Http.Requests.Applications;

/// <summary>
///     Create a new guild command. New guild commands will be available in the guild immediately. Returns 201 if a command
///     with the same name does not already exist, or 200 if it does (in which case the previous command will be
///     overwritten). Both responses include an application command object. Creating a command with the same name as an
///     existing command will overwrite the old command.
/// </summary>
/// <param name="ApplicationId"></param>
/// <param name="GuildId"></param>s
public record CreateGuildApplicationCommandRequest(Snowflake ApplicationId, Snowflake GuildId)
    : IRequest<ApplicationCommand>
{
    /// <summary>
    ///     Name of command, 1-32 characters.
    /// </summary>
    public required string Name { get; init; }

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
    ///     Type of command, defaults 1 if not set.
    /// </summary>
    public ApplicationCommandType? Type { get; set; }

    /// <summary>
    ///     Indicates whether the command is age-restricted.
    /// </summary>
    public bool? Nsfw { get; set; }

    public HttpMethod Method => HttpMethod.Post;

    public string Path => $"applications/{ApplicationId}/guilds/{GuildId}/commands";
}