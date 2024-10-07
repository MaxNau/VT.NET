using System;
using System.Text.Json.Serialization;

namespace VT.NET.Responses
{
    /// <summary>
    /// Represents the links associated with a VirusTotal API response.
    /// </summary>
    /// <remarks>
    /// The <see cref="Links"/> class contains URIs that provide access to related resources
    /// in the VirusTotal API.
    /// </remarks>
    public class Links
    {
        internal Links() { }

        [JsonConstructor]
        internal Links(Uri self)
        {
            Self = self;
        }

        /// <summary>
        /// The URI that points to the resource itself.
        /// </summary>
        public Uri Self { get; }
    }
}
