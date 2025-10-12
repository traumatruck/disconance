using Disconance.Http.Extensions;
using Disconance.Interactions.Middleware;
using Disconance.Interactions.Processors;
using Disconance.Interactions.Security;
using Microsoft.Extensions.DependencyInjection;

namespace Disconance.Interactions.Extensions;

public static class ServiceCollectionExtensions
{
    /// <summary>
    ///     Adds the Disconance interaction services to the specified IServiceCollection. Calls AddDisconanceHttp() internally,
    ///     separate registration is not required.
    /// </summary>
    /// <param name="serviceCollection">The instance of IServiceCollection used for dependency injection.</param>
    /// <returns>The updated IServiceCollection to support chaining of method calls.</returns>
    public static IServiceCollection AddInteractions(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddScoped<IInteractionSecurityHandler, NSecInteractionSecurityHandler>();
        serviceCollection.AddScoped<IInteractionRequestProcessor, InteractionRequestProcessor>();
        serviceCollection.AddScoped<IInteractionMiddlewarePipeline, InteractionMiddlewareMiddlewarePipeline>();

        return serviceCollection.AddDisconanceHttp();
    }
}