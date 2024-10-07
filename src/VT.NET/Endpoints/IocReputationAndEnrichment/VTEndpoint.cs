using System;
using System.Net;
using System.Net.Http;
using System.Text;
using VT.NET.Constants;
using VT.NET.Http;

namespace VT.NET.Endpoints.IocReputationAndEnrichment
{
    /// <summary>
    /// Represents a client endpoint for interacting with the VirusTotal API.
    /// </summary>
    /// <remarks>
    /// This class extends the <see cref="RestClient"/> to provide a specific configuration
    /// for the VirusTotal API, setting the base address used for API requests.
    /// </remarks>
    public class VTEndpoint : RestClient
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="VTEndpoint"/> class.
        /// </summary>
        /// <param name="httpClient">An <see cref="HttpClient"/> instance used for making HTTP requests.</param>
        /// <param name="apiKey">VirusTotal API key</param>
        public VTEndpoint(HttpClient httpClient, string apiKey) : base(httpClient)
        {
            SetVirusTotalAddress();
            AddDefaultRequestHeader(VTHeaderNames.ApiKey, apiKey);
        }

        /// <summary>
        /// Sets the base address for the VirusTotal API.
        /// </summary>
        /// <remarks>
        /// The base address is set to "https://www.virustotal.com/api/v3/". If the current 
        /// base address is null or does not match the expected VirusTotal API address, 
        /// it updates the base address accordingly.
        /// </remarks>
        private void SetVirusTotalAddress()
        {
            if (BaseAddress == null
                || BaseAddress.OriginalString != "https://www.virustotal.com/api/v3/"
                || BaseAddress.OriginalString != "https://www.virustotal.com/api/v3")
            {
                BaseAddress = new Uri("https://www.virustotal.com/api/v3/");
            }
        }

        /// <summary>
        /// Builds a query string for API requests based on the provided parameters.
        /// </summary>
        /// <param name="limit">The maximum number of results to return. Must be greater than zero.</param>
        /// <param name="filter">An optional filter to apply to the results.</param>
        /// <param name="cursor">An optional cursor for pagination.</param>
        /// <param name="anotherQuery">An optional additional query string to include.</param>
        /// <returns>A query string formatted for use in an API request. Returns an empty string if no parameters are provided.</returns>
        protected string BuildQuery(int limit, string filter = null, string cursor = null, string anotherQuery = null)
        {
            var queryBuilder = new StringBuilder();

            if (!string.IsNullOrEmpty(anotherQuery))
            {
                queryBuilder.Append(anotherQuery);
            }

            if (limit > 0)
            {
                AppendParameter(queryBuilder, limit, "limit");
            }

            AppendParameter(queryBuilder, cursor, "cursor");
            AppendParameter(queryBuilder, filter, "filter");

            return queryBuilder.Length > 0 ?
                queryBuilder[0] != '?' ? "?" + queryBuilder.ToString() : queryBuilder.ToString()
                : string.Empty;
        }

        private void AppendParameter(StringBuilder queryBuilder, object value, string paramName)
        {
            string stringValue = value?.ToString();
            if (!string.IsNullOrWhiteSpace(stringValue))
            {
                if (queryBuilder.Length > 0)
                {
                    queryBuilder.Append("&");
                }
                queryBuilder.Append($"{paramName}={WebUtility.UrlEncode(stringValue)}");
            }
        }
    }
}
