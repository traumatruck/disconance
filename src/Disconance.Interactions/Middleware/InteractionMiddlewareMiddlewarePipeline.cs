using System.Collections.Immutable;
using Disconance.Models.Interactions;

namespace Disconance.Interactions.Middleware;

/// <summary>
///     Default implementation of the interaction middleware pipeline. Chains middlewares in the order they are registered.
/// </summary>
public sealed class InteractionMiddlewareMiddlewarePipeline(IEnumerable<IInteractionMiddleware> middlewares)
    : IInteractionMiddlewarePipeline
{
    private readonly ImmutableArray<IInteractionMiddleware> _middlewares = [..middlewares];

    public Task<InteractionResponse> InvokeAsync(InteractionReceivedContext context,
        Func<Task<InteractionResponse>> next)
    {
        // Build the middleware chain by wrapping the next delegate
        var pipeline = next;

        // Iterate in reverse to wrap from the outside in
        foreach (var middleware in _middlewares.Reverse())
        {
            var capturedNext = pipeline;
            pipeline = () => middleware.InvokeAsync(context, capturedNext);
        }

        return pipeline();
    }
}