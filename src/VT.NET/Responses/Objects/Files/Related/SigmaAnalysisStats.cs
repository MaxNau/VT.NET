using System.Text.Json.Serialization;

namespace VT.NET.Responses.Objects.Files.Related
{
    /// <summary>
    /// Sigma analysis stats for the file.
    /// </summary>
    public class SigmaAnalysisStats
    {
        internal SigmaAnalysisStats() { }

        [JsonConstructor]
        internal SigmaAnalysisStats(int critical, int high, int medium, int low)
        {
            Critical = critical;
            High = high;
            Medium = medium;
            Low = low;
        }

        /// <summary>
        /// Number of matched critical severity rules.
        /// </summary>
        public int Critical { get; }

        /// <summary>
        /// Number of matched high severity rules.
        /// </summary>
        public int High { get; }

        /// <summary>
        /// Number of matched low severity rules.
        /// </summary>
        public int Medium { get; }

        /// <summary>
        /// Number of matched medium severity rules.
        /// </summary>
        public int Low { get; }
    }
}
