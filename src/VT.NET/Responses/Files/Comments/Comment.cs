using System.Text.Json.Serialization;

namespace VT.NET.Responses.Files.Comments
{
    /// <summary>
    /// Represents a comment associated with a file analysis in the VirusTotal API response.
    /// </summary>
    /// <remarks>
    /// The <see cref="Comment"/> class includes details about user comments related 
    /// to the analysis of files, including attributes that provide specific information 
    /// about the comment.
    /// </remarks>
    public class Comment : VTObject
    {
        internal Comment() { }

        [JsonConstructor]
        internal Comment(string id, string type, Links links, CommentAttributes attributes)
            : base(type, id, links)
        {
            Attributes = attributes;
        }

        /// <summary>
        /// Attributes that provide detailed information about the comment.
        /// </summary>
        public CommentAttributes Attributes { get; set; }
    }
}
