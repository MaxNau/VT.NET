using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace VT.NET.Responses.Files.FileReport
{
    /// <summary>
    /// Represents the attributes containing detailed information about a file's analysis 
    /// from the VirusTotal API response.
    /// </summary>
    /// <remarks>
    /// The <see cref="Attributes"/> class includes various statistics and metadata related 
    /// to the analyzed file, such as hashes, submission dates, and analysis results.
    /// </remarks>
    public class Attributes
    {
        internal Attributes() { }

        [JsonConstructor]
        internal Attributes(string sha1, long lastModificationDate, List<string> names,
            string md5, long size, long lastAnalysisDate, string magic, string tlsh,
            string magika, List<object> tags, string typeDescription, long timesSubmitted,
            List<object> typeTags, long reputation, LastAnalysisStats lastAnalysisStats,
            string sha256, TotalVotes totalVotes, long lastSubmissionDate, long uniqueSources,
            string meaningfulName, Dictionary<string, LastAnalysisResult> lastAnalysisResults,
            long firstSubmissionDate, string ssdeep)
        {
            Sha1 = sha1;
            LastModificationDate = lastModificationDate;
            Names = names;
            Md5 = md5;
            Size = size;
            LastAnalysisDate = lastAnalysisDate;
            Magic = magic;
            Tlsh = tlsh;
            Magika = magika;
            Tags = tags;
            TypeDescription = typeDescription;
            TimesSubmitted = timesSubmitted;
            TypeTags = typeTags;
            Reputation = reputation;
            LastAnalysisStats = lastAnalysisStats;
            Sha256 = sha256;
            TotalVotes = totalVotes;
            LastSubmissionDate = lastSubmissionDate;
            UniqueSources = uniqueSources;
            MeaningfulName = meaningfulName;
            LastAnalysisResults = lastAnalysisResults;
            FirstSubmissionDate = firstSubmissionDate;
            Ssdeep = ssdeep;
        }

        /// <summary>
        /// SHA-1 hash of the file.
        /// </summary>
        public string Sha1 { get; }

        /// <summary>
        /// Date the file was last modified.
        /// </summary>
        public long LastModificationDate { get; }

        /// <summary>
        /// Names associated with the file.
        /// </summary>
        public List<string> Names { get; }

        /// <summary>
        /// MD5 hash of the file.
        /// </summary>
        public string Md5 { get; }

        /// <summary>
        /// Size of the file in bytes.
        /// </summary>
        public long Size { get; }

        /// <summary>
        /// Date of the last analysis of the file.
        /// </summary>
        public long LastAnalysisDate { get; }

        /// <summary>
        /// File type as determined by the magic bytes.
        /// </summary>
        public string Magic { get; }

        /// <summary>
        /// TLSH hash of the file.
        /// </summary>
        public string Tlsh { get; }

        /// <summary>
        /// Magic number representation of the file.
        /// </summary>
        public string Magika { get; }

        /// <summary>
        /// Tags associated with the file.
        /// </summary>
        public List<object> Tags { get; }

        /// <summary>
        /// Description of the file type.
        /// </summary>
        public string TypeDescription { get; }

        /// <summary>
        /// Number of times the file has been submitted for analysis.
        /// </summary>
        public long TimesSubmitted { get; }

        /// <summary>
        /// Tags related to the file type.
        /// </summary>
        public List<object> TypeTags { get; }

        /// <summary>
        /// Reputation score of the file.
        /// </summary>
        public long Reputation { get; }

        /// <summary>
        /// Statistics from the last analysis.
        /// </summary>
        public LastAnalysisStats LastAnalysisStats { get; }

        /// <summary>
        /// SHA-256 hash of the file.
        /// </summary>
        public string Sha256 { get; }

        /// <summary>
        /// Total votes received for the file's reputation.
        /// </summary>
        public TotalVotes TotalVotes { get; }

        /// <summary>
        /// Date of the last submission of the file.
        /// </summary>
        public long LastSubmissionDate { get; }

        /// <summary>
        /// Number of unique sources that submitted the file.
        /// </summary>
        public long UniqueSources { get; }

        /// <summary>
        /// Meaningful name for the file, if available.
        /// </summary>
        public string MeaningfulName { get; }

        /// <summary>
        /// Results from the last analysis by various engines.
        /// </summary>
        public Dictionary<string, LastAnalysisResult> LastAnalysisResults { get; }

        /// <summary>
        /// Date of the first submission of the file.
        /// </summary>
        public long FirstSubmissionDate { get; }

        /// <summary>
        /// ssdeep hash of the file.
        /// </summary>
        public string Ssdeep { get; }
    }
}
