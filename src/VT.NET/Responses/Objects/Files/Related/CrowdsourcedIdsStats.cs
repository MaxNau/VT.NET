using System.Text.Json.Serialization;

namespace VT.NET.Responses.Objects.Files.Related
{
    /// <summary>
    /// IDS results stats
    /// </summary>
    public class CrowdsourcedIdsStats
    {
        internal CrowdsourcedIdsStats() { }

        [JsonConstructor]
        internal CrowdsourcedIdsStats(int high, int medium, int low, int info)
        {
            High = high;
            Medium = medium;
            Low = low;
            Info = info;
        }

        /// <summary>
        /// Number of IDS matched rules having a high severity.
        /// </summary>
        public int High { get; }

        /// <summary>
        /// Number of IDS matched rules having a medium severity.
        /// </summary>
        public int Medium { get; }

        /// <summary>
        /// Number of IDS matched rules having a low severity.
        /// </summary>
        public int Low { get; }

        /// <summary>
        /// Number of IDS matched rules having a info severity.
        /// </summary>
        public int Info { get; }
    }
}
