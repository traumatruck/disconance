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

        throw new NotImplementedException();
    }
}