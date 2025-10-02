using Disconance.Models.Interactions;

namespace Disconance.Interactions;

public interface IInteractionHandler
{
    Task<InteractionResponse> HandleInteractionAsync(Interaction interaction,
        CancellationToken cancellationToken = default);
}