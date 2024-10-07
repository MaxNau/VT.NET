using System.Text.Json.Serialization;

namespace VT.NET.Responses.Objects.IPs
{
    /// <summary>
    /// Represents a report for the IP address returned by the VirusTotal API.
    /// This class contains the ID, type, links, and attributes associated with the IP address report.
    /// </summary>
    public class IpAddressObject : VTObject
    {
        internal IpAddressObject() { }

        [JsonConstructor]
        internal IpAddressObject(string id, string type, Links links, IpAddressObjectAttributes attributes)
            : base(id, type, links)
        {
            Attributes = attributes;
        }

        /// <summary>
        /// Attributes of the IP address report.
        /// </summary>
        public IpAddressObjectAttributes Attributes { get; }
    }
}
