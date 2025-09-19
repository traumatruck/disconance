using Disconance.Models.Components;
using Disconance.Models.Interactions;

namespace Disconance.Interactions.Commands;

/// <inheritdoc />
public class CommandProcessor(ICommandRepository commandRepository) : ICommandProcessor
{
    private readonly Dictionary<string, ISimpleCommand> _simpleCommandMap =
        commandRepository.GetSimpleCommands().ToDictionary(c => c.Name);

    private readonly Dictionary<string, IBaseCommand> _baseCommandMap =
        commandRepository.GetBaseCommands().ToDictionary(c => c.Name);

    /// <inheritdoc />
    public async Task<InteractionResponse> ProcessCommandAsync(Interaction interaction)
    {
        if (interaction.Data is not ApplicationCommandData applicationCommandData)
        {
            //TODO Logging

            return new InteractionResponse
            {
                Type = InteractionCallbackType.ChannelMessageWithSource,
                Data = new InteractionMessageCallbackData
                {
                    Components = [new TextDisplay { Content = "An unexpected error occurred." }]
                }
            };
        }

        var isSimpleCommand = !applicationCommandData.Options?.Any() ?? true;

        if (isSimpleCommand)
        {
            ICommandBehavior simpleCommandBehavior = _simpleCommandMap[applicationCommandData.Name];
            return await simpleCommandBehavior.ExecuteAsync(interaction);
        }

        var baseCommand = _baseCommandMap[applicationCommandData.Name];
        var options = applicationCommandData.Options ?? [];

        foreach (var option in options)
        {
            var subcommand = 
                baseCommand.Subcommands.FirstOrDefault(subcommand => subcommand.Name == option.Name);

            if (subcommand is not ICommandBehavior subcommandBehavior)
            {
                continue;
            }
            
            return await subcommandBehavior.ExecuteAsync(interaction);
        }
        // TODO The 900 other situations that can happen
        //
        // if (_commandMap.TryGetValue(commandData.Name, out var command))
        // {
        //     if (command is ICommandBehavior behavior)
        //     {
        //         // Check if this is a subcommand
        //         if (commandData.Options?.FirstOrDefault() is { } firstOption)
        //         {
        //             if (firstOption.Type == ApplicationCommandOptionType.SubCommandGroup)
        //             {
        //                 // Handle subcommand group
        //                 var subcommandGroupName = firstOption.Name;
        //                 var subcommandOption = firstOption.Options?.FirstOrDefault();
        //                 if (subcommandOption?.Type == ApplicationCommandOptionType.SubCommand)
        //                 {
        //                     var subcommandName = subcommandOption.Name;
        //                     // For now, handle test command subcommands
        //                     if (commandData.Name == "test" && subcommandGroupName == "user")
        //                     {
        //                         if (subcommandName == "info")
        //                         {
        //                             return new InteractionResponse
        //                             {
        //                                 Type = InteractionCallbackType.ChannelMessageWithSource,
        //                                 Data = new InteractionMessageCallbackData
        //                                 {
        //                                     Components = [new TextDisplay { Content = "User info command executed!" }]
        //                                 }
        //                             };
        //                         }
        //
        //                         if (subcommandName == "ban")
        //                         {
        //                             return new InteractionResponse
        //                             {
        //                                 Type = InteractionCallbackType.ChannelMessageWithSource,
        //                                 Data = new InteractionMessageCallbackData
        //                                 {
        //                                     Components = [new TextDisplay { Content = "User ban command executed!" }]
        //                                 }
        //                             };
        //                         }
        //                     }
        //                 }
        //             }
        //             else if (firstOption.Type == ApplicationCommandOptionType.SubCommand)
        //             {
        //                 // Handle direct subcommand
        //                 var subcommandName = firstOption.Name;
        //                 if (commandData.Name == "test" && subcommandName == "server")
        //                 {
        //                     return new InteractionResponse
        //                     {
        //                         Type = InteractionCallbackType.ChannelMessageWithSource,
        //                         Data = new InteractionMessageCallbackData
        //                         {
        //                             Components = [new TextDisplay { Content = "Server info command executed!" }]
        //                         }
        //                     };
        //                 }
        //             }
        //         }
        //         else
        //         {
        //             // Simple command
        //             return await behavior.ExecuteAsync(interaction);
        //         }
        //     }
        // }
        //
        // return new InteractionResponse
        // {
        //     Type = InteractionCallbackType.ChannelMessageWithSource,
        //     Data = new InteractionMessageCallbackData
        //     {
        //         Components = [new TextDisplay { Content = "Error" }]
        //     }
        // };

        throw new NotImplementedException();
    }
}