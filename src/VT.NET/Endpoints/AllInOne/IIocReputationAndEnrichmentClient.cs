using VT.NET.Endpoints.IocReputationAndEnrichment;

namespace VT.NET.Endpoints.AllInOne
{
    /// <summary>
    /// Defines interface for interacting with the VirusTotal IOC REPUTATION and ENRICHMENT API,
    /// providing access to various services related to files, URLs, IP addresses etc.
    /// </summary>
    public interface IIocReputationAndEnrichmentClient
    {
        /// <summary>
        /// Client for interacting with VirusTotal files API.
        /// </summary>
        IVTFiles Files { get; }

        /// <summary>
        /// Client for interacting with VirusTotal URLs API.
        /// </summary>
        IVTUrls Urls { get; }

        /// <summary>
        /// Client for interacting with VirusTotal IP addresses API.
        /// </summary>
        IVTIPs IPs { get; }

        /// <summary>
        /// Client for interacting with VirusTotal Domains API.
        /// </summary>
        IVTDomains Domains { get; }

        /// <summary>
        /// Client for interacting with VirusTotal Comments API.
        /// </summary>
        IVTComments Comments { get; }

        /// <summary>
        /// Client for interacting with VirusTotal Votes API.
        /// </summary>
        IVTVotes Votes { get; }

        /// <summary>
        /// Client for interacting with VirusTotal Objects API.
        /// </summary>
        IVTObjects Objects { get; }
    }
}
