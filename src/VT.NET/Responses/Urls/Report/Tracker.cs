namespace VT.NET.Responses.Urls.Report
{
    /// <summary>
    /// Represents a tracker associated with the URL.
    /// </summary>
    public class Tracker
    {
        /// <summary>
        /// Gets or sets the ID of the tracker, if available.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets the ingestion date of the tracker as a UNIX timestamp.
        /// </summary>
        public long Timestamp { get; set; }

        /// <summary>
        /// Gets or sets the URL of the tracker script.
        /// </summary>
        public string Url { get; set; }
    }
}
