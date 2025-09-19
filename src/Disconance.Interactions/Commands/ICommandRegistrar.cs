using Disconance.Models;

namespace Disconance.Interactions.Commands;

/// <summary>
///     Provides functionality for registering interactions commands.
/// </summary>
public interface ICommandRegistrar
{
    /// <summary>
    ///     Registers commands, optionally for a specific guild.
    /// </summary>
    /// <param name="guildId">The optional guild ID to register commands for. If null, registers global commands.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    Task RegisterCommandsAsync(Snowflake? guildId = null, CancellationToken cancellationToken = default);
}