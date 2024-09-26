using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using VT.NET.Exceptions;

namespace VT.NET.Http
{
    /// <summary>
    /// Represents a REST client for making HTTP requests to an API.
    /// </summary>
    /// <remarks>
    /// The <see cref="RestClient"/> class provides methods to perform GET and POST requests,
    /// along with handling common response patterns such as deserialization and error handling.
    /// </remarks>
    public class RestClient : IRestClient
    {
        private readonly HttpClient _httpClient;
        private readonly JsonSerializerOptions _jsonSerializerOptions = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };

        /// <summary>
        /// Initializes a new instance of the <see cref="RestClient"/> class with the specified <see cref="HttpClient"/>.
        /// </summary>
        /// <param name="httpClient">The <see cref="HttpClient"/> to be used for making requests.</param>
        public RestClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
            FixBaseAddress(_httpClient);
        }

        /// <summary>
        /// BaseAddress
        /// </summary>
        protected Uri BaseAddress
        {
            get { return _httpClient.BaseAddress; }
            set { _httpClient.BaseAddress = value; }
        }

        internal IRestClient Self => this;

        async Task<T> IRestClient.GetAsync<T>(string requestUri, CancellationToken cancellationToken)
        {
            var response = await _httpClient.GetAsync(requestUri).ConfigureAwait(false);
            return await GetResponseContentAsync<T>(response).ConfigureAwait(false);
        }

        async Task<T> IRestClient.PostAsync<T>(string requestUri, HttpContent content, CancellationToken cancellationToken)
        {
            var response = await _httpClient.PostAsync(requestUri, content, cancellationToken).ConfigureAwait(false);
            return await GetResponseContentAsync<T>(response).ConfigureAwait(false);
        }

        /// <summary>
        /// Adds a default request header to the <see cref="_httpClient"/>.
        /// </summary>
        /// <param name="headerName">The name of the header to add.</param>
        /// <param name="headerValue">The value of the header to add.</param>
        /// <exception cref="ArgumentNullException">Thrown if the header name or value is null or empty.</exception>
        protected void AddDefaultRequestHeader(string headerName, string headerValue)
        {
            if (string.IsNullOrWhiteSpace(headerName))
            {
                throw new ArgumentNullException(nameof(headerName));
            }

            if (string.IsNullOrWhiteSpace(headerValue))
            {
                throw new ArgumentNullException(headerValue);
            }

            bool headerExists = _httpClient.DefaultRequestHeaders.Contains(headerName);

            if (string.IsNullOrEmpty(headerValue))
            {
                if (!headerExists)
                {
                    throw new ArgumentNullException(nameof(headerValue), $"Header {headerName} value is required and was not provided.");
                }
            }
            else if (!headerExists)
            {
                _httpClient.DefaultRequestHeaders.Add(headerName, headerValue);
            }
        }

        private async Task<T> GetResponseContentAsync<T>(HttpResponseMessage httpResponseMessage)
        {
            var contentAsString = await httpResponseMessage.Content.ReadAsStringAsync().ConfigureAwait(false);

            if (!httpResponseMessage.IsSuccessStatusCode)
            {
                throw new ApiException((int)httpResponseMessage.StatusCode,
                    $"API request failed: {httpResponseMessage.ReasonPhrase}",
                    contentAsString);
            }

            return JsonSerializer.Deserialize<T>(contentAsString, _jsonSerializerOptions);
        }

        private void FixBaseAddress(HttpClient httpClient)
        {
            if (!httpClient.BaseAddress.OriginalString.EndsWith("/"))
            {
                httpClient.BaseAddress = new Uri(httpClient.BaseAddress.OriginalString + "/");
            }
        }
    }
}
