using System.Text.Json.Serialization;
using VT.NET.Responses.Files.FileReport;

namespace VT.NET.Responses.Files.Comments
{
    public class Comment
    {
        internal Comment() { }

        [JsonConstructor]
        internal Comment(string id, string type, Links links, CommentAttributes attributes)
        {
            Id = id;
            Type = type;
            Links = links;
            Attributes = attributes;
        }

        public string Id { get; set; }
        public string Type { get; set; }
        public Links Links { get; set; }
        public CommentAttributes Attributes { get; set; }
    }
}
