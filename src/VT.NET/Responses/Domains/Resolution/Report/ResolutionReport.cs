using System.Text.Json.Serialization;
using VT.NET.Responses.Files;

namespace VT.NET.Responses.Domains.Resolution.Report
{
    /// <summary>
    /// Represents a resolution object returned by the VirusTotal API.
    /// This class contains the details of a domain resolution, including the date, host name, IP address, and analysis statistics.
    /// </summary>
    public class ResolutionReport
    {
        internal ResolutionReport() { }

        [JsonConstructor]
        internal ResolutionReport(string type, string id, ResolutionAttributes attributes, Links links)
        {
            Type = type;
            Id = id;
            Attributes = attributes;
            Links = links;
        }

        /// <summary>
        /// Type of the object, which is "resolution".
        /// </summary>
        public string Type { get; }

        /// <summary>
        /// Identifier for the resolution object.
        /// </summary>
        public string Id { get; }

        /// <summary>
        /// Attributes associated with the resolution, including date, host name, IP address, and analysis statistics.
        /// </summary>
        public ResolutionAttributes Attributes { get; }

        /// <summary>
        /// Links related to the resolution object.
        /// </summary>
        public Links Links { get; }
    }
}
