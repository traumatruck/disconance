using Disconance.Models.Interactions;

namespace Disconance.Interactions.Commands.Components;

public interface IMessageComponent
{
    string Name { get; }

    Task<InteractionResponse> ExecuteAsync(Interaction interaction, CancellationToken cancellationToken = default);
}