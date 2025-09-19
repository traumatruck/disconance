using System.Collections;
using System.Collections.Immutable;
using System.Reflection;
using Disconance.Configuration;
using Disconance.Http.Models;
using Disconance.Http.Requests;
using Disconance.Http.Requests.Applications;
using Disconance.Models;
using Disconance.Models.Interactions;
using Disconance.Models.Permissions;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace Disconance.Interactions.Commands;

/// <inheritdoc />
public class CommandRegistrar(
    IRequestSender requestSender,
    IOptions<DisconanceOptions> disconanceOptions,
    IServiceProvider serviceProvider
) : ICommandRegistrar
{
    /// <inheritdoc />
    public async Task RegisterCommandsAsync(Assembly commandAssembly, Snowflake? guildId = null, CancellationToken cancellationToken = default)
    {
        var applicationId = new Snowflake(disconanceOptions.Value.ApplicationId);
        var simpleCommands = serviceProvider.GetServices<ISimpleCommand>();

        var commands = simpleCommands.Select(simpleCommand => new ApplicationCommand
        {
            Name = simpleCommand.Name,
            Description = simpleCommand.Description,
            Type = ApplicationCommandType.ChatInput,
            //TODO Permissions control
            DefaultMemberPermissions = string.Empty.AddPermission(Permission.Administrator)
        }).ToList();

        // Register complex commands with Discord
        var assemblyTypes = commandAssembly.GetTypes();

        var allCommandsReference = assemblyTypes.Where(type =>
                typeof(ICommand).IsAssignableFrom(type) && type is { IsAbstract: false, IsInterface: false })
            .ToImmutableArray();

        var baseCommandTypes = allCommandsReference.Where(type =>
            type.BaseType?.IsGenericType == true && type.BaseType.GetGenericTypeDefinition() == typeof(BaseCommand<>));

        foreach (var baseCommandType in baseCommandTypes)
        {
            var baseType = baseCommandType.BaseType;

            if (baseType == null)
            {
                continue;
            }

            if (serviceProvider.GetService(baseType) is not ICommand command)
            {
                continue;
            }

            var commandOptions = new List<ApplicationCommandOption>();

            // Get subcommand groups
            var subcommandGroupTypes = allCommandsReference.Where(type =>
                type.BaseType?.IsGenericType == true &&
                type.BaseType.GetGenericTypeDefinition() == typeof(SubcommandGroup<,>));

            foreach (var groupType in subcommandGroupTypes)
            {
                var groupTypeBaseType = groupType.BaseType;

                if (groupTypeBaseType == null)
                {
                    continue;
                }

                if (serviceProvider.GetService(groupTypeBaseType) is not ICommand subcommandGroup)
                {
                    continue;
                }

                var groupOption = new ApplicationCommandOption
                {
                    Type = ApplicationCommandOptionType.SubCommandGroup,
                    Name = subcommandGroup.Name,
                    Description = subcommandGroup.Description,
                    Options = []
                };

                var subcommandsProperty = groupType.GetProperty(nameof(SubcommandGroup<,>.Subcommands));

                if (subcommandsProperty != null)
                {
                    if (subcommandsProperty.GetValue(subcommandGroup) is not IEnumerable subcommands)
                    {
                        continue;
                    }

                    foreach (var subcommand in subcommands)
                    {
                        var subCommand = (ICommand) subcommand;

                        groupOption.Options.Add(new ApplicationCommandOption
                        {
                            Type = ApplicationCommandOptionType.SubCommand,
                            Name = subCommand.Name,
                            Description = subCommand.Description
                        });
                    }
                }

                commandOptions.Add(groupOption);
            }

            var genericParameterType = baseType.GetGenericArguments()[0];
            var subcommandsType = typeof(ISubcommand<>).MakeGenericType(genericParameterType);
            var directSubcommands = serviceProvider.GetServices(subcommandsType);

            var directSubcommandApplicationCommands = 
                from ICommand typedSubcommand in directSubcommands
                select new ApplicationCommandOption
                {
                    Type = ApplicationCommandOptionType.SubCommand,
                    Name = typedSubcommand.Name,
                    Description = typedSubcommand.Description
                };

            commandOptions.AddRange(directSubcommandApplicationCommands);

            commands.Add(new ApplicationCommand
            {
                Name = command.Name,
                Description = command.Description,
                Type = ApplicationCommandType.ChatInput,
                Options = commandOptions.Count != 0 ? commandOptions : null
            });
        }

        ApiResponse<List<ApplicationCommand>> response;

        if (guildId is null)
        {
            var bulkRequest = new BulkOverwriteGlobalApplicationCommandsRequest(applicationId)
            {
                Commands = commands
            };
            
            response = await requestSender.SendAsync(bulkRequest, cancellationToken);
        }
        else
        {
            var bulkRequest = new BulkOverwriteGuildApplicationCommandsRequest(applicationId, guildId.Value)
            {
                Commands = commands
            };
            
            response = await requestSender.SendAsync(bulkRequest, cancellationToken);   
        }

        if ((int) response.StatusCode < 200 || (int) response.StatusCode >= 300)
        {
            throw new InvalidOperationException($"Failed to bulk register commands: HTTP {response.StatusCode}");
        }
    }
}