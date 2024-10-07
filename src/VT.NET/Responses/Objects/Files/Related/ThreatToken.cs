using System.Text.Json.Serialization;

namespace VT.NET.Responses.Objects.Files.Related
{
    /// <summary>
    /// Threat token 
    /// </summary>
    public class ThreatToken
    {
        internal ThreatToken() { }

        [JsonConstructor]
        internal ThreatToken(int count, string value)
        {
            Count = count;
            Value = value;
        }

        /// <summary>
        /// How many AV engines had said token
        /// </summary>
        public int Count { get; }

        /// <summary>
        /// A token
        /// </summary>
        public string Value { get; }
    }
}
