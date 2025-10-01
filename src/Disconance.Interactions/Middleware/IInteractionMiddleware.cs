using Disconance.Models.Interactions;

namespace Disconance.Interactions.Middleware;

/// <summary>
///     Middleware for processing interactions in a pipeline. Allows logic before and after interaction response
///     construction.
/// </summary>
public interface IInteractionMiddleware
{
    /// <summary>
    ///     Invokes the middleware with the given context and next delegate.
    /// </summary>
    /// <param name="context">The interaction context.</param>
    /// <param name="next">The next middleware in the pipeline, which returns the interaction response.</param>
    /// <returns>The interaction response (should not be modified).</returns>
    Task<InteractionResponse> InvokeAsync(InteractionReceivedContext context, Func<Task<InteractionResponse>> next);
}