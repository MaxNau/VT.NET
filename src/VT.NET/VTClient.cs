using System.Net.Http;
using VT.NET.Endpoints.AllInOne;
using VT.NET.Endpoints.IocReputationAndEnrichment;

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
            IocReputationAndEnrichmentClient = new IocReputationAndEnrichmentClient(httpClient, apiKey);
        }

        /// <summary>
        /// IOC REPUTATION and ENRICHMENT client
        /// </summary>
        public IIocReputationAndEnrichmentClient IocReputationAndEnrichmentClient { get; }
    }
}
