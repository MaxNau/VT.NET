using System.Text.Json.Serialization;

namespace VT.NET.Responses.Urls.Report
{
    /// <summary>
    /// Represents a tracker associated with the URL.
    /// </summary>
    public class Tracker
    {
        internal Tracker() { }

        [JsonConstructor]
        internal Tracker(string id, long timestamp, string url)
        {
            Id = id;
            Timestamp = timestamp;
            Url = url;
        }

        /// <summary>
        /// ID of the tracker, if available.
        /// </summary>
        public string Id { get; }

        /// <summary>
        /// Ingestion date of the tracker as a UNIX timestamp.
        /// </summary>
        public long Timestamp { get; }

        /// <summary>
        /// URL of the tracker script.
        /// </summary>
        public string Url { get; }
    }
}
