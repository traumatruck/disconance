using Disconance.Interactions.Processors.Results;
using Microsoft.AspNetCore.Http;

namespace Disconance.Interactions.Processors;

/// <summary>
///     Defines a contract for processing interaction requests in the system.
/// </summary>
public interface IInteractionRequestProcessor
{
    /// <summary>
    ///     Processes an interaction request asynchronously.
    /// </summary>
    /// <param name="interactionRequest">The interaction request to process.</param>
    /// <returns>
    ///     A task that represents the asynchronous operation. The task result contains an implementation of
    ///     <see cref="IInteractionRequestProcessorResult" /> indicating the success status and any issues encountered.
    /// </returns>
    Task<IInteractionRequestProcessorResult> ProcessInteractionRequestAsync(HttpRequest interactionRequest);
}