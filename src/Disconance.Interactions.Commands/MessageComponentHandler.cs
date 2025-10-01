using Disconance.Models.Interactions;

namespace Disconance.Interactions.Commands;

/// <inheritdoc />
public class MessageComponentHandler(IEnumerable<IMessageComponent> messageComponents) : IMessageComponentHandler
{
    /// <inheritdoc />
    public async Task<InteractionResponse> HandleAsync(Interaction interaction, CancellationToken cancellationToken = default)
    {
        var messageComponent = messageComponents.FirstOrDefault(messageComponent =>
            messageComponent.ComponentId == (interaction.Data as MessageComponentData)?.CustomId);
        
        if (messageComponent == null)
        {
            //TODO Logging
            
            return new InteractionResponse
            {
                Type = InteractionCallbackType.ChannelMessageWithSource,
                Data = new InteractionMessageCallbackData
                {
                    Content = "An unexpected error occurred."
                }
            };
        }

        return await messageComponent.OnMessageComponentInteractionAsync(interaction, cancellationToken);
    }
}