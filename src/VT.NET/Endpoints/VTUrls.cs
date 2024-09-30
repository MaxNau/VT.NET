using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using VT.NET.Responses;
using VT.NET.Responses.Analysis;
using VT.NET.Responses.Urls.Report;
using VT.NET.Utility;

namespace VT.NET.Endpoints
{
    /// <summary>
    /// Represents the VirusTotal URLs API endpoint, providing methods to scan URLs, retrieve reports, and rescan URLs.
    /// </summary>
    public class VTUrls : VTEndpoint, IVTUrls
    {
        private readonly IVTUrlIdentifierGenerator _vtUrlIdentifierGenerator;

        /// <summary>
        /// Initializes a new instance of the <see cref="VTUrls"/> class.
        /// </summary>
        /// <param name="httpClient">The <see cref="HttpClient"/> used to make HTTP requests.</param>
        /// <param name="apiKey">The API key for authenticating requests to the VirusTotal API.</param>
        public VTUrls(HttpClient httpClient, string apiKey) : base(httpClient, apiKey)
        {
            _vtUrlIdentifierGenerator = new VTUrlIdentifierGenerator();
        }

        /// <summary>
        /// Scans the specified URL for threats.
        /// </summary>
        /// <param name="url">The URL to be scanned. Must not be null.</param>
        /// <param name="cancellationToken">A token to cancel the operation, if needed.</param>
        /// <returns>A task representing the asynchronous operation, containing the analysis result.</returns>
        /// <exception cref="ArgumentNullException">Thrown when the <paramref name="url"/> is null.</exception>
        public async Task<VTAnalysis> ScanAsync(Uri url, CancellationToken cancellationToken = default)
        {
            if (url == null)
            {
                throw new ArgumentNullException(nameof(url));
            }

            using (var content = new FormUrlEncodedContent(new Dictionary<string, string>
            {
                { "url", "https://docs.virustotal.com/reference/scan-url" },
            }))
            {
                var result = await Self.PostAsync<VTResponse<VTAnalysis>>("urls", content, cancellationToken);
                return result.Data;
            }
        }

        /// <summary>
        /// Retrieves the report for the specified URL.
        /// </summary>
        /// <param name="url">The URL for which to retrieve the report. Must not be null.</param>
        /// <param name="cancellationToken">A token to cancel the operation, if needed.</param>
        /// <returns>A task representing the asynchronous operation, containing the URL report.</returns>
        /// <exception cref="ArgumentNullException">Thrown when the <paramref name="url"/> is null.</exception>
        public async Task<UrlReport> GetReportAsync(Uri url, CancellationToken cancellationToken = default)
        {
            if (url == null)
            {
                throw new ArgumentNullException(nameof(url));
            }

            var base64EncodedUrl = _vtUrlIdentifierGenerator.EncodeUrlToBase64(url);
            var result = await Self.GetAsync<VTResponse<UrlReport>>($"urls/{base64EncodedUrl}", cancellationToken);
            return result.Data;
        }

        /// <summary>
        /// Retrieves the report for a given URL identifier or Base64 representation.
        /// </summary>
        /// <param name="id">The URL identifier or Base64 representation of the URL (without padding).</param>
        /// <param name="cancellationToken">A token to cancel the operation, if needed.</param>
        /// <returns>A task representing the asynchronous operation, containing the URL report.</returns>
        public async Task<UrlReport> GetReportAsync(string id, CancellationToken cancellationToken = default)
        {
            var result = await Self.GetAsync<VTResponse<UrlReport>>($"urls/{id}", cancellationToken);
            return result.Data;
        }

        /// <summary>
        /// Rescans the specified URL for threats.
        /// </summary>
        /// <param name="url">The URL to be rescanned. Must not be null.</param>
        /// <param name="cancellationToken">A token to cancel the operation, if needed.</param>
        /// <returns>A task representing the asynchronous operation, containing the analysis result.</returns>
        /// <exception cref="ArgumentNullException">Thrown when the <paramref name="url"/> is null.</exception>
        public async Task<VTAnalysis> RescanAsync(Uri url, CancellationToken cancellationToken = default)
        {
            if (url == null)
            {
                throw new ArgumentNullException(nameof(url));
            }

            var base64EncodedUrl = _vtUrlIdentifierGenerator.EncodeUrlToBase64(url);
            var result = await Self.GetAsync<VTResponse<VTAnalysis>>($"urls/{base64EncodedUrl}/analyse", cancellationToken);
            return result.Data;
        }


        /// <summary>
        /// Rescans a given URL identifier or Base64 representation.
        /// </summary>
        /// <param name="id">The URL identifier or Base64 representation of the URL (without padding).</param>
        /// <param name="cancellationToken">A token to cancel the operation, if needed.</param>
        /// <returns>A task representing the asynchronous operation, containing the analysis result.</returns>
        public async Task<VTAnalysis> RescanAsync(string id, CancellationToken cancellationToken = default)
        {
            var result = await Self.GetAsync<VTResponse<VTAnalysis>>($"urls/{id}/analyse", cancellationToken);
            return result.Data;
        }
    }
}
