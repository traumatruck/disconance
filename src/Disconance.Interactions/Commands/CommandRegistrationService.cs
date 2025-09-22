using Disconance.Interactions.Attributes;
using Disconance.Models;
using Microsoft.Extensions.Logging;

namespace Disconance.Interactions.Commands;

public class CommandRegistrationService(
    ICommandRegistrar commandRegistrar,
    ILogger<CommandRegistrationService> logger
    ) : ICommandRegistrationService
{
    public async Task RegisterAllCommandsAsync(CancellationToken cancellationToken = default)
    {
        logger.LogInformation("Starting command registration");

        var commandAssemblies = CommandAssemblyAttribute.GetCommandAssemblies();

        foreach (var commandAssembly in commandAssemblies)
        {
            var commandAttributes = commandAssembly.CustomAttributes.Where(attribute =>
                attribute.AttributeType == typeof(CommandAssemblyAttribute));

            foreach (var attribute in commandAttributes)
            {
                var guildId =
                    attribute.NamedArguments
                        .SingleOrDefault(argument => argument.MemberName == nameof(CommandAssemblyAttribute.GuildId))
                        .TypedValue.Value as ulong?;

                logger.LogDebug("Registering commands for assembly {AssemblyName} with guild ID {GuildId}",
                    commandAssembly.FullName, guildId);

                await commandRegistrar.RegisterCommandsAsync(commandAssembly, guildId, cancellationToken);
            }
        }

        logger.LogInformation("Command registration completed");
    }
}