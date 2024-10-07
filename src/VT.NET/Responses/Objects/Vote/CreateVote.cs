using System.Text.Json.Serialization;

namespace VT.NET.Responses.Objects.Vote
{
    internal class CreateVote
    {
        [JsonConstructor]
        internal CreateVote(Verdict verdict)
        {
            Attributes = new CreateVoteAttributes(verdict);
        }

        public string Type => "vote";
        public CreateVoteAttributes Attributes { get; }
    }
}
