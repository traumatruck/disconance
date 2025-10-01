using Disconance.Models.Interactions;

namespace Disconance.Interactions.Commands;

/// <inheritdoc />
public class ModalSubmitHandler(ICommandRepository commandRepository) : IModalSubmitHandler
{
    /// <inheritdoc />
    public async Task<InteractionResponse> HandleAsync(Interaction interaction,
        CancellationToken cancellationToken = default)
    {
        //TODO We should register IModalForm objects in the container and then pull them like we do in the command processor.
        // This would decouple modal behavior from commands 
        var modalForm = commandRepository.GetAllCommands().Where(command => command is IModalForm).Cast<IModalForm>()
            .FirstOrDefault(modalForm => modalForm.ModalId == (interaction.Data as ModalSubmitData)?.CustomId);

        if (modalForm == null)
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

        return await modalForm.OnModalSubmitAsync(interaction, cancellationToken);
    }
}