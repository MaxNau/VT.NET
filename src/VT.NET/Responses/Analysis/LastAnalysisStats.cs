using System.Text.Json.Serialization;

namespace VT.NET.Responses.Analysis
{
    /// <summary>
    /// Represents the statistics of the last analysis conducted on a file in VirusTotal.
    /// </summary>
    /// <remarks>
    /// The <see cref="LastAnalysisStats"/> class contains counts of the different types of results 
    /// returned by the engines that analyzed the file.
    /// </remarks>
    public class LastAnalysisStats
    {
        internal LastAnalysisStats() { }

        [JsonConstructor]
        internal LastAnalysisStats(long malicious, long suspicious, long undetected,
            long harmless, long timeout, long confirmedTimeout, long failure, long typeUnsupported)
        {
            Malicious = malicious;
            Suspicious = suspicious;
            Undetected = undetected;
            Harmless = harmless;
            Timeout = timeout;
            ConfirmedTimeout = confirmedTimeout;
            Failure = failure;
            TypeUnsupported = typeUnsupported;
        }

        /// <summary>
        /// Count of engines that reported the file as malicious.
        /// </summary>
        public long Malicious { get; }

        /// <summary>
        /// Count of engines that reported the file as suspicious.
        /// </summary>
        public long Suspicious { get; }

        /// <summary>
        /// Count of engines that did not detect the file.
        /// </summary>
        public long Undetected { get; }

        /// <summary>
        /// Count of engines that reported the file as harmless.
        /// </summary>
        public long Harmless { get; }

        /// <summary>
        /// Count of engines that timed out during analysis.
        /// </summary>
        public long Timeout { get; }

        /// <summary>
        /// Count of engines with confirmed timeout during analysis.
        /// </summary>
        public long ConfirmedTimeout { get; }

        /// <summary>
        /// Count of engines that failed to analyze the file.
        /// </summary>
        public long Failure { get; }

        /// <summary>
        /// Count of engines that did not support the file type.
        /// </summary>
        public long TypeUnsupported { get; }
    }
}
