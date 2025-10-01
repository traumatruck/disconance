namespace Disconance.Interactions.Commands;

public interface ICommandRegistrationService
{
    Task RegisterAllCommandsAsync(CancellationToken cancellationToken = default);
}