using System;
using System.Collections.Generic;

namespace VT.NET.Parameters
{
    /// <summary>
    /// Represents an abstract base class for defining on-to-many relationships in the VirusTotal API.
    /// </summary>
    /// <remarks>
    /// This class serves as the foundation for specific relationship types that can have multiple
    /// associated entities, allowing for flexible modeling of complex relationships in the data.
    /// </remarks>
    public abstract class ManyRelationship
    {
        /// <summary>
        /// Gets the internal collection of relationships as an enumerable of enum types.
        /// </summary>
        internal abstract IEnumerable<Enum> RelationshipsInternal { get; }
    }

    /// <summary>
    /// Represents a generic one-to-many relationship for a specific type of enum in the VirusTotal API.
    /// </summary>
    /// <typeparam name="T">The type of the enum that defines the relationships.</typeparam>
    /// <remarks>
    /// This class allows for the storage and retrieval of multiple relationships for a given type,
    /// making it easier to work with collections of relationships in a type-safe manner.
    /// </remarks>
    public abstract class ManyRelationship<T> : ManyRelationship where T : Enum
    {
        /// <summary>
        /// Internal collection of relationships as an enumerable of enum types.
        /// </summary>
        internal override IEnumerable<Enum> RelationshipsInternal
        {
            get
            {
                for (int i = 0; i < Relationships.Count; i++)
                {
                    yield return Relationships[i];
                }
            }
        }

        /// <summary>
        /// List of relationships associated with this instance.
        /// </summary>
        /// <remarks>
        /// The Relationships property holds multiple values of type <typeparamref name="T"/>,
        /// allowing the representation of various relationships in a one-to-many context.
        /// </remarks>
        public List<T> Relationships { get; } = new List<T>();
    }
}
