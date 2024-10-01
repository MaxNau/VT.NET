using System.Text.Json.Serialization;
using VT.NET.Responses.Files;

namespace VT.NET.Responses.Domains.Report
{
    /// <summary>
    /// Represents a report for a domain retrieved from the VirusTotal API.
    /// This class contains the ID, type, links, and attributes associated with the domain report.
    /// </summary>
    public class DomainReport
    {
        internal DomainReport() { }

        [JsonConstructor]
        internal DomainReport(DomainAttributes attributes, string id, Links links, string type)
        {
            Attributes = attributes;
            Id = id;
            Links = links;
            Type = type;
        }

        /// <summary>
        /// Attributes related to the domain.
        /// </summary>
        public DomainAttributes Attributes { get; }

        /// <summary>
        /// Unique identifier for the domain report.
        /// </summary>
        public string Id { get; }

        /// <summary>
        /// Links associated with the domain report.
        /// </summary>
        public Links Links { get; }

        /// <summary>
        /// Type of the object, which is "domain".
        /// </summary>
        public string Type { get; }
    }
}
