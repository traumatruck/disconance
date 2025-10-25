using Disconance.Models.Interactions;

namespace Disconance.Interactions.Commands;

public interface ICommandBehavior
{
    public string CommandName { get; }

    Task<InteractionResponse> ExecuteAsync(Interaction interaction, ApplicationCommandData applicationCommandData,
        CancellationToken cancellationToken = default);
}