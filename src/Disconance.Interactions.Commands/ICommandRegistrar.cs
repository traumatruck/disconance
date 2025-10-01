using System.Reflection;
using Disconance.Models;

namespace Disconance.Interactions.Commands;

/// <summary>
///     Provides functionality for registering interactions commands.
/// </summary>
public interface ICommandRegistrar
{
    /// <summary>
    ///     Registers commands from a specific assembly, optionally for a specific guild.
    /// </summary>
    /// <param name="commandAssembly">The assembly that contains the commands to register.</param>
    /// <param name="guildId">The optional guild ID to register commands for. If null, registers global commands.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    Task RegisterCommandsAsync(Assembly commandAssembly, Snowflake? guildId = null,
        CancellationToken cancellationToken = default);
}