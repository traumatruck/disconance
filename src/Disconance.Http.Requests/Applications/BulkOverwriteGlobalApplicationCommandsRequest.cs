using Disconance.Models;
using Disconance.Models.Interactions;

namespace Disconance.Http.Requests.Applications;

/// <summary>
///     Takes a list of application commands, overwriting the existing global command list for this application.
///     Returns a list of application command objects. Commands that do not exist or are not valid will be ignored.
///     This will overwrite all types of application commands: slash commands, user commands, and message commands.
/// </summary>
/// <param name="ApplicationId"></param>
public record BulkOverwriteGlobalApplicationCommandsRequest(Snowflake ApplicationId)
    : IRequest<List<ApplicationCommand>>
{
    /// <summary>
    ///     The commands to overwrite.
    /// </summary>
    //TODO Response body should be array
    public required List<ApplicationCommand> Commands { get; init; }

    public HttpMethod Method => HttpMethod.Put;

    public string Path => $"applications/{ApplicationId}/commands";
}