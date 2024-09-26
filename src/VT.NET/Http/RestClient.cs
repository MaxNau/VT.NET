using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using VT.NET.Exceptions;

namespace VT.NET.Http
{
    public class RestClient : IRestClient
    {
        private readonly HttpClient _httpClient;
        private readonly JsonSerializerOptions _jsonSerializerOptions = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };

        public RestClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        internal IRestClient Self => this;

        async Task<T> IRestClient.GetAsync<T>(string requestUri, CancellationToken cancellationToken)
        {
            var response = await _httpClient.GetAsync(requestUri);
            return await GetResponseContentAsync<T>(response);
        }

        async Task<T> IRestClient.PostAsync<T>(string requestUri, HttpContent content, CancellationToken cancellationToken)
        {
            var response = await _httpClient.PostAsync(requestUri, content, cancellationToken).ConfigureAwait(false);
            return await GetResponseContentAsync<T>(response).ConfigureAwait(false);
        }

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
    }
}
