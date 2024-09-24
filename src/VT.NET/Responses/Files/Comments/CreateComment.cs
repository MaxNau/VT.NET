namespace VT.NET.Responses.Files.Comments
{
    internal class CreateComment
    {
        internal CreateComment(string comment)
        {
            Attributes = new CreateCommentAttributes(comment);
        }

        public string Type => "comment";
        public CreateCommentAttributes Attributes { get; }
    }
}
