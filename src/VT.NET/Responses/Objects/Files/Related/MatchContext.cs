using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace VT.NET.Responses.Objects.Files.Related
{
    /// <summary>
    /// Specific matched events.
    /// </summary>
    public class MatchContext
    {
        internal MatchContext() { }

        [JsonConstructor]
        internal MatchContext(Dictionary<string, string> values)
        {
            Values = values;
        }

        /// <summary>
        /// All matched events represented as key-value.
        /// </summary>
        public Dictionary<string, string> Values { get; }
    }
}
