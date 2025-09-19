using Disconance.Models.Interactions;

namespace Disconance.Interactions.Processors.Results;

/// <summary>
///     Represents the result of a successful interaction request processing.
/// </summary>
public sealed class SuccessfulInteractionRequestProcessorResult : IInteractionRequestProcessorResult
{
    /// <inheritdoc />
    public required InteractionResponse InteractionResponse { get; init; }

    /// <inheritdoc />
    public bool IsSuccess => true;

    /// <inheritdoc />
    public string? ErrorMessage => null;
}