using System.Text.Json.Serialization;

namespace VT.NET.Responses.Domains.Report
{
    /// <summary>
    /// Represents a popularity rank for a domain.
    /// </summary>
    public class PopularityRank
    {
        internal PopularityRank() { }

        [JsonConstructor]
        internal PopularityRank(int rank, long timestamp)
        {
            Rank = rank;
            Timestamp = timestamp;
        }

        /// <summary>
        /// Rank position of the domain.
        /// </summary>
        public int Rank { get; }

        /// <summary>
        /// UTC timestamp when the rank was recorded.
        /// </summary>
        public long Timestamp { get; }
    }
}
