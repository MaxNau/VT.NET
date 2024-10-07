using System.Net.Http;
using VT.NET.Endpoints.IocReputationAndEnrichment;

namespace VT.NET.Endpoints.AllInOne
{
    /// <summary>
    /// Represents a all-in-one client for interacting with the VirusTotal IOC REPUTATION and ENRICHMENT API,
    /// providing access to various services related to files, URLs, IP addresses etc.
    /// </summary>
    public class IocReputationAndEnrichmentClient : VTEndpoint, IIocReputationAndEnrichmentClient
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="IocReputationAndEnrichmentClient"/> class.
        /// </summary>
        /// <param name="httpClient">An <see cref="HttpClient"/> instance used for making HTTP requests.</param>
        /// <param name="apiKey">The API key for authenticating requests to the VirusTotal API.</param>
        public IocReputationAndEnrichmentClient(HttpClient httpClient, string apiKey)
            : base(httpClient, apiKey)
        {
            Files = new VTFiles(httpClient, apiKey);
            Urls = new VTUrls(httpClient, apiKey);
            IPs = new VTIPs(httpClient, apiKey);
            Domains = new VTDomains(httpClient, apiKey);
            Comments = new VTComments(httpClient, apiKey);
            Votes = new VTVotes(httpClient, apiKey);
            Objects = new VTObjects(httpClient, apiKey);
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

        /// <summary>
        /// Client for interacting with VirusTotal Comments API.
        /// </summary>
        public IVTComments Comments { get; }

        /// <summary>
        /// Client for interacting with VirusTotal Votes API.
        /// </summary>
        public IVTVotes Votes { get; }

        /// <summary>
        /// Client for interacting with VirusTotal Objects API.
        /// </summary>
        public IVTObjects Objects { get; }
    }
}
