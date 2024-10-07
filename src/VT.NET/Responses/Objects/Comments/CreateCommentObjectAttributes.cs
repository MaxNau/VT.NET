using System.Text.Json.Serialization;

namespace VT.NET.Responses.Comments
{
    internal class CreateCommentObjectAttributes
    {
        [JsonConstructor]
        public CreateCommentObjectAttributes(string comment)
        {
            Text = comment;
        }

        public string Text { get; }
    }
}
