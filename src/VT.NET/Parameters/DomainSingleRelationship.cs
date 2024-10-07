using VT.NET.Enums.Relationship;

namespace VT.NET.Parameters
{
    /// <summary>
    /// Represents a single relationship specifically for domain-related entities.
    /// </summary>
    public class DomainSingleRelationship : SingleRelationship<DomainRelationship>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DomainSingleRelationship"/> class.
        /// </summary>
        /// <param name="relationship">The <see cref="DomainRelationship"/> that defines the relationship.</param>
        public DomainSingleRelationship(DomainRelationship relationship)
        {
            Relationship = relationship;
        }
    }
}
