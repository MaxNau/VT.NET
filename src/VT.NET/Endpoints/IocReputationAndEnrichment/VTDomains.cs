using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using VT.NET.Responses;
using VT.NET.Responses.Objects.Analysis;
using VT.NET.Responses.Objects.Domains;
using VT.NET.Responses.Objects.Domains.Resolution;

namespace VT.NET.Endpoints.IocReputationAndEnrichment
{
    /// <summary>
    /// Provides methods for interacting with the VirusTotal Domains API.
    /// This class allows you to retrieve reports, rescan domains, and get resolution details.
    /// </summary>
    public class VTDomains : VTEndpoint, IVTDomains
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="VTDomains"/> class.
        /// </summary>
        /// <param name="httpClient">The HTTP client used for making requests to the API.</param>
        /// <param name="apiKey">The API key for authenticating with the VirusTotal API.</param>
        public VTDomains(HttpClient httpClient, string apiKey) : base(httpClient, apiKey)
        {
        }

        /// <summary>
        /// Retrieves the report for a specified domain.
        /// </summary>
        /// <param name="domain">The domain for which the report is to be retrieved.</param>
        /// <param name="cancellationToken">A cancellation token to cancel the operation, if needed.</param>
        /// <returns>A task representing the asynchronous operation, with a <see cref="DomainObject"/> as the result.</returns>
        public async Task<DomainObject> GetReportAsync(string domain, CancellationToken cancellationToken = default)
        {
            var result = await Self.GetAsync<VTResponse<DomainObject>>($"domains/{domain}", cancellationToken).ConfigureAwait(false);
            return result.Data;
        }

        /// <summary>
        /// Rescans a specified domain for analysis.
        /// </summary>
        /// <param name="domain">The domain to rescan.</param>
        /// <param name="cancellationToken">A cancellation token to cancel the operation, if needed.</param>
        /// <returns>A task representing the asynchronous operation, with a <see cref="AnalysisObject"/> as the result.</returns>
        public async Task<AnalysisObject> RescanAsync(string domain, CancellationToken cancellationToken = default)
        {
            var result = await Self.PostAsync<VTResponse<AnalysisObject>>($"domains/{domain}/analyse", null, cancellationToken).ConfigureAwait(false);
            return result.Data;
        }


        /// <summary>
        /// Retrieves the resolution details for a specified resolution object ID.
        /// A resolution object ID is made by appending the IP and the domain it resolves to.
        /// </summary>
        /// <param name="id">The resolution object ID to retrieve.</param>
        /// <param name="cancellationToken">A cancellation token to cancel the operation, if needed.</param>
        /// <returns>A task representing the asynchronous operation, with a <see cref="ResolutionObject"/> as the result.</returns>
        public async Task<ResolutionObject> GetResolutionAsync(string id, CancellationToken cancellationToken = default)
        {
            var result = await Self.GetAsync<VTResponse<ResolutionObject>>($"resolutions/{id}", cancellationToken).ConfigureAwait(false);
            return result.Data;
        }
    }
}
