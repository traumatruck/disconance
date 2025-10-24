using Disconance.Models;
using Disconance.Models.Interactions;

namespace Disconance.Http.Requests.Applications;

/// <summary>
///     Fetch all of the guild commands for your application for a specific guild. Returns an array of application command
///     objects. The objects returned by this endpoint may be augmented with additional fields if localization is active.
/// </summary>
/// <param name="applicationId"></param>
/// <param name="guildId"></param>
public class GetGuildApplicationCommandsRequest(Snowflake applicationId, Snowflake guildId)
    : IRequest<IEnumerable<ApplicationCommand>>
{
    /// <summary>
    ///     Whether to include full localization dictionaries (name_localizations and description_localizations) in the
    ///     returned objects, instead of the name_localized and description_localized fields. Default false.
    /// </summary>
    public bool? WithLocalizations { get; set; }

    public HttpMethod Method => HttpMethod.Get;

    public string Path => $"applications/{applicationId}/guilds/{guildId}/commands";
}