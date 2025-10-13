using Disconance.Core.Configuration;
using Disconance.Http.Requests;
using Disconance.Http.Requests.Applications;
using Disconance.Models;
using Disconance.Models.Interactions;
using Microsoft.Extensions.Options;

namespace Disconance.Interactions.Commands;

public class CommandRegistrationService(
    IEnumerable<ICommand> commands,
    IOptions<DisconanceOptions> disconanceOptions,
    IRequestSender requestSender,
    IServiceProvider serviceProvider) : ICommandRegistrationService
{
    public async Task RegisterGlobalCommandsAsync(CancellationToken cancellationToken = default)
    {
        var applicationCommands = GetApplicationCommands().ToList();

        if (applicationCommands.Count > 0)
        {
            var applicationId = disconanceOptions.Value.ApplicationId;

            await requestSender.SendAsync(
                new BulkOverwriteGlobalApplicationCommandsRequest(applicationId)
                {
                    Commands = applicationCommands
                }, cancellationToken);
        }
    }

    public async Task RegisterGuildCommandsAsync(Snowflake guildId, CancellationToken cancellationToken = default)
    {
        var applicationCommands = GetApplicationCommands().ToList();

        if (applicationCommands.Count > 0)
        {
            var applicationId = disconanceOptions.Value.ApplicationId;

            await requestSender.SendAsync(
                new BulkOverwriteGuildApplicationCommandsRequest(applicationId, guildId)
                {
                    Commands = applicationCommands
                }, cancellationToken);
        }
    }

    private ApplicationCommand ConvertToApplicationCommand(ICommand command)
    {
        var applicationCommand = new ApplicationCommand
        {
            Name = command.Name,
            Description = command.Description
        };

        if (command is Command commandImpl)
        {
            commandImpl.ConfigureAsync(applicationCommand, serviceProvider);
        }

        return applicationCommand;
    }

    private IEnumerable<ApplicationCommand> GetApplicationCommands()
    {
        return commands.Select(ConvertToApplicationCommand);
    }
}