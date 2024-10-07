using System.Collections.Generic;
using System.Text.Json.Serialization;
using VT.NET.Responses.Objects.Vote;
using VT.NET.Responses.Objects.Analysis;

namespace VT.NET.Responses.Objects.Urls
{
    /// <summary>
    /// Represents the attributes associated with a URL in the VirusTotal API response.
    /// This class contains various metadata and analysis results related to the URL.
    /// </summary>
    public class UrlObjectAttributes : VTScannedObjectAttributes
    {
        internal UrlObjectAttributes() { }

        [JsonConstructor]
        internal UrlObjectAttributes(int timesSubmitted, string lastHttpResponseContentSha256,
            long lastHttpResponseContentLength, Dictionary<string, string> lastHttpResponseHeaders,
            Dictionary<string, List<string>> htmlMeta, string url, long lastSubmissionDate,
            Dictionary<string, string> categories, List<object> threatNames, string lastFinalUrl,
            List<string> redirectionChain, List<string> outgoingLinks, int lastHttpResponseCode, string tld,
            long firstSubmissionDate, Dictionary<string, List<Tracker>> trackers, string title,
            Dictionary<string, string> lastHttpResponseCookies, Dictionary<string, string> targetedBrand,
            long lastAnalysisDate, long lastModificationDate,
            Dictionary<string, LastAnalysisResult> lastAnalysisResults, LastAnalysisStats lastAnalysisStats,
            TotalVotes totalVotes, long reputation, List<string> tags)
            : base(lastAnalysisDate, lastModificationDate, lastAnalysisResults, lastAnalysisStats,
                 totalVotes, reputation, tags)
        {
            Categories = categories;
            FirstSubmissionDate = firstSubmissionDate;
            HtmlMeta = htmlMeta;
            LastFinalUrl = lastFinalUrl;
            LastHttpResponseCode = lastHttpResponseCode;
            LastHttpResponseContentLength = lastHttpResponseContentLength;
            LastHttpResponseContentSha256 = lastHttpResponseContentSha256;
            LastHttpResponseCookies = lastHttpResponseCookies;
            LastHttpResponseHeaders = lastHttpResponseHeaders;
            LastSubmissionDate = lastSubmissionDate;
            OutgoingLinks = outgoingLinks;
            RedirectionChain = redirectionChain;
            TargetedBrand = targetedBrand;
            TimesSubmitted = timesSubmitted;
            Title = title;
            Trackers = trackers;
            Url = url;
            ThreatNames = threatNames;
            Tld = tld;
        }

        /// <summary>
        /// Dictionary of categories from partners categorizing the URL.
        /// </summary>
        public Dictionary<string, string> Categories { get; }

        /// <summary>
        /// UTC timestamp of the first submission date.
        /// </summary>
        public long FirstSubmissionDate { get; }

        /// <summary>
        /// Dictionary of HTML meta tags.
        /// </summary>
        public Dictionary<string, List<string>> HtmlMeta { get; }

        /// <summary>
        /// Final URL if the original URL redirects.
        /// </summary>
        public string LastFinalUrl { get; }

        /// <summary>
        /// HTTP response code of the last response.
        /// </summary>
        public int LastHttpResponseCode { get; }

        /// <summary>
        /// Content length of the last HTTP response.
        /// </summary>
        public long LastHttpResponseContentLength { get; }

        /// <summary>
        /// SHA256 hash of the URL response body.
        /// </summary>
        public string LastHttpResponseContentSha256 { get; }

        /// <summary>
        /// Dictionary containing the website's cookies.
        /// </summary>
        public Dictionary<string, string> LastHttpResponseCookies { get; }

        /// <summary>
        /// Dictionary containing the headers of the last HTTP response.
        /// </summary>
        public Dictionary<string, string> LastHttpResponseHeaders { get; }

        /// <summary>
        /// UTC timestamp of the last submission date.
        /// </summary>
        public long LastSubmissionDate { get; }

        /// <summary>
        /// List of outgoing links.
        /// </summary>
        public List<string> OutgoingLinks { get; }

        /// <summary>
        /// List of redirection chains.
        /// </summary>
        public List<string> RedirectionChain { get; }

        /// <summary>
        /// Dictionary with targeted brand information.
        /// </summary>
        public Dictionary<string, string> TargetedBrand { get; }

        /// <summary>
        /// Number of times the URL has been submitted for analysis.
        /// </summary>
        public int TimesSubmitted { get; }

        /// <summary>
        /// Title of the webpage.
        /// </summary>
        public string Title { get; }

        /// <summary>
        /// Dictionary of trackers found in the URL.
        /// </summary>
        public Dictionary<string, List<Tracker>> Trackers { get; }

        /// <summary>
        /// Original URL being scanned.
        /// </summary>
        public string Url { get; }

        /// <summary>
        /// Threat names associated with url.
        /// </summary>
        public List<object> ThreatNames { get; }

        /// <summary>
        /// Top-level domain (TLD) associated with the URL.
        /// </summary>
        /// <remarks>
        /// The TLD represents the last segment of the domain name, providing insight into the
        /// domain's categorization and geographical relevance. Examples include ".com", ".org",
        /// ".net", etc.
        /// </remarks>
        public string Tld { get; }
    }
}
