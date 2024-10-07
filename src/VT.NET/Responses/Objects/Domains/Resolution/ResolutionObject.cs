using System.Text.Json.Serialization;

namespace VT.NET.Responses.Objects.Domains.Resolution
{
    /// <summary>
    /// Represents a resolution object returned by the VirusTotal API.
    /// This class contains the details of a domain resolution, including the date, host name, IP address, and analysis statistics.
    /// </summary>
    public class ResolutionObject
    {
        internal ResolutionObject() { }

        [JsonConstructor]
        internal ResolutionObject(string type, string id, ResolutionObjectAttributes attributes, Links links)
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
        public ResolutionObjectAttributes Attributes { get; }

        /// <summary>
        /// Links related to the resolution object.
        /// </summary>
        public Links Links { get; }
    }
}
