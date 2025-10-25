using Disconance.Models.Interactions;

namespace Disconance.Interactions.Commands;

public interface IModalForm
{
    string Name { get; }

    Task<InteractionResponse> ExecuteAsync(Interaction interaction, ModalSubmitData modalSubmitData,
        CancellationToken cancellationToken = default);
}