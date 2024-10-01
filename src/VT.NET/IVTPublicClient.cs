using VT.NET.Endpoints;

namespace VT.NET
{
    /// <summary>
    /// Defines interface for interacting with the VirusTotal public APIs.
    /// This interface provides access to various VirusTotal public APIs - files, URLs, IP addresses etc.
    /// </summary>
    public interface IVTPublicClient
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
        /// Client for interacting with VirusTotal domains API.
        /// </summary>
        IVTDomains Domains { get; }
    }
}
