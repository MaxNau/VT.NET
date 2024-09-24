using System;
using System.Text.Json.Serialization;

namespace VT.NET.Responses.Files
{
    public class Links
    {
        internal Links() { }

        [JsonConstructor]
        internal Links(Uri self)
        {
            Self = self;
        }
        public Uri Self { get; }
    }
}
