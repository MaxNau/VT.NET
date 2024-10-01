using System.Collections.Generic;
using VT.NET.Responses.Files.FileReport;
using VT.NET.Responses.Analysis;
using System.Text.Json.Serialization;

namespace VT.NET.Responses.Urls.Report
{
    /// <summary>
    /// Represents the attributes associated with a URL in the VirusTotal API response.
    /// This class contains various metadata and analysis results related to the URL.
    /// </summary>
    public class UrlAttributes
    {
        internal UrlAttributes() { }

        [JsonConstructor]
        internal UrlAttributes(Dictionary<string, string> categories, long firstSubmissionDate,
            Dictionary<string, List<string>> htmlMeta, long lastAnalysisDate,
            Dictionary<string, LastAnalysisResult> lastAnalysisResults,
            LastAnalysisStats lastAnalysisStats, string lastFinalUrl,
            int lastHttpResponseCode, int lastHttpResponseContentLength,
            string lastHttpResponseContentSha256, Dictionary<string, string> lastHttpResponseCookies,
            Dictionary<string, string> lastHttpResponseHeaders, long lastModificationDate,
            long lastSubmissionDate, List<string> outgoingLinks, List<string> redirectionChain,
            int reputation, List<string> tags, Dictionary<string, string> targetedBrand,
            int timesSubmitted, string title, TotalVotes totalVotes,
            Dictionary<string, List<Tracker>> trackers, string url)
        {
            Categories = categories;
            FirstSubmissionDate = firstSubmissionDate;
            HtmlMeta = htmlMeta;
            LastAnalysisDate = lastAnalysisDate;
            LastAnalysisResults = lastAnalysisResults;
            LastAnalysisStats = lastAnalysisStats;
            LastFinalUrl = lastFinalUrl;
            LastHttpResponseCode = lastHttpResponseCode;
            LastHttpResponseContentLength = lastHttpResponseContentLength;
            LastHttpResponseContentSha256 = lastHttpResponseContentSha256;
            LastHttpResponseCookies = lastHttpResponseCookies;
            LastHttpResponseHeaders = lastHttpResponseHeaders;
            LastModificationDate = lastModificationDate;
            LastSubmissionDate = lastSubmissionDate;
            OutgoingLinks = outgoingLinks;
            RedirectionChain = redirectionChain;
            Reputation = reputation;
            Tags = tags;
            TargetedBrand = targetedBrand;
            TimesSubmitted = timesSubmitted;
            Title = title;
            TotalVotes = totalVotes;
            Trackers = trackers;
            Url = url;
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
        /// UTC timestamp of the last analysis date.
        /// </summary>
        public long LastAnalysisDate { get; }

        /// <summary>
        /// Dictionary of results from URL scanners.
        /// </summary>
        public Dictionary<string, LastAnalysisResult> LastAnalysisResults { get; }

        /// <summary>
        /// Statistics of the last analysis results.
        /// </summary>
        public LastAnalysisStats LastAnalysisStats { get; }

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
        public int LastHttpResponseContentLength { get; }

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
        /// UTC timestamp of the last modification date.
        /// </summary>
        public long LastModificationDate { get; }

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
        /// Reputation score of the URL.
        /// </summary>
        public int Reputation { get; }

        /// <summary>
        /// List of tags associated with the URL.
        /// </summary>
        public List<string> Tags { get; }

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
        /// Dictionary containing total votes received for the URL.
        /// </summary>
        public TotalVotes TotalVotes { get; }

        /// <summary>
        /// Dictionary of trackers found in the URL.
        /// </summary>
        public Dictionary<string, List<Tracker>> Trackers { get; }

        /// <summary>
        /// Original URL being scanned.
        /// </summary>
        public string Url { get; }
    }
}
