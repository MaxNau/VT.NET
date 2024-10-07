using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace VT.NET.Responses.Objects.Relationship.Whois
{
    /// <summary>
    /// Domain and IP addresses whois record attributes.
    /// </summary>
    public class WhoisObjectAttributes : VTObjectAttributes
    {
        internal WhoisObjectAttributes() { }

        [JsonConstructor]
        internal WhoisObjectAttributes(long firstSeenDate, Dictionary<string, string> whoisMap,
            long lastUpdated, string registrantCountry)
        {
            FirstSeenDate = firstSeenDate;
            WhoisMap = whoisMap;
            LastUpdated = lastUpdated;
            RegistrantCountry = registrantCountry;
        }

        /// <summary>
        /// Date the whois record was first retrieved by VirusTotal. UTC timestamp.
        /// </summary>
        public long FirstSeenDate { get; }

        /// <summary>
        /// dictionary containing all parsed fields from the whois.
        /// All keys and values are strings, if there are repeated fields in the whois information,
        /// these are appended in the same string using the | character as separator.
        /// All Registrant * data is anonymised to protect private people's identities but
        /// can be used to pivot. All * Date fields are in %Y-%m-%dT%H:%M:%SZ format.
        /// </summary>
        public Dictionary<string, string> WhoisMap { get; }

        /// <summary>
        /// Updated date field extracted from the whois record. UTC timestamp.
        /// </summary>
        public long LastUpdated { get; }

        /// <summary>
        /// Registrant Country
        /// </summary>
        public string RegistrantCountry { get; }
    }
}
