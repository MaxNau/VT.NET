using System.Text.Json.Serialization;

namespace VT.NET.Responses.Objects.Files.Related
{
    /// <summary>
    /// Context of the alert
    /// </summary>
    public class AlertContext
    {
        internal AlertContext() { }

        [JsonConstructor]
        internal AlertContext(string destIp, int destPort, string hostname, string protocol, string srcIp,
            int srcPort, string url)
        {
            DestIp = destIp;
            DestPort = destPort;
            Hostname = hostname;
            Protocol = protocol;
            SrcIp = srcIp;
            SrcPort = srcPort;
            Url = url;
        }

        /// <summary>
        /// Destination IP.
        /// </summary>
        public string DestIp { get; }

        /// <summary>
        /// Destination port.
        /// </summary>
        public int DestPort { get; }

        /// <summary>
        /// In case the alert is related to an HTTP event, destination hostname.
        /// </summary>
        public string Hostname { get; }

        /// <summary>
        /// Communication protocol.
        /// </summary>
        public string Protocol { get; }

        /// <summary>
        /// Source IP.
        /// </summary>
        public string SrcIp { get; }

        /// <summary>
        /// Source port.
        /// </summary>
        public int SrcPort { get; }

        /// <summary>
        /// In case the alert is related to an HTTP event, destination URL.
        /// </summary>
        public string Url { get; }
    }
}
