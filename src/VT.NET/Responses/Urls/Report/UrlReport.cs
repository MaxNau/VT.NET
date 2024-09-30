using VT.NET.Responses.Files;

namespace VT.NET.Responses.Urls.Report
{
    /// <summary>
    /// Represents a report for a URL returned by the VirusTotal API.
    /// This class contains the ID, type, links, and attributes associated with the URL report.
    /// </summary>
    public class UrlReport
    {
        /// <summary>
        /// Gets or sets the unique identifier for the URL report.
        /// This ID corresponds to the SHA256 hash of the URL.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets the type of the resource. For URL reports, this will typically be "url".
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// Gets or sets the links associated with the URL report.
        /// This property contains various links relevant to the URL, such as self-referencing links.
        /// </summary>
        public Links Links { get; set; }

        /// <summary>
        /// Gets or sets the attributes of the URL report.
        /// This property contains various metadata and analysis results related to the URL.
        /// </summary>
        public UrlAttributes Attributes { get; set; }
    }
}
