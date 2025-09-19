using Disconance.Models.Interactions;

namespace Disconance.Interactions.Commands;

/// <summary>
///     Represents a processor for handling interaction commands asynchronously.
/// </summary>
public interface ICommandProcessor
{
    /// <summary>
    ///     Processes an interaction command asynchronously and returns the appropriate response.
    /// </summary>
    /// <param name="interaction">The interaction object containing details about the command to be processed.</param>
    /// <returns>A task that represents the asynchronous operation, containing the response of type InteractionResponse.</returns>
    Task<InteractionResponse> ProcessCommandAsync(Interaction interaction);
}