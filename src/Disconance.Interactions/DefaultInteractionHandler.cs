using Disconance.Interactions.Commands;
using Disconance.Interactions.Commands.Modals;
using Disconance.Models.Interactions;

namespace Disconance.Interactions;

public class DefaultInteractionHandler(
    IEnumerable<ICommandBehavior> commandBehaviors,
    IEnumerable<IMessageComponent> messageComponents,
    IEnumerable<IModalForm> modals) : IInteractionHandler
{
    public async Task<InteractionResponse> HandleInteractionAsync(Interaction interaction,
        CancellationToken cancellationToken = new())
    {
        switch (interaction)
        {
            case { Type: InteractionType.ApplicationCommand, Data: ApplicationCommandData interactionData }:
            {
                var commandBehavior =
                    commandBehaviors.SingleOrDefault(commandBehavior =>
                        commandBehavior.CommandName == interactionData.Name) ??
                    throw new InvalidOperationException($"No command behavior found for: {interactionData.Name}");

                return await commandBehavior.ExecuteAsync(interaction, cancellationToken);
            }
            case { Type: InteractionType.MessageComponent, Data: MessageComponentData messageComponentData }:
            {
                var customId = messageComponentData.CustomId.Split("|")[0];

                var messageComponent =
                    messageComponents.SingleOrDefault(messageComponent =>
                        messageComponent.Name == customId) ??
                    throw new InvalidOperationException($"No message component found for: {customId}");

                return await messageComponent.ExecuteAsync(interaction, cancellationToken);
            }
            case { Type: InteractionType.ModalSubmit, Data: ModalSubmitData modalSubmitData }:
            {
                var customId = modalSubmitData.CustomId.Split("|")[0];

                var modal =
                    modals.SingleOrDefault(modal => modal.Name == customId) ??
                    throw new InvalidOperationException($"No modal found for: {customId}");

                return await modal.ExecuteAsync(interaction, cancellationToken);
            }
        }

        throw new NotImplementedException();
    }
}