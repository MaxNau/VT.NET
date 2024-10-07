using System.Text.Json.Serialization;

namespace VT.NET.Responses.Comments
{
    internal class CreateCommentObject
    {
        [JsonConstructor]
        internal CreateCommentObject(string comment)
        {
            Attributes = new CreateCommentObjectAttributes(comment);
        }

        public string Type => "comment";
        public CreateCommentObjectAttributes Attributes { get; }
    }
}
