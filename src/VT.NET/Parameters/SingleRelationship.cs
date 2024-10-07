using System;

namespace VT.NET.Parameters
{
    /// <summary>
    /// Represents an abstract base class for defining single relationships in the VirusTotal API.
    /// </summary>
    /// <remarks>
    /// This class serves as the foundation for specific relationship types that can have a single
    /// associated entity, enabling clear modeling of relationships in the data.
    /// </remarks>
    public abstract class SingleRelationship
    {
        /// <summary>
        /// Internal representation of the relationship as an enum type.
        /// </summary>
        internal abstract Enum RelationshipInternal { get; }
    }

    /// <summary>
    /// Represents a generic single relationship for a specific type of enum in the VirusTotal API.
    /// </summary>
    /// <typeparam name="T">The type of the enum that defines the relationship.</typeparam>
    /// <remarks>
    /// This class allows for the storage and retrieval of a single relationship for a given type,
    /// making it easier to work with relationships in a type-safe manner.
    /// </remarks>
    public abstract class SingleRelationship<T> : SingleRelationship where T : Enum
    {
        /// <summary>
        /// Internal representation of the relationship as an enum type.
        /// </summary>
        internal override Enum RelationshipInternal
        {
            get
            {
                return Relationship;
            }
        }

        /// <summary>
        /// Relationship associated with this instance.
        /// </summary>
        /// <remarks>
        /// The Relationship property holds a single value of type <typeparamref name="T"/>,
        /// representing the specific relationship in a one-to-one context.
        /// </remarks>
        public T Relationship { get; protected set; }
    }
}
