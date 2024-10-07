using System.Text.Json.Serialization;

namespace VT.NET.Responses.Objects.Vote
{
    /// <summary>
    /// Represents a vote object used within the VirusTotal API.
    /// </summary>
    public class VoteObject : VTObject
    {
        internal VoteObject() { }

        [JsonConstructor]
        internal VoteObject(string id, string type, Links links, VoteObjectAttributes attributes)
            : base(id, type, links)
        {
            Attributes = attributes;
        }

        /// <summary>
        /// Attributes associated with the vote object.
        /// </summary>
        public VoteObjectAttributes Attributes { get; set; }
    }
}
