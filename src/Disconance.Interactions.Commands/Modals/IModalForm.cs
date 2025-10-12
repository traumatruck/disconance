using Disconance.Models.Interactions;

namespace Disconance.Interactions.Commands.Modals;

public interface IModalForm
{
    string Name { get; }

    Task<InteractionResponse> ExecuteAsync(Interaction interaction, CancellationToken cancellationToken = default);
}