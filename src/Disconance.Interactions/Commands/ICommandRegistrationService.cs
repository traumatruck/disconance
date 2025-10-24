using Disconance.Models;

namespace Disconance.Interactions.Commands;

public interface ICommandRegistrationService
{
    Task RegisterGlobalCommandsAsync(CancellationToken cancellationToken = default);
    
    Task RegisterGuildCommandsAsync(Snowflake guildId, CancellationToken cancellationToken = default);
}