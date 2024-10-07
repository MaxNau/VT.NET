using System.Collections.Generic;
using VT.NET.Responses.Objects.Analysis;
using VT.NET.Responses.Objects.Vote;

namespace VT.NET.Responses.Objects
{
    /// <summary>
    /// VirusTotal scanned object common attributes
    /// </summary>
    public abstract class VTScannedObjectAttributes : VTObjectAttributes
    {
        internal VTScannedObjectAttributes() { }

        internal VTScannedObjectAttributes(long lastAnalysisDate, long lastModificationDate,
            Dictionary<string, LastAnalysisResult> lastAnalysisResults, LastAnalysisStats lastAnalysisStats,
            TotalVotes totalVotes, long reputation, List<string> tags)
        {
            LastAnalysisDate = lastAnalysisDate;
            LastModificationDate = lastModificationDate;
            LastAnalysisResults = lastAnalysisResults;
            LastAnalysisStats = lastAnalysisStats;
            TotalVotes = totalVotes;
            Reputation = reputation;
            Tags = tags;
        }

        /// <summary>
        /// Date of the last analysis of the scanned object.
        /// </summary>
        public long LastAnalysisDate { get; }

        /// <summary>
        /// Date the scanned object was last modified.
        /// </summary>
        public long LastModificationDate { get; }

        /// <summary>
        /// Results from the last analysis by various engines.
        /// </summary>
        public Dictionary<string, LastAnalysisResult> LastAnalysisResults { get; }

        /// <summary>
        /// Statistics from the last analysis.
        /// </summary>
        public LastAnalysisStats LastAnalysisStats { get; }

        /// <summary>
        /// Total votes received.
        /// </summary>
        public TotalVotes TotalVotes { get; }

        /// <summary>
        /// Reputation score of the scanned object.
        /// </summary>
        public long Reputation { get; }

        /// <summary>
        /// Tags associated with the scanned object.
        /// </summary>
        public List<string> Tags { get; }
    }
}
