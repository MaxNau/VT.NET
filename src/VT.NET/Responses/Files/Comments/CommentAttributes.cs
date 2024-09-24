using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace VT.NET.Responses.Files.Comments
{
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

        public List<string> Tags { get; }
        public long Date { get; }
        public Votes Votes { get; }
        public string Html { get; }
        public string Text { get; }
    }
}
