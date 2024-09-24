using System;
using System.Text.Json.Serialization;

namespace VT.NET.Responses
{
    public class MetaLinks
    {
        internal MetaLinks() { }

        [JsonConstructor]
        internal MetaLinks(Uri self, Uri next)
        {
            Self = self;
            Next = next;
        }

        public Uri Self { get; }
        public Uri Next { get; }
    }
}
