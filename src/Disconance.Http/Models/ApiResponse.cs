using System.Net;

namespace Disconance.Http.Models;

/// <summary>
///     Represents a generic API response containing data and an HTTP status code.
/// </summary>
/// <typeparam name="T">The type of the response data included in the API response.</typeparam>
public record ApiResponse<T>
{
    /// <summary>
    ///     Gets the data payload associated with the API response. This represents the content returned by the HTTP request.
    /// </summary>
    /// <remarks>
    ///     The value of this property may be <c>null</c> if the response content is empty or not deserialized successfully.
    ///     The type of the data corresponds to the generic parameter <typeparamref name="T" /> specified in the
    ///     <see cref="ApiResponse{T}" /> class.
    /// </remarks>
    public T? Data { get; init; }

    /// <summary>
    ///     Gets the HTTP status code associated with the API response. Represents the outcome of the HTTP request as defined
    ///     in the <see cref="HttpStatusCode" /> enumeration.
    /// </summary>
    /// <remarks>
    ///     The value of this property indicates the HTTP response status, such as <c>200</c> for success, <c>404</c> for not
    ///     found, or other codes. This can be used to determine whether the request was successful or resulted in an error.
    /// </remarks>
    public HttpStatusCode StatusCode { get; init; }
}