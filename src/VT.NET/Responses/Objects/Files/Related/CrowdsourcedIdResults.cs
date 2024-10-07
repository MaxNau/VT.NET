using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace VT.NET.Responses.Objects.Files.Related
{
    /// <summary>
    /// IDS (Snort and Suricata) matches for the file. If the file it's not a PCAP,
    /// the matches are taken from a PCAP generated after running the file in a sandbox.
    /// Results are sorted by severity level, there is only one item per matched alert.
    /// </summary>
    public class CrowdsourcedIdResults
    {
        internal CrowdsourcedIdResults() { }

        [JsonConstructor]
        internal CrowdsourcedIdResults(string ruleCategory, string alertSeverity, string ruleMsg, string ruleId,
            string ruleSource, string ruleUrl, string ruleRaw, IEnumerable<string> ruleReferences,
            IEnumerable<AlertContext> alertContext)
        {
            RuleCategory = ruleCategory;
            AlertSeverity = alertSeverity;
            RuleMsg = ruleMsg;
            RuleId = ruleId;
            RuleSource = ruleSource;
            RuleUrl = ruleUrl;
            RuleRaw = ruleRaw;
            RuleReferences = ruleReferences;
            AlertContext = alertContext;
        }

        /// <summary>
        /// Alert category description
        /// </summary>
        public string RuleCategory { get; }

        /// <summary>
        /// One of high, medium, low or info.
        /// </summary>
        public string AlertSeverity { get; }

        /// <summary>
        /// Alert description.
        /// </summary>
        public string RuleMsg { get; }

        /// <summary>
        /// Suricata/Snort rule SID.
        /// </summary>
        public string RuleId { get; }

        /// <summary>
        /// Rule source, determined by SID range.
        /// </summary>
        public string RuleSource { get; }

        /// <summary>
        /// Rule URL
        /// </summary>
        public string RuleUrl { get; }

        /// <summary>
        /// Raw rule
        /// </summary>
        public string RuleRaw { get; }

        /// <summary>
        /// Rule references
        /// </summary>
        public IEnumerable<string> RuleReferences { get; }

        /// <summary>
        /// Context for every match of that alert
        /// </summary>
        public IEnumerable<AlertContext> AlertContext { get; }
    }
}
