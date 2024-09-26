using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace VT.NET.Responses
{
    /// <summary>
    /// Represents a paginated response from the VirusTotal API.
    /// </summary>
    /// <typeparam name="T">The type of the items in the response data.</typeparam>
    /// <remarks>
    /// The <see cref="VTPagedResponse{T}"/> class encapsulates the data returned by the API, along with
    /// metadata and links for navigating through pages of results.
    /// </remarks>
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

        /// <summary>
        /// A list of items included in the paginated response.
        /// </summary>
        public List<T> Data { get; }

        /// <summary>
        /// Metadata providing information about the response, such as item count and pagination cursor.
        /// </summary>
        public Meta Meta { get; }

        /// <summary>
        /// Links for navigating to additional pages of results, including self and next links.
        /// </summary>
        public MetaLinks Links { get; }
    }
}
