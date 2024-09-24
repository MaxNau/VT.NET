using System.Text.Json.Serialization;

namespace VT.NET.Responses.Files.FileReport
{
    public class TotalVotes
    {
        internal TotalVotes() { }

        [JsonConstructor]
        internal TotalVotes(long harmless, long malicious)
        {
            Harmless = harmless;
            Malicious = malicious;
        }

        public long Harmless { get; }
        public long Malicious { get; }
    }
}
