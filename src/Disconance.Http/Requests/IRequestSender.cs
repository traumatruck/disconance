using Disconance.Http.Models;

namespace Disconance.Http.Requests;

/// <summary>
///     Defines a contract for sending requests and receiving typed responses.
/// </summary>
public interface IRequestSender
{
    Task<ApiResponse<TResponse>> SendAsync<TResponse>(IRequest<TResponse> request,
        CancellationToken cancellationToken = default);
}