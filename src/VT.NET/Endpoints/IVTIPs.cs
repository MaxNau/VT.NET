﻿using System.Threading.Tasks;
using System.Threading;
using VT.NET.Responses.IPs.Report;
using VT.NET.Responses.Analysis;

namespace VT.NET.Endpoints
{
    /// <summary>
    /// Defines a contract for interacting with the VirusTotal IP Addresses API.
    /// Provides methods for rescanning IP Address and retrieving reports.
    /// </summary>
    public interface IVTIPs
    {
        /// <summary>
        /// Asynchronously retrieves the report for a specific IP address from the VirusTotal API.
        /// </summary>
        /// <param name="ipAddress">The IP address for which to retrieve the report.</param>
        /// <param name="cancellationToken">A cancellation token to cancel the operation, if needed.</param>
        /// <returns>A task representing the asynchronous operation, containing the IP report.</returns>
        Task<IPReport> GetReportAsync(string ipAddress, CancellationToken cancellationToken = default);

        /// <summary>
        /// Asynchronously rescans a specific IP address using the VirusTotal API.
        /// </summary>
        /// <param name="ipAddress">The IP address to rescan.</param>
        /// <param name="cancellationToken">A cancellation token to cancel the operation, if needed.</param>
        /// <returns>A task representing the asynchronous operation, containing the analysis result.</returns>
        Task<VTAnalysis> RescanAsync(string ipAddress, CancellationToken cancellationToken = default);
    }
}
