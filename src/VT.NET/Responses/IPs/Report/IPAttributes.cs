using System.Collections.Generic;
using System.Text.Json.Serialization;
using VT.NET.Responses.Analysis;
using VT.NET.Responses.Files.FileReport;

namespace VT.NET.Responses.IPs.Report
{
    /// <summary>
    /// Represents the attributes associated with IP address in the VirusTotal API response.
    /// This class contains various metadata and analysis results related to the IP address.
    /// </summary>
    public class IPAttributes
    {
        internal IPAttributes() { }

        [JsonConstructor]
        internal IPAttributes(string asOwner, int asn, string continent, string country, string jarm,
            long lastAnalysisDate, Dictionary<string, LastAnalysisResult> lastAnalysisResults,
            LastAnalysisStats lastAnalysisStats, string lastHttpsCertificate, long lastHttpsCertificateDate,
            long lastModificationDate, string network, string regionalInternetRegistry, int reputation,
            List<string> tags, TotalVotes totalVotes, string whois, long whoisDate)
        {
            AsOwner = asOwner;
            Asn = asn;
            Continent = continent;
            Country = country;
            Jarm = jarm;
            LastAnalysisDate = lastAnalysisDate;
            LastAnalysisResults = lastAnalysisResults;
            LastAnalysisStats = lastAnalysisStats;
            LastHttpsCertificate = lastHttpsCertificate;
            LastHttpsCertificateDate = lastHttpsCertificateDate;
            LastModificationDate = lastModificationDate;
            Network = network;
            RegionalInternetRegistry = regionalInternetRegistry;
            Reputation = reputation;
            Tags = tags;
            TotalVotes = totalVotes;
            Whois = whois;
            WhoisDate = whoisDate;
        }

        /// Owner of the Autonomous System to which the IP belongs.
        public string AsOwner { get; }

        /// Autonomous System Number to which the IP belongs.
        public int Asn { get; }

        /// Continent where the IP is placed (ISO-3166 continent code).
        public string Continent { get; }

        /// Country where the IP is placed (ISO-3166 country code).
        public string Country { get; }

        /// JARM hash of the IP address.
        public string Jarm { get; }

        /// UTC timestamp representing the last time the IP was scanned.
        public long LastAnalysisDate { get; }

        /// Results from URL scanners, with the scanner name as the key.
        public Dictionary<string, LastAnalysisResult> LastAnalysisResults { get; }

        /// Number of different results from the scans.
        public LastAnalysisStats LastAnalysisStats { get; }

        /// SSL Certificate object information for the IP.
        public string LastHttpsCertificate { get; } // Assume this will be further defined

        /// Date when the last HTTPS certificate was retrieved.
        public long LastHttpsCertificateDate { get; }

        /// UTC timestamp when any of the IP's information was last updated.
        public long LastModificationDate { get; }

        /// IP network range to which the IP belongs.
        public string Network { get; }

        /// Regional Internet Registry (RIR) for the IP.
        public string RegionalInternetRegistry { get; }

        /// IP's score calculated from the votes of the VirusTotal community.
        public int Reputation { get; }

        /// List of identificative attributes for the IP.
        public List<string> Tags { get; }

        /// Unweighted number of total votes from the community.
        public TotalVotes TotalVotes { get; }

        /// WHOIS information as returned from the pertinent WHOIS server.
        public string Whois { get; }

        /// Date of the last update of the WHOIS record in VirusTotal.
        public long WhoisDate { get; }
    }
}
