using System.Text.Json.Serialization;

namespace VT.NET.Responses.Files.Comments
{
    /// <summary>
    /// Represents the voting results for a analysis in the VirusTotal API response.
    /// </summary>
    /// <remarks>
    /// The <see cref="Votes"/> class contains the counts of positive, negative, and abuse votes
    /// related to a safety evaluation by various engines.
    /// </remarks>
    public class Votes
    {
        internal Votes() { }

        [JsonConstructor]
        internal Votes(long positive, long negative, long abuse)
        {
            Positive = positive;
            Negative = negative;
            Abuse = abuse;
        }

        /// <summary>
        /// Represents the total number of positive votes indicating the file is safe.
        /// </summary>
        public long Positive { get; }

        /// <summary>
        /// Represents the total number of negative votes indicating the file is unsafe.
        /// </summary>
        public long Negative { get; }

        /// <summary>
        /// Represents the total number of votes indicating abuse associated with the file.
        /// </summary>
        public long Abuse { get; }
    }
}
