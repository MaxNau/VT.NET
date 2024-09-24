using System.Text.Json.Serialization;

namespace VT.NET.Responses.Files.UploadFile
{
    public class FileAnalysis
    {
        internal FileAnalysis() { }

        [JsonConstructor]
        internal FileAnalysis(string type, string id, Links links)
        {
            Type = type;
            Id = id;
            Links = links;
        }

        public string Type { get; }
        public string Id { get; }
        public Links Links { get; }
    }
}
