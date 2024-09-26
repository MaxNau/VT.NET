using System.Text.Json.Serialization;

namespace VT.NET.Responses
{
    /// <summary>
    /// Represents metadata information related to a VirusTotal API response.
    /// </summary>
    /// <remarks>
    /// The <see cref="Meta"/> class contains details about the number of items returned 
    /// and a cursor for pagination in the API response.
    /// </remarks>
    public class Meta
    {
        internal Meta() { }

        [JsonConstructor]
        internal Meta(long count, string cursor)
        {
            Count = count;
            Cursor = cursor;
        }

        /// <summary>
        /// The total number of items returned in the response.
        /// </summary>
        public long Count { get; }

        /// <summary>
        /// A cursor string for paginating through results.
        /// </summary>
        public string Cursor { get; }
    }
}
