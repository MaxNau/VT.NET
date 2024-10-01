using System.Net.Http;
using VT.NET.Endpoints;

namespace VT.NET
{
    /// <summary>
    /// Represents a all-in-one client for interacting with the VirusTotal API, providing access to various services related to files, URLs, IP addresses etc.
    /// </summary>
    public class VTClient : VTEndpoint, IVTPublicClient
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="VTClient"/> class.
        /// </summary>
        /// <param name="httpClient">An <see cref="HttpClient"/> instance used for making HTTP requests.</param>
        /// <param name="apiKey">The API key for authenticating requests to the VirusTotal API.</param>
        public VTClient(HttpClient httpClient, string apiKey) : base(httpClient, apiKey)
        {
            Files = new VTFiles(httpClient, apiKey);
            Urls = new VTUrls(httpClient, apiKey);
            IPs = new VTIPs(httpClient, apiKey);
            Domains = new VTDomains(httpClient, apiKey);
        }

        /// <summary>
        /// Client for interacting with VirusTotal files API.
        /// </summary>
        public IVTFiles Files { get; }

        /// <summary>
        /// Client for interacting with VirusTotal URLs API.
        /// </summary>
        public IVTUrls Urls { get; }

        /// <summary>
        /// Client for interacting with VirusTotal IP addresses API.
        /// </summary>
        public IVTIPs IPs { get; }

        /// <summary>
        /// Client for interacting with VirusTotal Domains API.
        /// </summary>
        public IVTDomains Domains { get; }
    }
}
