using Disconance.Http.Models;

namespace Disconance.Http.Requests;

/// <summary>
///     Defines a mechanism for handling HTTP requests and generating responses.
/// </summary>
/// <typeparam name="TRequest">The type of the request object, which must implement <see cref="IRequest{TResponse}" />.</typeparam>
/// <typeparam name="TResponse">The type of the response object.</typeparam>
public interface IRequestHandler<in TRequest, TResponse> where TRequest : IRequest<TResponse>
{
    Task<ApiResponse<TResponse>> HandleAsync(TRequest request, CancellationToken cancellationToken);
}