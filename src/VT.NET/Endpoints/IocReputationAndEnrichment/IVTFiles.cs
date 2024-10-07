using System.Threading.Tasks;
using System.Threading;
using System.IO;
using VT.NET.Responses.Objects.Analysis;
using VT.NET.Responses.Objects.Files;

namespace VT.NET.Endpoints.IocReputationAndEnrichment
{
    /// <summary>
    /// Defines the methods for interacting with the VirusTotal Files API.
    /// </summary>
    /// <remarks>
    /// The <see cref="IVTFiles"/> interface provides operations for uploading files, 
    /// rescanning files, retrieving file reports, and managing file comments in the 
    /// VirusTotal service.
    /// </remarks>
    public interface IVTFiles
    {
        /// <summary>
        /// Uploads a file to the VirusTotal service.
        /// </summary>
        /// <param name="filePath">The path to the file to upload.</param>
        /// <param name="password">An optional password for encrypted files, encoded in Base64.</param>
        /// <param name="forceUploadUrl">Indicates whether to force the upload URL to be used.</param>
        /// <param name="cancellationToken">A cancellation token to cancel the operation.</param>
        /// <returns>A task representing the asynchronous upload operation, with a result of type <see cref="AnalysisObject"/>.</returns>
        Task<AnalysisObject> UploadFileAsync(string filePath, string password = null, bool forceUploadUrl = false, CancellationToken cancellationToken = default);

        /// <summary>
        /// Uploads a file as a stream to the VirusTotal service.
        /// </summary>
        /// <typeparam name="T">The type of the file object.</typeparam>
        /// <param name="stream">The stream containing the file data.</param>
        /// <param name="filename">The name of the file being uploaded.</param>
        /// <param name="password">An optional password for encrypted files, encoded in Base64.</param>
        /// <param name="forceUploadUrl">Indicates whether to force the upload URL to be used.</param>
        /// <param name="cancellationToken">A cancellation token to cancel the operation.</param>
        /// <returns>A task representing the asynchronous upload operation, with a result of type <see cref="AnalysisObject"/>.</returns>
        Task<AnalysisObject> UploadFileAsync<T>(Stream stream, string filename, string password, bool forceUploadUrl = false, CancellationToken cancellationToken = default);

        /// <summary>
        /// Rescans a previously submitted file by its identifier.
        /// </summary>
        /// <param name="id">The identifier of the file to rescan.</param>
        /// <param name="cancellationToken">A cancellation token to cancel the operation.</param>
        /// <returns>A task representing the asynchronous rescan operation, with a result of type <see cref="FileObject"/>.</returns>
        Task<AnalysisObject> RescanFileAsync(string id, CancellationToken cancellationToken = default);

        /// <summary>
        /// Retrieves the report for a file using its identifier.
        /// </summary>
        /// <param name="id">The identifier of the file to retrieve the report for.</param>
        /// <param name="cancellationToken">A cancellation token to cancel the operation.</param>
        /// <returns>A task representing the asynchronous report retrieval operation, with a result of type <see cref="FileObject"/>.</returns>
        Task<FileObject> GetFileReportAsync(string id, CancellationToken cancellationToken = default);
    }
}
