namespace Disconance.Http.Requests;

// ReSharper disable once UnusedTypeParameter
public interface IRequest<out T>
{
    /// <summary>
    ///     Represents the HTTP method (e.g., GET, POST, PUT, DELETE) to be used when sending the HTTP request.
    /// </summary>
    public HttpMethod Method { get; }

    /// <summary>
    ///     Represents the relative URL path associated with the HTTP request. Must not begin with a slash unless you
    ///     are intentionally targeting the base Discord url, if you include a slash the api path and version will not
    ///     be included in the request.
    /// </summary>
    public string Path { get; }
}