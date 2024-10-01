using System.Text.Json.Serialization;

namespace VT.NET.Responses.Domains.Report
{
    /// <summary>
    /// Represents a DNS record associated with a domain.
    /// This class contains various attributes of the DNS record, providing details about its configuration and properties.
    /// </summary>
    public class DnsRecord
    {
        internal DnsRecord() { }

        [JsonConstructor]
        internal DnsRecord(int expire, int flag, int minimum, int priority, int refresh, string rname,
            int retry, int serial, string tag, int ttl, string type, string value)
        {
            Expire = expire;
            Flag = flag;
            Minimum = minimum;
            Priority = priority;
            Refresh = refresh;
            Rname = rname;
            Retry = retry;
            Serial = serial;
            Tag = tag;
            Ttl = ttl;
            Type = type;
            Value = value;
        }

        /// <summary>
        /// Expiration date of the DNS record (in seconds).
        /// </summary>
        public int Expire { get; }

        /// <summary>
        /// Flag associated with the DNS record.
        /// </summary>
        public int Flag { get; }

        /// <summary>
        /// Minimum TTL for the DNS record.
        /// </summary>
        public int Minimum { get; }

        /// <summary>
        /// Priority of the DNS record (for records such as MX).
        /// </summary>
        public int Priority { get; }

        /// <summary>
        /// Refresh interval for the DNS record (in seconds).
        /// </summary>
        public int Refresh { get; }

        /// <summary>
        /// Responsible person's name (usually an email address).
        /// </summary>
        public string Rname { get; }

        /// <summary>
        /// Retry interval for the DNS record (in seconds).
        /// </summary>
        public int Retry { get; }

        /// <summary>
        /// Serial number of the DNS record.
        /// </summary>
        public int Serial { get; }

        /// <summary>
        /// Tag associated with the DNS record.
        /// </summary>
        public string Tag { get; }

        /// <summary>
        /// Time-to-live for the DNS record (in seconds).
        /// </summary>
        public int Ttl { get; }

        /// <summary>
        /// Type of the DNS record (e.g., A, AAAA, CNAME).
        /// </summary>
        public string Type { get; }

        /// <summary>
        /// Value of the DNS record (e.g., IP address for A records).
        /// </summary>
        public string Value { get; }
    }
}
