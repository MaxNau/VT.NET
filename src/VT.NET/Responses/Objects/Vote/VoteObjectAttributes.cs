using System.Text.Json.Serialization;

namespace VT.NET.Responses.Objects.Vote
{
    /// <summary>
    /// Represents the attributes associated with a vote in the VirusTotal API response.
    /// </summary>
    public class VoteObjectAttributes
    {
        internal VoteObjectAttributes() { }

        [JsonConstructor]
        internal VoteObjectAttributes(long date, int value, string verdict)
        {
            Date = date;
            Value = value;
            Verdict = verdict;
        }

        /// <summary>
        /// Date when the vote was cast, represented as a timestamp.
        /// </summary>
        public long Date { get; }

        /// <summary>
        /// Weight given by this vote for the community score (positive or negative).
        /// </summary>
        public int Value { get; }

        /// <summary>
        /// Verdict indicating if the vote was for making it "malicious" or "harmless".
        /// </summary>
        public string Verdict { get; }
    }
}
