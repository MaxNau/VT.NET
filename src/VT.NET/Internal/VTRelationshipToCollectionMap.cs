using System;
using VT.NET.Parameters;

namespace VT.NET.Internal
{
    internal class VTRelationshipToCollectionMap
    {
        public string Get(ManyRelationship relationship)
        {
            if (relationship is DomainManyRelationship)
            {
                return "domains";
            }
            else if (relationship is FileManyRelationship)
            {
                return "files";
            }
            else if (relationship is IpAddressManyRelationship)
            {
                return "ip_addresses";
            }
            else if (relationship is UrlManyRelationship)
            {
                return "urls";
            }
            else
            {
                throw new NotSupportedException($"Relationship {relationship} is not supported");
            }
        }

        public string Get(SingleRelationship relationship)
        {
            if (relationship is DomainSingleRelationship)
            {
                return "domains";
            }
            else if (relationship is FileSingleRelationship)
            {
                return "files";
            }
            else if (relationship is IpAddressSingleRelationship)
            {
                return "ip_addresses";
            }
            else if (relationship is UrlSingleRelationship)
            {
                return "urls";
            }
            else
            {
                throw new NotSupportedException($"Relationship {relationship} is not supported");
            }
        }
    }
}
