using Disconance.Models.Interactions;

namespace Disconance.Interactions.Processors.Results;

public sealed record UnauthorizedInteractionRequestProcessorResult : IInteractionRequestProcessorResult
{
    public InteractionResponse? InteractionResponse => null;

    public bool IsSuccess => false;

    public required string? ErrorMessage { get; init; }
}