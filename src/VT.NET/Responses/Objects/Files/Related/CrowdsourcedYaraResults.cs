namespace VT.NET.Responses.Objects.Files.Related
{
    /// <summary>
    /// YARA matches from crowdsourced rules.
    /// </summary>
    public class CrowdsourcedYaraResults
    {
        /// <summary>
        /// Matched rule description.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Rule author.
        /// </summary>
        public string Author { get; set; }

        /// <summary>
        /// Matched rule's ruleset name.
        /// </summary>
        public string RulesetName { get; set; }

        /// <summary>
        /// Matched rule name.
        /// </summary>
        public string RuleName { get; set; }

        /// <summary>
        /// VirusTotal's ruleset ID. You can use this ID to fetch
        /// the ruleset info in the /api/v3/yara_rulesets/{id} endpoint.
        /// </summary>
        public string RulesetId { get; set; }

        /// <summary>
        /// Whether the match was in a subfile or not.
        /// </summary>
        public bool MatchInSubfile { get; set; }

        /// <summary>
        /// Ruleset source.
        /// </summary>
        public string Source { get; set; }
    }
}
