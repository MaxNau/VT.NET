using System.Text.Json.Serialization;
using VT.NET.Responses.Objects.Comments;

namespace VT.NET.Responses.Comments
{
    /// <summary>
    /// Represents the attributes of a comment in the VirusTotal API response.
    /// </summary>
    /// <remarks>
    /// The <see cref="CommentObjectAttributes"/> class contains detailed information about a 
    /// comment, including tags, submission date, votes, and the content of the comment.
    /// </remarks>
    public class CommentObject : VTObject
    {
        internal CommentObject() { }

        [JsonConstructor]
        internal CommentObject(string id, string type, Links links, CommentObjectAttributes attributes)
            : base(id, type, links)
        {
            Attributes = attributes;
        }

        /// <summary>
        /// Attributes that provide detailed information about the comment.
        /// </summary>
        public CommentObjectAttributes Attributes { get; }
    }
}
