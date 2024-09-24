using System.Text.Json.Serialization;

namespace VT.NET.Responses.Files.FileReport
{
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

        public long Malicious { get; }
        public long Suspicious { get; }
        public long Undetected { get; }
        public long Harmless { get; }
        public long Timeout { get; }
        public long ConfirmedTimeout { get; }
        public long Failure { get; }
        public long TypeUnsupported { get; }
    }
}
