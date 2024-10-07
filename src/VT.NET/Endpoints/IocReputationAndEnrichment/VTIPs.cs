using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using VT.NET.Responses;
using VT.NET.Responses.Objects.Analysis;
using VT.NET.Responses.Objects.IPs;
using VT.NET.Validators;

namespace VT.NET.Endpoints.IocReputationAndEnrichment
{
    /// <summary>
    /// Represents a client for interacting with the VirusTotal API specifically for IP addresses.
    /// Provides methods to retrieve reports and rescan IP addresses.
    /// </summary>
    public class VTIPs : VTEndpoint, IVTIPs
    {
        private readonly IValidator<string> _ipAddressValidator;
        /// <summary>
        /// Initializes a new instance of the <see cref="VTIPs"/> class.
        /// </summary>
        /// <param name="httpClient">The <see cref="HttpClient"/> used to make API requests.</param>
        /// <param name="apiKey">The API key for authenticating with the VirusTotal API.</param>
        public VTIPs(HttpClient httpClient, string apiKey) : base(httpClient, apiKey)
        {
            var validatorFactory = new ValidatorFactory();
            _ipAddressValidator = validatorFactory.Get<string>(typeof(IPAddressValidator));
        }

        /// <summary>
        /// Asynchronously retrieves the report for a specific IP address.
        /// </summary>
        /// <param name="ipAddress">The IP address to retrieve the report for.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> to cancel the operation if needed.</param>
        /// <returns>A task that represents the asynchronous operation, containing the <see cref="IpAddressObject"/> for the specified IP address.</returns>
        public async Task<IpAddressObject> GetReportAsync(string ipAddress, CancellationToken cancellationToken = default)
        {
            var validationResult = _ipAddressValidator.Validate(ipAddress);
            validationResult.ThrowIfAny();

            var result = await Self.GetAsync<VTResponse<IpAddressObject>>($"ip_addresses/{ipAddress}", cancellationToken).ConfigureAwait(false);
            return result.Data;
        }

        /// <summary>
        /// Asynchronously rescans a specific IP address to get the latest analysis.
        /// </summary>
        /// <param name="ipAddress">The IP address to rescan.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> to cancel the operation if needed.</param>
        /// <returns>A task that represents the asynchronous operation, containing the <see cref="AnalysisObject"/> of the rescan.</returns>
        public async Task<AnalysisObject> RescanAsync(string ipAddress, CancellationToken cancellationToken = default)
        {
            var validationResult = _ipAddressValidator.Validate(ipAddress);
            validationResult.ThrowIfAny();

            var result = await Self.PostAsync<VTResponse<AnalysisObject>>($"ip_addresses/{ipAddress}/analyse", null, cancellationToken).ConfigureAwait(false);
            return result.Data;
        }
    }
}
