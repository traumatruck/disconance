using Disconance.Http.Models;

namespace Disconance.Http.Requests;

/// <summary>
///     A service responsible for sending requests and retrieving typed responses.
///     Acts as a central point for request handling by delegating to the appropriate request handlers.
/// </summary>
public class RequestSender(IServiceProvider serviceProvider) : IRequestSender
{
    public async Task<ApiResponse<TResponse>> SendAsync<TResponse>(IRequest<TResponse> request,
        CancellationToken cancellationToken = default)
    {
        var requestType = request.GetType();
        var responseType = typeof(TResponse);
        var handlerType = typeof(IRequestHandler<,>).MakeGenericType(requestType, responseType);

        var handler = serviceProvider.GetService(handlerType)
                      ?? throw new InvalidOperationException($"No handler registered for {requestType.Name}");

        var method = handlerType.GetMethod(nameof(IRequestHandler<,>.HandleAsync))
                     ?? throw new InvalidOperationException("HandleAsync method not found on handler");

        return await (Task<ApiResponse<TResponse>>) method.Invoke(handler, [request, cancellationToken])!;
    }
}