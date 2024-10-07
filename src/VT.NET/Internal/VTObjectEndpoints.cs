using System;
using System.Collections.Generic;

namespace VT.NET.Internal
{
    internal class VTObjectEndpoints
    {
        private readonly Dictionary<VTObjectType, string> _endpoints = new Dictionary<VTObjectType, string>()
        {
            { VTObjectType.File, "files" },
            { VTObjectType.Url, "urls" },
            { VTObjectType.Domain, "domains" },
            { VTObjectType.IP, "ip_addresses" }
        };

        public string Get(VTObjectType objectType)
        {
            return _endpoints.TryGetValue(objectType, out var endpoint) ?
                endpoint : throw new ArgumentOutOfRangeException(objectType.ToString());
        }
    }
}
