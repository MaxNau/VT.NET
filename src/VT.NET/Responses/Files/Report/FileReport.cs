using System.Text.Json.Serialization;

namespace VT.NET.Responses.Files.FileReport
{
    public class FileReport
    {
        internal FileReport() { }

        [JsonConstructor]
        internal FileReport(string id, string type, Links links, Attributes attributes)
        {
            Id = id;
            Type = type;
            Links = links;
            Attributes = attributes;
        }

        public string Id { get; }
        public string Type { get; }
        public Links Links { get; }
        public Attributes Attributes { get; }
    }
}
