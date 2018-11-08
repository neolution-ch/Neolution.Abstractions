namespace Neolution.Abstractions.Http
{
    using System.Net.Http;

    /// <summary>
    /// HttpClient factory
    /// </summary>
    public interface IHttpClientAccessor
    {
        /// <summary>
        /// Gets the reused HTTP client.
        /// </summary>
        /// <value>
        /// The reused HTTP client.
        /// </value>
        HttpClient HttpClient { get; }

        /// <summary>
        /// Creates a new HTTP client instance.
        /// </summary>
        /// <returns>A new (non-reused) HTTP client.</returns>
        HttpClient CreateHttpClient();

        /// <summary>
        /// Creates a new HTTP client instance and instantiates it with the specified message handler.
        /// </summary>
        /// <param name="handler">The HTTP message handler.</param>
        /// <returns>A new (non-reused) HTTP client.</returns>
        HttpClient CreateHttpClient(HttpMessageHandler handler);
    }
}
