using System.Text.Json.Serialization;
using VT.NET.Responses.Files;

namespace VT.NET.Responses.IPs.Report
{
    /// <summary>
    /// Represents a report for the IP address returned by the VirusTotal API.
    /// This class contains the ID, type, links, and attributes associated with the IP address report.
    /// </summary>
    public class IPReport
    {
        internal IPReport() { }

        [JsonConstructor]
        internal IPReport(IPAttributes attributes, string id, Links links, string type)
        {
            Attributes = attributes;
            Id = id;
            Links = links;
            Type = type;
        }

        /// <summary>
        /// Attributes of the IP address report.
        /// </summary>
        public IPAttributes Attributes { get; }

        /// <summary>
        /// Unique identifier for the IP address.
        /// </summary>
        public string Id { get; }

        /// <summary>
        /// Links related to the IP address report.
        /// </summary>
        public Links Links { get; }

        /// <summary>
        /// Type of the data, which is expected to be "ip_address".
        /// </summary>
        public string Type { get; }
    }
}
