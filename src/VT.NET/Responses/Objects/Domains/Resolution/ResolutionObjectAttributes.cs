using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace VT.NET.Responses.Objects.Domains.Resolution
{
    /// <summary>
    /// Represents the attributes of a resolution object.
    /// This class contains information about the date, host name, IP address, and last analysis statistics.
    /// </summary>
    public class ResolutionObjectAttributes
    {
        internal ResolutionObjectAttributes() { }

        [JsonConstructor]
        internal ResolutionObjectAttributes(
            long date, string hostName, Dictionary<string, int> hostNameLastAnalysisStats,
            string ipAddress, Dictionary<string, int> ipAddressLastAnalysisStats, string resolver)
        {
            Date = date;
            HostName = hostName;
            HostNameLastAnalysisStats = hostNameLastAnalysisStats;
            IpAddress = ipAddress;
            IpAddressLastAnalysisStats = ipAddressLastAnalysisStats;
            Resolver = resolver;
        }

        /// <summary>
        /// Date when the resolution was made (UTC timestamp).
        /// </summary>
        public long Date { get; }

        /// <summary>
        /// Domain or subdomain requested to the resolver.
        /// </summary>
        public string HostName { get; }

        /// <summary>
        /// Last detection statistics from the resolution's domain,
        /// similar to the domain's last_analysis_stats attribute.
        /// </summary>
        public Dictionary<string, int> HostNameLastAnalysisStats { get; }

        /// <summary>
        /// IP address the domain was resolved to.
        /// </summary>
        public string IpAddress { get; }

        /// <summary>
        /// Last detection statistics from the resolution's IP address,
        /// similar to the IP address' last_analysis_stats attribute.
        /// </summary>
        public Dictionary<string, int> IpAddressLastAnalysisStats { get; }

        /// <summary>
        /// Source of the resolution.
        /// </summary>
        public string Resolver { get; }
    }
}
