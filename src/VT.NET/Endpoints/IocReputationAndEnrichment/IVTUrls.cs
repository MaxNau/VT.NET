using System.Threading.Tasks;
using System.Threading;
using System;
using VT.NET.Responses.Objects.Analysis;
using VT.NET.Responses.Objects.Urls;

namespace VT.NET.Endpoints.IocReputationAndEnrichment
{
    /// <summary>
    /// Defines a contract for interacting with the VirusTotal URLs API.
    /// Provides methods for scanning URLs, retrieving reports, and rescanning URLs.
    /// </summary>
    public interface IVTUrls
    {
        /// <summary>
        /// Scans the specified URL for threats.
        /// </summary>
        /// <param name="url">The URL to be scanned. Must not be null.</param>
        /// <param name="cancellationToken">A token to cancel the operation, if needed.</param>
        /// <returns>
        /// A task representing the asynchronous operation, containing the analysis result of the scanned URL.
        /// </returns>
        /// <exception cref="ArgumentNullException">Thrown when the <paramref name="url"/> is null.</exception>
        Task<AnalysisObject> ScanAsync(Uri url, CancellationToken cancellationToken = default);

        /// <summary>
        /// Retrieves the report for the specified URL.
        /// </summary>
        /// <param name="url">The URL for which to retrieve the report. Must not be null.</param>
        /// <param name="cancellationToken">A token to cancel the operation, if needed.</param>
        /// <returns>
        /// A task representing the asynchronous operation, containing the URL report.
        /// </returns>
        /// <exception cref="ArgumentNullException">Thrown when the <paramref name="url"/> is null.</exception>
        Task<UrlObject> GetReportAsync(Uri url, CancellationToken cancellationToken = default);

        /// <summary>
        /// Retrieves the report for a given URL identifier or Base64 representation.
        /// </summary>
        /// <param name="id">The URL identifier or Base64 representation of the URL (without padding).</param>
        /// <param name="cancellationToken">A token to cancel the operation, if needed.</param>
        /// <returns>
        /// A task representing the asynchronous operation, containing the URL report.
        /// </returns>
        Task<UrlObject> GetReportAsync(string id, CancellationToken cancellationToken = default);

        /// <summary>
        /// Rescans the specified URL for threats.
        /// </summary>
        /// <param name="url">The URL to be rescanned. Must not be null.</param>
        /// <param name="cancellationToken">A token to cancel the operation, if needed.</param>
        /// <returns>
        /// A task representing the asynchronous operation, containing the analysis result of the rescanned URL.
        /// </returns>
        /// <exception cref="ArgumentNullException">Thrown when the <paramref name="url"/> is null.</exception>
        Task<AnalysisObject> RescanAsync(Uri url, CancellationToken cancellationToken = default);

        /// <summary>
        /// Rescans a given URL identifier or Base64 representation.
        /// </summary>
        /// <param name="id">The URL identifier or Base64 representation of the URL (without padding).</param>
        /// <param name="cancellationToken">A token to cancel the operation, if needed.</param>
        /// <returns>
        /// A task representing the asynchronous operation, containing the analysis result of the rescanned URL.
        /// </returns>
        Task<AnalysisObject> RescanAsync(string id, CancellationToken cancellationToken = default);
    }
}
