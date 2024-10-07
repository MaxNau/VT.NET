using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace VT.NET.Responses.Objects.Files.Related
{
    /// <summary>
    /// Sandbox verdict details
    /// </summary>
    public class SandboxVerdict
    {
        internal SandboxVerdict() { }

        [JsonConstructor]
        internal SandboxVerdict(string category, int confidence, IEnumerable<string> malwareClassification,
            IEnumerable<string> malwareNames, string sandboxName)
        {
            Category = category;
            Confidence = confidence;
            MalwareClassification = malwareClassification;
            MalwareNames = malwareNames;
            SandboxName = sandboxName;
        }

        /// <summary>
        /// Normalized verdict category.It can be one of suspicious, malicious, harmless or undetected.
        /// </summary>
        public string Category { get; }

        /// <summary>
        /// Verdict confidence from 0 to 100.
        /// </summary>
        public int Confidence { get; }

        /// <summary>
        /// Raw sandbox verdicts.
        /// </summary>
        public IEnumerable<string> MalwareClassification { get; }

        /// <summary>
        /// Malware family names.
        /// </summary>
        public IEnumerable<string> MalwareNames { get; }

        /// <summary>
        /// Sandbox that provided the verdict.
        /// </summary>
        public string SandboxName { get; }
    }
}
