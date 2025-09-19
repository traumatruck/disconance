using Disconance.Models.Interactions;

namespace Disconance.Interactions.Processors.Results;

/// <summary>
///     Represents the result of processing an interaction request in the system.
/// </summary>
public interface IInteractionRequestProcessorResult
{
    /// <summary>
    ///     Represents the response to an interaction request.
    /// </summary>
    InteractionResponse? InteractionResponse { get; }

    /// <summary>
    ///     Indicates whether the interaction request was processed successfully.
    /// </summary>
    bool IsSuccess { get; }

    /// <summary>
    ///     Gets an optional error message describing the reason for a failed interaction request processing.
    /// </summary>
    string? ErrorMessage { get; }
}