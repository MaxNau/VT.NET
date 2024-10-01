using System.Collections.Generic;
using System.Text.Json.Serialization;
using VT.NET.Responses.Analysis;
using VT.NET.Responses.Files.FileReport;

namespace VT.NET.Responses.Domains.Report
{
    /// <summary>
    /// Represents attributes related to a domain retrieved from the VirusTotal API.
    /// This class contains information such as categorization, creation date, analysis results, and other relevant details about the domain.
    /// </summary>
    public class DomainAttributes
    {
        internal DomainAttributes() { }

        [JsonConstructor]
        internal DomainAttributes(Dictionary<string, string> categories, long creationDate, string jarm,
            long lastAnalysisDate, Dictionary<string, LastAnalysisResult> lastAnalysisResults,
            LastAnalysisStats lastAnalysisStats, List<DnsRecord> lastDnsRecords,
            long lastDnsRecordsDate, object lastHttpsCertificate, long lastHttpsCertificateDate,
            long lastModificationDate, long lastUpdateDate,
            Dictionary<string, PopularityRank> popularityRanks, string registrar, int reputation,
            List<string> tags, TotalVotes totalVotes, string whois, long whoisDate)
        {
            Categories = categories;
            CreationDate = creationDate;
            Jarm = jarm;
            LastAnalysisDate = lastAnalysisDate;
            LastAnalysisResults = lastAnalysisResults;
            LastAnalysisStats = lastAnalysisStats;
            LastDnsRecords = lastDnsRecords;
            LastDnsRecordsDate = lastDnsRecordsDate;
            LastHttpsCertificate = lastHttpsCertificate;
            LastHttpsCertificateDate = lastHttpsCertificateDate;
            LastModificationDate = lastModificationDate;
            LastUpdateDate = lastUpdateDate;
            PopularityRanks = popularityRanks;
            Registrar = registrar;
            Reputation = reputation;
            Tags = tags;
            TotalVotes = totalVotes;
            Whois = whois;
            WhoisDate = whoisDate;
        }

        /// <summary>
        /// Mapping that relates categorization services with the category assigned to the domain.
        /// </summary>
        public Dictionary<string, string> Categories { get; }

        /// <summary>
        /// Creation date extracted from the Domain's whois (UTC timestamp).
        /// </summary>
        public long CreationDate { get; }

        /// <summary>
        /// Domain's JARM hash.
        /// </summary>
        public string Jarm { get; }

        /// <summary>
        /// UTC timestamp representing the last time the domain was scanned.
        /// </summary>
        public long LastAnalysisDate { get; }

        /// <summary>
        /// Results from URL scanners, mapping scanner name to their results.
        /// </summary>
        public Dictionary<string, LastAnalysisResult> LastAnalysisResults { get; }

        /// <summary>
        /// Number of different results from the scans.
        /// </summary>
        public LastAnalysisStats LastAnalysisStats { get; }

        /// <summary>
        /// Domain's DNS records on its last scan.
        /// </summary>
        public List<DnsRecord> LastDnsRecords { get; }

        /// <summary>
        /// Date when the DNS records list was retrieved by VirusTotal (UTC timestamp).
        /// </summary>
        public long LastDnsRecordsDate { get; }

        /// <summary>
        /// SSL Certificate object retrieved last time the domain was analyzed.
        /// </summary>
        public object LastHttpsCertificate { get; }

        /// <summary>
        /// Date when the certificate was retrieved by VirusTotal (UTC timestamp).
        /// </summary>
        public long LastHttpsCertificateDate { get; }

        /// <summary>
        /// Date when any of the domain's information was last updated.
        /// </summary>
        public long LastModificationDate { get; }

        /// <summary>
        /// Updated date extracted from whois (UTC timestamp).
        /// </summary>
        public long LastUpdateDate { get; }

        /// <summary>
        /// Domain's position in popularity ranks.
        /// </summary>
        public Dictionary<string, PopularityRank> PopularityRanks { get; }

        /// <summary>
        /// Company that registered the domain.
        /// </summary>
        public string Registrar { get; }

        /// <summary>
        /// Domain's score calculated from the votes of the VirusTotal community.
        /// </summary>
        public int Reputation { get; }

        /// <summary>
        /// List of representative attributes for the domain.
        /// </summary>
        public List<string> Tags { get; }

        /// <summary>
        /// Unweighted number of total votes from the community.
        /// </summary>
        public TotalVotes TotalVotes { get; }

        /// <summary>
        /// Whois information as returned from the pertinent whois server.
        /// </summary>
        public string Whois { get; }

        /// <summary>
        /// Date of the last update of the whois record in VirusTotal.
        /// </summary>
        public long WhoisDate { get; }
    }
}
