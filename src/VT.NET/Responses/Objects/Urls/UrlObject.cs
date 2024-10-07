using System.Text.Json.Serialization;

namespace VT.NET.Responses.Objects.Urls
{
    /// <summary>
    /// Represents a report for a URL returned by the VirusTotal API.
    /// This class contains the ID, type, links, and attributes associated with the URL report.
    /// </summary>
    public class UrlObject : VTObject
    {
        internal UrlObject() { }

        [JsonConstructor]
        internal UrlObject(string id, string type, Links links, UrlObjectAttributes attributes)
            : base(id, type, links)
        {
            Attributes = attributes;
        }

        /// <summary>
        /// Attributes of the URL report.
        /// This property contains various metadata and analysis results related to the URL.
        /// </summary>
        public UrlObjectAttributes Attributes { get; }
    }
}
