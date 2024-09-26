namespace VT.NET.Responses.Files.Comments
{
    internal class CreateCommentAttributes
    {
        public CreateCommentAttributes(string comment)
        {
            Text = comment;
        }

        public string Text { get; }
    }
}
