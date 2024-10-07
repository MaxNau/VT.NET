using System.Text.Json.Serialization;

namespace VT.NET.Responses.Objects.Vote
{
    internal class CreateVoteAttributes
    {
        [JsonConstructor]
        internal CreateVoteAttributes(Verdict verdict)
        {
            Verdict = verdict;
        }

        public Verdict Verdict { get; }
    }
}
