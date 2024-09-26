using System;
using System.Text.Json.Serialization;

namespace VT.NET.Responses
{
    /// <summary>
    /// Represents the links related to metadata in a VirusTotal API response.
    /// </summary>
    /// <remarks>
    /// The <see cref="MetaLinks"/> class contains URIs that provide access to the current resource 
    /// and the next resource in a paginated response.
    /// </remarks>
    public class MetaLinks
    {
        internal MetaLinks() { }

        [JsonConstructor]
        internal MetaLinks(Uri self, Uri next)
        {
            Self = self;
            Next = next;
        }

        /// <summary>
        /// The URI that points to the current resource.
        /// </summary>
        public Uri Self { get; }

        /// <summary>
        /// The URI that points to the next resource in the pagination.
        /// </summary>
        public Uri Next { get; }
    }
}
