using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace VT.NET.Responses.Objects
{
    /// <summary>
    /// Represents the relationships of a specific object in the VirusTotal API.
    /// </summary>
    public class ObjectRelationships
    {
        internal ObjectRelationships() { }

        [JsonConstructor]
        internal ObjectRelationships(List<ObjectDescriptor> data, Links links, Meta meta)
        {
            Data = data;
            Links = links;
            Meta = meta;
        }

        /// <summary>
        /// List of related objects.
        /// </summary>
        public List<ObjectDescriptor> Data { get; }

        /// <summary>
        /// Links related to the object relationships.
        /// </summary>
        public Links Links { get; }

        /// <summary>
        /// Metadata
        /// </summary>
        public Meta Meta { get; }
    }
}
