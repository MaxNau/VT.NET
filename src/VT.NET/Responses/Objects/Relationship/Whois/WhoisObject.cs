using System.Text.Json.Serialization;

namespace VT.NET.Responses.Objects.Relationship.Whois
{
    /// <summary>
    /// Domain and IP addresses whois object.
    /// </summary>
    public class WhoisObject : VTObject
    {
        internal WhoisObject() { }

        [JsonConstructor]
        internal WhoisObject(string id, string type, Links links, WhoisObjectAttributes attributes)
            : base(id, type, links)
        {
            Attributes = attributes;
        }

        /// <summary>
        /// Whois object attributes
        /// </summary>
        public WhoisObjectAttributes Attributes { get; }
    }
}
