using VT.NET.Endpoints.AllInOne;

namespace VT.NET
{
    /// <summary>
    /// Defines interface for interacting with the VirusTotal public APIs.
    /// This interface provides access to various VirusTotal public APIs - files, URLs, IP addresses etc.
    /// </summary>
    public interface IVTPublicClient
    {
        /// <summary>
        /// IOC REPUTATION and ENRICHMENT client
        /// </summary>
        IIocReputationAndEnrichmentClient IocReputationAndEnrichmentClient { get; }
    }
}
