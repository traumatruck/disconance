using Disconance.Models.Interactions;

namespace Disconance.Interactions.Processors.Results;

/// <summary>
///     Represents a result indicating the failure of processing an interaction request in the system. This class
///     implements the <see cref="IInteractionRequestProcessorResult" /> interface and provides specific information about
///     the failure, such as an error message.
/// </summary>
public class FailedInteractionRequestProcessorResult : IInteractionRequestProcessorResult
{
    /// <inheritdoc />
    public InteractionResponse? InteractionResponse => null;

    /// <inheritdoc />
    public bool IsSuccess => false;

    /// <inheritdoc />
    public required string? ErrorMessage { get; init; }
}