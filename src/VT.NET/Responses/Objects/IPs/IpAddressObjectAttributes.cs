using System.Collections.Generic;
using System.Text.Json.Serialization;
using VT.NET.Responses.Objects;
using VT.NET.Responses.Objects.Analysis;
using VT.NET.Responses.Objects.Vote;

namespace VT.NET.Responses.Objects.IPs
{
    /// <summary>
    /// Represents the attributes associated with IP address in the VirusTotal API response.
    /// This class contains various metadata and analysis results related to the IP address.
    /// </summary>
    public class IpAddressObjectAttributes : VTScannedObjectAttributes
    {
        internal IpAddressObjectAttributes() { }

        [JsonConstructor]
        internal IpAddressObjectAttributes(string asOwner, int? asn, string continent, string country, string jarm,
            string lastHttpsCertificate, long? lastHttpsCertificateDate, long lastAnalysisDate,
            long lastModificationDate, string network, string regionalInternetRegistry,
            Dictionary<string, LastAnalysisResult> lastAnalysisResults, LastAnalysisStats lastAnalysisStats,
            TotalVotes totalVotes, long reputation, List<string> tags, string whois, long whoisDate)
            : base(lastAnalysisDate, lastModificationDate, lastAnalysisResults, lastAnalysisStats,
                 totalVotes, reputation, tags)
        {
            AsOwner = asOwner;
            Asn = asn;
            Continent = continent;
            Country = country;
            Jarm = jarm;
            LastHttpsCertificate = lastHttpsCertificate;
            LastHttpsCertificateDate = lastHttpsCertificateDate;
            Network = network;
            RegionalInternetRegistry = regionalInternetRegistry;
            Whois = whois;
            WhoisDate = whoisDate;
        }

        /// Owner of the Autonomous System to which the IP belongs.
        public string AsOwner { get; }

        /// Autonomous System Number to which the IP belongs.
        public int? Asn { get; }

        /// Continent where the IP is placed (ISO-3166 continent code).
        public string Continent { get; }

        /// Country where the IP is placed (ISO-3166 country code).
        public string Country { get; }

        /// JARM hash of the IP address.
        public string Jarm { get; }

        /// SSL Certificate object information for the IP.
        public string LastHttpsCertificate { get; } // Assume this will be further defined

        /// Date when the last HTTPS certificate was retrieved.
        public long? LastHttpsCertificateDate { get; }

        /// IP network range to which the IP belongs.
        public string Network { get; }

        /// Regional Internet Registry (RIR) for the IP.
        public string RegionalInternetRegistry { get; }

        /// WHOIS information as returned from the pertinent WHOIS server.
        public string Whois { get; }

        /// Date of the last update of the WHOIS record in VirusTotal.
        public long WhoisDate { get; }
    }
}
