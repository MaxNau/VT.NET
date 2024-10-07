using VT.NET.Enums.Relationship;

namespace VT.NET.Parameters
{
    /// <summary>
    /// Represents a single relationship specifically for ip-related entities.
    /// </summary>
    public class IpAddressSingleRelationship : SingleRelationship<IpAddressRelationship>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="IpAddressSingleRelationship"/> class.
        /// </summary>
        /// <param name="relationship">The <see cref="IpAddressRelationship"/> that defines the relationship.</param>
        public IpAddressSingleRelationship(IpAddressRelationship relationship)
        {
            Relationship = relationship;
        }
    }
}
