using System.Collections.Generic;
using System.Text.Json.Serialization;
using VT.NET.Responses.Objects.Vote;

namespace VT.NET.Responses.Objects.Comments
{
    /// <summary>
    /// Represents the attributes of a comment in the VirusTotal API.
    /// </summary>
    public class CommentObjectAttributes
    {
        internal CommentObjectAttributes() { }

        [JsonConstructor]
        internal CommentObjectAttributes(string html, string text, VotingResults votes, List<string> tags, int date)
        {
            Html = html;
            Text = text;
            Votes = votes;
            Tags = tags;
            Date = date;
        }

        /// <summary>
        /// HTML representation of the comment.
        /// </summary>
        public string Html { get; }

        /// <summary>
        /// Plain text representation of the comment.
        /// </summary>
        public string Text { get; }

        /// <summary>
        /// Votes associated with the comment.
        /// </summary>
        public VotingResults Votes { get; }

        /// <summary>
        /// Tags associated with the comment.
        /// </summary>
        public List<string> Tags { get; }

        /// <summary>
        /// The date when the comment was created, represented as a Unix timestamp.
        /// </summary>
        public int Date { get; }
    }
}
