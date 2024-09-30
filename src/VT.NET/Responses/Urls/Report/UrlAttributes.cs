using System.Collections.Generic;
using VT.NET.Responses.Files.FileReport;
using VT.NET.Responses.Analysis;

namespace VT.NET.Responses.Urls.Report
{
    /// <summary>
    /// Represents the attributes associated with a URL in the VirusTotal API response.
    /// This class contains various metadata and analysis results related to the URL.
    /// </summary>
    public class UrlAttributes
    {
        /// <summary>
        /// Gets or sets a dictionary of categories from partners categorizing the URL.
        /// </summary>
        public Dictionary<string, string> Categories { get; set; }

        /// <summary>
        /// Gets or sets the UTC timestamp of the first submission date.
        /// </summary>
        public long FirstSubmissionDate { get; set; }

        /// <summary>
        /// Gets or sets a dictionary of HTML meta tags.
        /// </summary>
        public Dictionary<string, List<string>> HtmlMeta { get; set; }

        /// <summary>
        /// Gets or sets the UTC timestamp of the last analysis date.
        /// </summary>
        public long LastAnalysisDate { get; set; }

        /// <summary>
        /// Gets or sets a dictionary of results from URL scanners.
        /// </summary>
        public Dictionary<string, LastAnalysisResult> LastAnalysisResults { get; set; }

        /// <summary>
        /// Gets or sets the statistics of the last analysis results.
        /// </summary>
        public LastAnalysisStats LastAnalysisStats { get; set; }

        /// <summary>
        /// Gets or sets the final URL if the original URL redirects.
        /// </summary>
        public string LastFinalUrl { get; set; }

        /// <summary>
        /// Gets or sets the HTTP response code of the last response.
        /// </summary>
        public int LastHttpResponseCode { get; set; }

        /// <summary>
        /// Gets or sets the content length of the last HTTP response.
        /// </summary>
        public int LastHttpResponseContentLength { get; set; }

        /// <summary>
        /// Gets or sets the SHA256 hash of the URL response body.
        /// </summary>
        public string LastHttpResponseContentSha256 { get; set; }

        /// <summary>
        /// Gets or sets a dictionary containing the website's cookies.
        /// </summary>
        public Dictionary<string, string> LastHttpResponseCookies { get; set; }

        /// <summary>
        /// Gets or sets a dictionary containing the headers of the last HTTP response.
        /// </summary>
        public Dictionary<string, string> LastHttpResponseHeaders { get; set; }

        /// <summary>
        /// Gets or sets the UTC timestamp of the last modification date.
        /// </summary>
        public long LastModificationDate { get; set; }

        /// <summary>
        /// Gets or sets the UTC timestamp of the last submission date.
        /// </summary>
        public long LastSubmissionDate { get; set; }

        /// <summary>
        /// Gets or sets a list of outgoing links.
        /// </summary>
        public List<string> OutgoingLinks { get; set; }

        /// <summary>
        /// Gets or sets a list of redirection chains.
        /// </summary>
        public List<string> RedirectionChain { get; set; }

        /// <summary>
        /// Gets or sets the reputation score of the URL.
        /// </summary>
        public int Reputation { get; set; }

        /// <summary>
        /// Gets or sets a list of tags associated with the URL.
        /// </summary>
        public List<string> Tags { get; set; }

        /// <summary>
        /// Gets or sets a dictionary with targeted brand information.
        /// </summary>
        public Dictionary<string, string> TargetedBrand { get; set; }

        /// <summary>
        /// Gets or sets the number of times the URL has been submitted for analysis.
        /// </summary>
        public int TimesSubmitted { get; set; }

        /// <summary>
        /// Gets or sets the title of the webpage.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets a dictionary containing total votes received for the URL.
        /// </summary>
        public TotalVotes TotalVotes { get; set; }

        /// <summary>
        /// Gets or sets a dictionary of trackers found in the URL.
        /// </summary>
        public Dictionary<string, List<Tracker>> Trackers { get; set; }

        /// <summary>
        /// Gets or sets the original URL being scanned.
        /// </summary>
        public string Url { get; set; }
    }
}
