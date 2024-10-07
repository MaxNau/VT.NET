using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace VT.NET.Responses.Objects
{
    /// <summary>
    /// Represents a VirusTotal object that contains attributes and relationships to other objects.
    /// This class is generic and can hold various types of attributes based on the specified type parameter <typeparamref name="T"/>.
    /// </summary>
    /// <typeparam name="T">The type of the attributes associated with the VirusTotal object.</typeparam>
    public class VTObjectWithRelationships<T> : VTObject
    {
        internal VTObjectWithRelationships() { }

        [JsonConstructor]
        internal VTObjectWithRelationships(string id, string type, Links links, T attributes,
            Dictionary<string, ObjectRelationships> relationships)
            : base(id, type, links)
        {
            Attributes = attributes;
            Relationships = relationships;
        }

        /// <summary>
        /// Gets the attributes associated with the VirusTotal object.
        /// </summary>
        public T Attributes { get; }

        /// <summary>
        /// Gets a dictionary of relationships to other objects.
        /// The key is the name of the relationship, and the value is the <see cref="ObjectRelationships"/> associated with that relationship.
        /// </summary>
        public Dictionary<string, ObjectRelationships> Relationships { get; }
    }
}
