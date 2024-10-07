using VT.NET.Enums.Relationship;

namespace VT.NET.Parameters
{
    /// <summary>
    /// Represents a single relationship specifically for utl-related entities.
    /// </summary>
    public class UrlSingleRelationship : SingleRelationship<UrlRelationship>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UrlSingleRelationship"/> class.
        /// </summary>
        /// <param name="relationship">The <see cref="UrlRelationship"/> that defines the relationship.</param>
        public UrlSingleRelationship(UrlRelationship relationship)
        {
            Relationship = relationship;
        }
    }
}
