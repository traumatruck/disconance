using Disconance.Interactions.Processors.Results;

namespace Disconance.Interactions.Processors;

/// <summary>
///     Defines a contract for processing interaction requests in the system.
/// </summary>
public interface IInteractionRequestProcessor
{
    /// <summary>
    ///     Processes an interaction request asynchronously.
    /// </summary>
    /// <param name="requestData">The raw request data to process.</param>
    /// <returns>
    ///     A task that represents the asynchronous operation. The task result contains an implementation of
    ///     <see cref="IInteractionRequestProcessorResult" /> indicating the success status and any issues encountered.
    /// </returns>
    Task<IInteractionRequestProcessorResult> ProcessInteractionRequestAsync(string requestData);
}