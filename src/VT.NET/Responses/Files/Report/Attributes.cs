using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace VT.NET.Responses.Files.FileReport
{
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

        public string Sha1 { get; }
        public long LastModificationDate { get; }
        public List<string> Names { get; }
        public string Md5 { get; }
        public long Size { get; }
        public long LastAnalysisDate { get; }
        public string Magic { get; }
        public string Tlsh { get; }
        public string Magika { get; }
        public List<object> Tags { get; }
        public string TypeDescription { get; }
        public long TimesSubmitted { get; }
        public List<object> TypeTags { get; }
        public long Reputation { get; }
        public LastAnalysisStats LastAnalysisStats { get; }
        public string Sha256 { get; }
        public TotalVotes TotalVotes { get; }
        public long LastSubmissionDate { get; }
        public long UniqueSources { get; }
        public string MeaningfulName { get; }
        public Dictionary<string, LastAnalysisResult> LastAnalysisResults { get; }
        public long FirstSubmissionDate { get; }
        public string Ssdeep { get; }
    }
}
