using System.Text.Json.Serialization;

namespace VT.NET.Responses
{
    public class Meta
    {
        internal Meta() { }

        [JsonConstructor]
        internal Meta(long count, string cursor)
        {
            Count = count;
            Cursor = cursor;
        }

        public long Count { get; }
        public string Cursor { get; }
    }
}
