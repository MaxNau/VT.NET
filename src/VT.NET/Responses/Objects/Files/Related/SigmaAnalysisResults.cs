using System.Text.Json.Serialization;

namespace VT.NET.Responses.Objects.Files.Related
{
    /// <summary>
    /// Sigma analyses results from all sandbox generated EVTX files
    /// </summary>
    public class SigmaAnalysisResults
    {
        internal SigmaAnalysisResults() { }

        [JsonConstructor]
        internal SigmaAnalysisResults(string ruleLevel, string ruleId, string ruleSource, string ruleTitle,
            string ruleDescription, string ruleAuthor, MatchContext[] matchContext)
        {
            RuleLevel = ruleLevel;
            RuleId = ruleId;
            RuleSource = ruleSource;
            RuleTitle = ruleTitle;
            RuleDescription = ruleDescription;
            RuleAuthor = ruleAuthor;
            MatchContext = matchContext;
        }

        /// <summary>
        /// Rule level, can be either of "critical", "high", "medium", "low".
        /// </summary>
        public string RuleLevel { get; }

        /// <summary>
        /// Rule ID in VirusTotal. You can use this to find other files matching this same rule.
        /// </summary>
        public string RuleId { get; }

        /// <summary>
        /// Sigma ruleset where this rule belongs to.
        /// </summary>
        public string RuleSource { get; }

        /// <summary>
        /// Matched sigma rule title.
        /// </summary>
        public string RuleTitle { get; }

        /// <summary>
        /// Rule description.
        /// </summary>
        public string RuleDescription { get; }

        /// <summary>
        /// Rule author
        /// </summary>
        public string RuleAuthor { get; }

        /// <summary>
        /// Specific matched events.
        /// </summary>
        public MatchContext[] MatchContext { get; }
    }
}
