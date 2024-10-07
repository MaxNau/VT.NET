using System.Text.Json.Serialization;

namespace VT.NET.Responses.Objects.Domains
{
    /// <summary>
    /// Represents a report for a domain retrieved from the VirusTotal API.
    /// This class contains the ID, type, links, and attributes associated with the domain report.
    /// </summary>
    public class DomainObject : VTObject
    {
        internal DomainObject() { }

        [JsonConstructor]
        internal DomainObject(string id, string type, Links links, DomainObjectAttributes attributes)
            : base(id, type, links)
        {
            Attributes = attributes;
        }

        /// <summary>
        /// Attributes related to the domain.
        /// </summary>
        public DomainObjectAttributes Attributes { get; }
    }
}
