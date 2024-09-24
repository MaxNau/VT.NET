using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace VT.NET.Responses
{
    public class VTPagedResponse<T>
    {
        internal VTPagedResponse() { }

        [JsonConstructor]
        internal VTPagedResponse(List<T> data, Meta meta, MetaLinks links)
        {
            Data = data;
            Meta = meta;
            Links = links;
        }

        public List<T> Data { get; }
        public Meta Meta { get; }
        public MetaLinks Links { get; }
    }
}
