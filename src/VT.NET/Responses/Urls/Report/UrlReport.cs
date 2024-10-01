using System.Text.Json.Serialization;
using VT.NET.Responses.Files;

namespace VT.NET.Responses.Urls.Report
{
    /// <summary>
    /// Represents a report for a URL returned by the VirusTotal API.
    /// This class contains the ID, type, links, and attributes associated with the URL report.
    /// </summary>
    public class UrlReport
    {
        internal UrlReport() { }

        [JsonConstructor]
        internal UrlReport(string id, string type, Links links, UrlAttributes attributes)
        {
            Id = id;
            Type = type;
            Links = links;
            Attributes = attributes;
        }

        /// <summary>
        /// Unique identifier for the URL report.
        /// This ID corresponds to the SHA256 hash of the URL.
        /// </summary>
        public string Id { get; }

        /// <summary>
        /// Type of the resource. For URL reports, this will typically be "url".
        /// </summary>
        public string Type { get; }

        /// <summary>
        /// Links associated with the URL report.
        /// This property contains various links relevant to the URL, such as self-referencing links.
        /// </summary>
        public Links Links { get; }

        /// <summary>
        /// Attributes of the URL report.
        /// This property contains various metadata and analysis results related to the URL.
        /// </summary>
        public UrlAttributes Attributes { get; }
    }
}
