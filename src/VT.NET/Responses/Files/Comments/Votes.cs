using System.Text.Json.Serialization;

namespace VT.NET.Responses.Files.Comments
{
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

        public long Positive { get; }
        public long Negative { get; }
        public long Abuse { get; }
    }
}
