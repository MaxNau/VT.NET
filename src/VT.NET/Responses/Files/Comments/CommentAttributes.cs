using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace VT.NET.Responses.Files.Comments
{
    /// <summary>
    /// Represents the attributes of a comment in the VirusTotal API response.
    /// </summary>
    /// <remarks>
    /// The <see cref="CommentAttributes"/> class contains detailed information about a 
    /// comment, including tags, submission date, votes, and the content of the comment.
    /// </remarks>
    public class CommentAttributes
    {
        internal CommentAttributes() { }

        internal CommentAttributes(string text)
        {
            Text = text;
        }

        [JsonConstructor]
        internal CommentAttributes(List<string> tags, long date, Votes votes, string html, string text)
        {
            Tags = tags;
            Date = date;
            Votes = votes;
            Html = html;
            Text = text;
        }

        /// <summary>
        /// A list of tags associated with the comment.
        /// </summary>
        public List<string> Tags { get; }

        /// <summary>
        /// The date when the comment was submitted.
        /// </summary>
        public long Date { get; }

        /// <summary>
        /// Voting information related to the comment.
        /// </summary>
        public Votes Votes { get; }

        /// <summary>
        /// The comment content in HTML format.
        /// </summary>
        public string Html { get; }

        /// <summary>
        /// The plain text content of the comment.
        /// </summary>
        public string Text { get; }
    }
}
