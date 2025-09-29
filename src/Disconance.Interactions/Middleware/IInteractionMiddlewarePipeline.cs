using Disconance.Models.Interactions;

namespace Disconance.Interactions.Middleware;

/// <summary>
///     Pipeline for executing interaction middleware.
/// </summary>
public interface IInteractionMiddlewarePipeline
{
    /// <summary>
    ///     Executes the middleware pipeline with the given context and final response builder.
    /// </summary>
    /// <param name="context">The interaction context.</param>
    /// <param name="next">The final delegate that builds the interaction response.</param>
    /// <returns>The interaction response.</returns>
    Task<InteractionResponse> InvokeAsync(InteractionReceivedContext context, Func<Task<InteractionResponse>> next);
}