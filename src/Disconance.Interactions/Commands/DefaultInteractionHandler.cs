using Disconance.Models.Interactions;

namespace Disconance.Interactions.Commands;

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

                if (interaction.Data is not ApplicationCommandData interactionInteractionData)
                {
                    throw new InvalidOperationException(
                        "Expected interaction data to be of type ApplicationCommandData.");
                }

                return await commandBehavior.ExecuteAsync(interaction, interactionInteractionData, cancellationToken);
            }
            case { Type: InteractionType.MessageComponent, Data: MessageComponentData messageComponentData }:
            {
                var customId = messageComponentData.CustomId.Split("|")[0];

                var messageComponent =
                    messageComponents.SingleOrDefault(messageComponent =>
                        messageComponent.Name == customId) ??
                    throw new InvalidOperationException($"No message component found for: {customId}");

                if (interaction.Data is not MessageComponentData messageInteractionData)
                {
                    throw new InvalidOperationException(
                        "Expected interaction data to be of type MessageComponentData.");
                }

                return await messageComponent.ExecuteAsync(interaction, messageInteractionData, cancellationToken);
            }
            case { Type: InteractionType.ModalSubmit, Data: ModalSubmitData modalSubmitData }:
            {
                var customId = modalSubmitData.CustomId.Split("|")[0];

                var modal =
                    modals.SingleOrDefault(modal =>
                        modal.Name == customId) ??
                    throw new InvalidOperationException($"No modal found for: {customId}");

                if (interaction.Data is not ModalSubmitData modalInteractionData)
                {
                    throw new InvalidOperationException(
                        "Expected interaction data to be of type ModalSubmitData.");
                }

                return await modal.ExecuteAsync(interaction, modalInteractionData, cancellationToken);
            }
        }

        throw new NotImplementedException();
    }
}