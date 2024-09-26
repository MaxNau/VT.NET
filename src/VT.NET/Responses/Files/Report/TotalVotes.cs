using System.Text.Json.Serialization;

namespace VT.NET.Responses.Files.FileReport
{
    /// <summary>
    /// Represents the total votes for a analysis in the VirusTotal API response.
    /// </summary>
    /// <remarks>
    /// The <see cref="TotalVotes"/> class encapsulates the voting results from different engines
    /// regarding the safety, specifically the counts of harmless and malicious votes.
    /// </remarks>
    public class TotalVotes
    {
        internal TotalVotes() { }

        [JsonConstructor]
        internal TotalVotes(long harmless, long malicious)
        {
            Harmless = harmless;
            Malicious = malicious;
        }

        /// <summary>
        /// Total number of votes indicating that the file is harmless.
        /// </summary>
        public long Harmless { get; }

        /// <summary>
        /// Total number of votes indicating that the file is malicious.
        /// </summary>
        public long Malicious { get; }
    }
}
