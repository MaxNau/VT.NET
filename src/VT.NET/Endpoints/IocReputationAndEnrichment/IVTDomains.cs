using System.Threading.Tasks;
using System.Threading;
using VT.NET.Responses.Objects.Analysis;
using VT.NET.Responses.Objects.Domains;
using VT.NET.Responses.Objects.Domains.Resolution;

namespace VT.NET.Endpoints.IocReputationAndEnrichment
{
    /// <summary>
    /// Defines a contract for interacting with the VirusTotal domains API.
    /// Provides methods for retrieving domain reports, domain resolutions, and rescanning domains.
    /// </summary>
    public interface IVTDomains
    {
        /// <summary>
        /// Asynchronously retrieves a report for the specified domain.
        /// </summary>
        /// <param name="domain">The domain to retrieve the report for.</param>
        /// <param name="cancellationToken">A cancellation token to cancel the operation.</param>
        /// <returns>A task representing the asynchronous operation, containing the domain report.</returns>
        Task<DomainObject> GetReportAsync(string domain, CancellationToken cancellationToken = default);

        /// <summary>
        /// Asynchronously rescans the specified domain.
        /// </summary>
        /// <param name="domain">The domain to rescan.</param>
        /// <param name="cancellationToken">A cancellation token to cancel the operation.</param>
        /// <returns>A task representing the asynchronous operation, containing the analysis result.</returns>
        Task<AnalysisObject> RescanAsync(string domain, CancellationToken cancellationToken = default);

        /// <summary>
        /// Asynchronously retrieves a resolution report by its ID.
        /// </summary>
        /// <param name="id">The unique identifier for the resolution report.</param>
        /// <param name="cancellationToken">A cancellation token to cancel the operation.</param>
        /// <returns>A task representing the asynchronous operation, containing the resolution report.</returns>
        Task<ResolutionObject> GetResolutionAsync(string id, CancellationToken cancellationToken = default);
    }
}
