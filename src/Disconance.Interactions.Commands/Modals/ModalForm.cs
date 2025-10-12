using Disconance.Models.Interactions;

namespace Disconance.Interactions.Commands.Modals;

public abstract class ModalForm : IModalForm
{
    public abstract Func<Modal, IServiceProvider, Task> ConfigureAsync { get; }

    public abstract string Name { get; }

    public abstract Task<InteractionResponse> ExecuteAsync(Interaction interaction,
        CancellationToken cancellationToken = default);
}