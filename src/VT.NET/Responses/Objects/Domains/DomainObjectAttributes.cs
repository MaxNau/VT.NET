using System.Collections.Generic;
using System.Text.Json.Serialization;
using VT.NET.Responses.Domains;
using VT.NET.Responses.Objects;
using VT.NET.Responses.Objects.Analysis;
using VT.NET.Responses.Objects.Vote;

namespace VT.NET.Responses.Objects.Domains
{
    /// <summary>
    /// Represents attributes related to a domain retrieved from the VirusTotal API.
    /// This class contains information such as categorization, creation date, analysis results, and other relevant details about the domain.
    /// </summary>
    public class DomainObjectAttributes : VTScannedObjectAttributes
    {
        internal DomainObjectAttributes() { }

        [JsonConstructor]
        internal DomainObjectAttributes(string whois, long whoisDate, long lastHttpsCertificateDate,
            long creationDate, long lastAnalysisDate, long lastModificationDate,
            Dictionary<string, string> categories, long lastUpdateDate, List<DnsRecord> lastDnsRecords,
            string tld, string registrar, Dictionary<string, PopularityRank> popularityRanks, string jarm,
            long lastDnsRecordsDate, object lastHttpsCertificate,
            Dictionary<string, LastAnalysisResult> lastAnalysisResults, LastAnalysisStats lastAnalysisStats,
            TotalVotes totalVotes, long reputation, List<string> tags)
            : base(lastAnalysisDate, lastModificationDate, lastAnalysisResults, lastAnalysisStats,
                  totalVotes, reputation, tags)
        {
            Categories = categories;
            CreationDate = creationDate;
            Jarm = jarm;
            LastDnsRecords = lastDnsRecords;
            LastDnsRecordsDate = lastDnsRecordsDate;
            LastHttpsCertificate = lastHttpsCertificate;
            LastHttpsCertificateDate = lastHttpsCertificateDate;
            LastUpdateDate = lastUpdateDate;
            PopularityRanks = popularityRanks;
            Registrar = registrar;
            Whois = whois;
            WhoisDate = whoisDate;
            Tld = tld;
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
        /// Whois information as returned from the pertinent whois server.
        /// </summary>
        public string Whois { get; }

        /// <summary>
        /// Date of the last update of the whois record in VirusTotal.
        /// </summary>
        public long WhoisDate { get; }

        /// <summary>
        /// Gets the top-level domain (TLD) associated with the domain object.
        /// </summary>
        /// <remarks>
        /// The TLD is the last segment of the domain name, such as ".com", ".org", or ".net". .
        /// </remarks>
        public string Tld { get; }
    }
}
