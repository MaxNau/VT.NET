using System.Collections.Generic;
using System.Text.Json.Serialization;
using VT.NET.Responses.Objects.Analysis;
using VT.NET.Responses.Objects.Files.Related;
using VT.NET.Responses.Objects.Vote;

namespace VT.NET.Responses.Objects.Files
{
    /// <summary>
    /// Represents the attributes containing detailed information about a file's analysis 
    /// from the VirusTotal API response.
    /// </summary>
    /// <remarks>
    /// The <see cref="FileObjectAttributes"/> class includes various statistics and metadata related 
    /// to the analyzed file, such as hashes, submission dates, and analysis results.
    /// </remarks>
    public class FileObjectAttributes : VTScannedObjectAttributes
    {
        internal FileObjectAttributes() { }

        [JsonConstructor]
        internal FileObjectAttributes(string sha1, long lastModificationDate, List<string> names,
            string md5, long size, long lastAnalysisDate, string magic, string tlsh,
            string magika, List<string> tags, string typeDescription, long timesSubmitted,
            List<object> typeTags, long reputation, LastAnalysisStats lastAnalysisStats,
            string sha256, TotalVotes totalVotes, long lastSubmissionDate, long uniqueSources,
            string meaningfulName, Dictionary<string, LastAnalysisResult> lastAnalysisResults,
            long firstSubmissionDate, string ssdeep,
            IEnumerable<CrowdsourcedIdResults> crowdsourcedIdsResults, CrowdsourcedIdsStats crowdsourcedIdsStats,
            Dictionary<string, SandboxVerdict> sandboxVerdicts,
            PopularThreatClassification popularThreatClassification, DetectItEasy detectItEasy,
            string typeTag, string authentihash, SigmaAnalysisStats sigmaAnalysisStats,
            IEnumerable<SigmaAnalysisResults> sigmaAnalysisResults, long creationDate, string vhash,
            string typeExtension, Dictionary<string, string> packers, IEnumerable<CrowdsourcedYaraResults> crowdsourcedYaraResults)
            : base(lastAnalysisDate, lastModificationDate, lastAnalysisResults, lastAnalysisStats,
                 totalVotes, reputation, tags)
        {
            Sha1 = sha1;
            Names = names;
            Md5 = md5;
            Size = size;
            Magic = magic;
            Tlsh = tlsh;
            Magika = magika;
            TypeDescription = typeDescription;
            TimesSubmitted = timesSubmitted;
            TypeTags = typeTags;
            Sha256 = sha256;
            LastSubmissionDate = lastSubmissionDate;
            UniqueSources = uniqueSources;
            MeaningfulName = meaningfulName;
            FirstSubmissionDate = firstSubmissionDate;
            Ssdeep = ssdeep;
            CrowdsourcedIdsResults = crowdsourcedIdsResults;
            SandboxVerdicts = sandboxVerdicts;
            PopularThreatClassification = popularThreatClassification;
            DetectItEasy = detectItEasy;
            TypeTag = typeTag;
            Authentihash = authentihash;
            SigmaAnalysisStats = sigmaAnalysisStats;
            SigmaAnalysisResults = sigmaAnalysisResults;
            CreationDate = creationDate;
            Vhash = vhash;
            TypeExtension = typeExtension;
            Packers = packers;
            CrowdsourcedIdsStats = crowdsourcedIdsStats;
            CrowdsourcedYaraResults = crowdsourcedYaraResults;
        }

        /// <summary>
        /// SHA-1 hash of the file.
        /// </summary>
        public string Sha1 { get; }

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
        /// SHA-256 hash of the file.
        /// </summary>
        public string Sha256 { get; }

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
        /// Date of the first submission of the file.
        /// </summary>
        public long FirstSubmissionDate { get; }

        /// <summary>
        /// ssdeep hash of the file.
        /// </summary>
        public string Ssdeep { get; }

        /// <summary>
        /// IDS matches for the file.
        /// </summary>
        public IEnumerable<CrowdsourcedIdResults> CrowdsourcedIdsResults { get; }

        /// <summary>
        /// IDS results stats.
        /// </summary>
        public CrowdsourcedIdsStats CrowdsourcedIdsStats { get; }

        /// <summary>
        /// A summary of all sandbox verdicts for a given file.
        /// </summary>
        public Dictionary<string, SandboxVerdict> SandboxVerdicts { get; }

        /// <summary>
        /// Human readable names extracted from the AV verdicts and clustering hashes
        /// </summary>
        public PopularThreatClassification PopularThreatClassification { get; }

        /// <summary>
        /// File type identification tool.
        /// </summary>
        public DetectItEasy DetectItEasy { get; }

        /// <summary>
        /// File type tag
        /// </summary>
        public string TypeTag { get; }

        /// <summary>
        /// Gets the authentihash associated with the object.
        /// </summary>
        /// <remarks>
        /// The authentihash is a unique identifier that can be used to verify the integrity of the object.
        /// </remarks>
        public string Authentihash { get; }

        /// <summary>
        /// Sigma analysis stats for the file.
        /// </summary>
        public SigmaAnalysisStats SigmaAnalysisStats { get; }

        /// <summary>
        /// Sigma results for the file.
        /// </summary>
        public IEnumerable<SigmaAnalysisResults> SigmaAnalysisResults { get; }

        /// <summary>
        /// The creation date indicates when the file was originally created
        /// </summary>
        public long CreationDate { get; }

        /// <summary>
        /// Vhash of the file.
        /// </summary>
        /// <remarks>
        /// The vhash is a unique hash value associated with the file, typically used for identifying the object across systems.
        /// </remarks>
        public string Vhash { get; }

        /// <summary>
        /// File extension type associated with the object.
        /// </summary>
        /// <remarks>
        /// The type extension provides information about the file type, which can be useful for filtering or categorizing files.
        /// </remarks>
        public string TypeExtension { get; }

        /// <summary>
        /// Identifies packers used on Windows PE files by several tools and AVs.
        /// Keys are tool names and values are identified packers
        /// </summary>
        public Dictionary<string,string> Packers { get; }

        /// <summary>
        /// YARA matches for the file.
        /// </summary>
        public IEnumerable<CrowdsourcedYaraResults> CrowdsourcedYaraResults { get; }
    }
}
