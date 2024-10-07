using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace VT.NET.Responses.Objects.Files.Related
{
    /// <summary>
    /// Human readable names extracted from the AV verdicts and clustering hashes
    /// </summary>
    public class PopularThreatClassification
    {
        internal PopularThreatClassification() { }

        [JsonConstructor]
        internal PopularThreatClassification(IEnumerable<ThreatToken> popularThreatCategory,
            IEnumerable<ThreatToken> popularThreatName, string suggestedThreatLabel)
        {
            PopularThreatCategory = popularThreatCategory;
            PopularThreatName = popularThreatName;
            SuggestedThreatLabel = suggestedThreatLabel;
        }

        /// <summary>
        /// Similar to popular_threat_name but these tokens are considered more generic or, in other words,
        /// categories of malware, instead of individual families. Unlike popular_threat_name,
        /// popular_threat_category is somewhat normalized. E.g.: 'ransom' becomes 'ransomware'.
        /// </summary>
        public IEnumerable<ThreatToken> PopularThreatCategory { get; }

        /// <summary>
        /// List of ThreatToken names Sorted in decreasing frequency
        /// </summary>
        public IEnumerable<ThreatToken> PopularThreatName { get; }

        /// <summary>
        /// A string combining part of popular_threat_category and popular_threat_name.
        /// </summary>
        public string SuggestedThreatLabel { get; }
    }
}
