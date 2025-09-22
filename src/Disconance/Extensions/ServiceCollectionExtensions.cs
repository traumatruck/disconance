using Disconance.Core.Configuration;
using Disconance.Http.Extensions;
using Disconance.Interactions.Extensions;
using Microsoft.Extensions.DependencyInjection;

namespace Disconance.Extensions;

public static class ServiceCollectionExtensions
{
    /// <summary>
    ///     Adds the Disconance configuration to the specified <see cref="IServiceCollection" />.
    /// </summary>
    /// <param name="serviceCollection">The collection of service descriptors to add services to.</param>
    /// <returns>The <see cref="IServiceCollection" /> with the Disconance configuration added.</returns>
    public static IServiceCollection AddDisconance(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddOptions<DisconanceOptions>()
            .BindConfiguration(DisconanceOptions.ConfigurationSectionName)
            .ValidateDataAnnotations()
            .ValidateOnStart();

        return serviceCollection.AddInteractions().AddHttp();
    }
}