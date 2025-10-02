using Disconance.Models.Interactions;

namespace Disconance.Interactions.Processors.Results;

/// <summary>
///     Represents the result of a successful interaction request processing.
/// </summary>
public sealed class SuccessfulInteractionRequestProcessorResult : IInteractionRequestProcessorResult
{
    /// <summary>
    ///     Represents the serialized form of an <see cref="InteractionResponse" /> associated with a successful interaction
    ///     request processing. This property contains the string representation of the interaction response, which can be used
    ///     for storage or transmission.
    /// </summary>
    public required string SerializedInteractionResponse { get; init; }

    /// <inheritdoc />
    public required InteractionResponse InteractionResponse { get; init; }

    /// <inheritdoc />
    public bool IsSuccess => true;

    /// <inheritdoc />
    public string? ErrorMessage => null;
}