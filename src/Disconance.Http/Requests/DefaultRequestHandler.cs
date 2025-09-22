using System.Collections;
using System.Collections.Immutable;
using System.Net.Http.Json;
using System.Reflection;
using System.Text;
using System.Text.Json;
using Disconance.Http.Json;
using Disconance.Http.Models;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Disconance.Http.Requests;

/// <summary>
///     Responsible for handling HTTP requests to the Discord API and processing responses into a structured format.
/// </summary>
/// <typeparam name="TResource">
///     The type of the resource request, which must implement <see cref="IRequest{TResponse}" />.
/// </typeparam>
/// <typeparam name="TResponse">
///     The type of the expected response from the API.
/// </typeparam>
public class DefaultRequestHandler<TResource, TResponse>(
    IHttpClientFactory httpClientFactory,
    IOptions<DiscordJsonOptions> jsonOptions,
    ILogger<DefaultRequestHandler<TResource, TResponse>> logger
) : IRequestHandler<TResource, TResponse> where TResource : IRequest<TResponse>
{
    private readonly HttpClient _httpClient = httpClientFactory.CreateClient("HttpApi");

    /// <summary>
    ///     Handles the given request and processes it asynchronously.
    /// </summary>
    /// <param name="resource">The request resource.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>Returns an <see cref="ApiResponse{TResponse}" /> containing the response data and status code.</returns>
    public async Task<ApiResponse<TResponse>> HandleAsync(TResource resource, CancellationToken cancellationToken)
    {
        HttpRequestMessage httpRequest;

        if (resource.Method == HttpMethod.Get)
        {
            var queryParams = GetQueryParameters(resource);
            var uri = resource.Path;

            if (queryParams.Count != 0)
            {
                var queryString = string.Join("&",
                    queryParams.Select(kvp => $"{kvp.Key}={Uri.EscapeDataString(kvp.Value)}"));

                uri = $"{resource.Path}?{queryString}";
            }

            httpRequest = new HttpRequestMessage(resource.Method, uri);
        }
        else
        {
            httpRequest = new HttpRequestMessage(resource.Method, resource.Path);

            // Serialize the request body for non-GET methods
            var bodyToSerialize = GetRequestBody(resource);
            var json = JsonSerializer.Serialize(bodyToSerialize, jsonOptions.Value.SerializerOptions);
            httpRequest.Content = new StringContent(json, Encoding.UTF8, "application/json");
        }

        var response = await _httpClient.SendAsync(httpRequest, cancellationToken);

        if (!response.IsSuccessStatusCode)
        {
            var errorContent = await response.Content.ReadAsStringAsync(cancellationToken);

            logger.LogError("Request to {Path} failed with {StatusCode}: {Error}", resource.Path, response.StatusCode,
                errorContent);
        }

        response.EnsureSuccessStatusCode();

        TResponse? result = default;

        if (response.Content.Headers.ContentLength > 0)
        {
            result = await response.Content.ReadFromJsonAsync<TResponse>(jsonOptions.Value.SerializerOptions,
                cancellationToken);
        }

        return new ApiResponse<TResponse>
        {
            Data = result,
            StatusCode = response.StatusCode
        };
    }

    private static object GetRequestBody(TResource resource)
    {
        var properties = typeof(TResource).GetProperties(BindingFlags.Public | BindingFlags.Instance);

        var collectionProperties = properties
            .Where(p => typeof(IEnumerable).IsAssignableFrom(p.PropertyType) && p.PropertyType != typeof(string))
            .ToImmutableArray();

        if (collectionProperties.Length != 1)
        {
            return resource;
        }

        var value = collectionProperties.First().GetValue(resource);
        
        // Return the body as an array if the property is an array
        // Otherwise, the entire object should be serialized
        return value ?? resource;
    }

    private static Dictionary<string, string> GetQueryParameters(TResource resource)
    {
        var properties =
            typeof(TResource).GetProperties(BindingFlags.Public | BindingFlags.Instance);

        var queryParams = new Dictionary<string, string>();

        foreach (var prop in properties)
        {
            var value = prop.GetValue(resource);

            if (value != null)
            {
                queryParams[prop.Name] = value.ToString() ?? string.Empty;
            }
        }

        return queryParams;
    }
}