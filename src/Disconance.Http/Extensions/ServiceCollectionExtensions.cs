using Disconance.Core.Configuration;
using Disconance.Http.Requests;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace Disconance.Http.Extensions;

internal static class ServiceCollectionExtensions
{
    private const string ApiUrl = "https://discord.com/api";
    private const int ApiVersion = 10;
    private const string UserAgentUrl = "https://github.com/blazed-pixel-labs/disconance";

    /// <summary>
    ///     Registers services required for sending HTTP requests to the Discord API and configures an HTTP client with
    ///     required headers and base address.
    /// </summary>
    /// <param name="serviceCollection">The service collection to which the services are added.</param>
    /// <returns>The updated service collection with the added services.</returns>
    internal static IServiceCollection AddHttp(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddSingleton<IRequestSender, RequestSender>();
        serviceCollection.AddTransient(typeof(IRequestHandler<,>), typeof(DefaultRequestHandler<,>));

        serviceCollection.AddHttpClient("HttpApi", (serviceProvider, client) =>
        {
            // Set base address
            var versionedApiUrl = $"{ApiUrl}/v{ApiVersion}/";
            var baseAddress = new Uri(versionedApiUrl);
            client.BaseAddress = baseAddress;

            // Set user agent
            const string userAgent = $"DiscordBot ({UserAgentUrl}, 1.0.0-alpha)";
            client.DefaultRequestHeaders.Add("User-Agent", userAgent);

            // Add authentication token
            var discordApplicationOptions =
                serviceProvider.GetRequiredService<IOptions<DisconanceOptions>>();

            var botToken = discordApplicationOptions.Value.BotToken;
            client.DefaultRequestHeaders.Add("Authorization", $"Bot {botToken}");

            //TODO OAuth support
        });

        return serviceCollection;
    }
}