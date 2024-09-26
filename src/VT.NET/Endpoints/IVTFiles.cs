using System.Threading.Tasks;
using System.Threading;
using System.IO;
using VT.NET.Responses.Files.FileReport;
using VT.NET.Responses.Files.Comments;
using VT.NET.Responses;
using VT.NET.Responses.Files;

namespace VT.NET.Endpoints
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
        /// <returns>A task representing the asynchronous upload operation, with a result of type <see cref="VTAnalysis"/>.</returns>
        Task<VTAnalysis> UploadFileAsync(string filePath, string password = null, bool forceUploadUrl = false, CancellationToken cancellationToken = default);

        /// <summary>
        /// Uploads a file as a stream to the VirusTotal service.
        /// </summary>
        /// <typeparam name="T">The type of the file object.</typeparam>
        /// <param name="stream">The stream containing the file data.</param>
        /// <param name="filename">The name of the file being uploaded.</param>
        /// <param name="password">An optional password for encrypted files, encoded in Base64.</param>
        /// <param name="forceUploadUrl">Indicates whether to force the upload URL to be used.</param>
        /// <param name="cancellationToken">A cancellation token to cancel the operation.</param>
        /// <returns>A task representing the asynchronous upload operation, with a result of type <see cref="VTAnalysis"/>.</returns>
        Task<VTAnalysis> UploadFileAsync<T>(Stream stream, string filename, string password, bool forceUploadUrl = false, CancellationToken cancellationToken = default);

        /// <summary>
        /// Rescans a previously submitted file by its identifier.
        /// </summary>
        /// <param name="id">The identifier of the file to rescan.</param>
        /// <param name="cancellationToken">A cancellation token to cancel the operation.</param>
        /// <returns>A task representing the asynchronous rescan operation, with a result of type <see cref="FileReport"/>.</returns>
        Task<VTAnalysis> RescanFile(string id, CancellationToken cancellationToken = default);

        /// <summary>
        /// Retrieves the report for a file using its identifier.
        /// </summary>
        /// <param name="id">The identifier of the file to retrieve the report for.</param>
        /// <param name="cancellationToken">A cancellation token to cancel the operation.</param>
        /// <returns>A task representing the asynchronous report retrieval operation, with a result of type <see cref="FileReport"/>.</returns>
        Task<FileReport> GetFileReportAsync(string id, CancellationToken cancellationToken = default);

        /// <summary>
        /// Retrieves comments associated with a file.
        /// </summary>
        /// <param name="id">The identifier of the file to get comments for.</param>
        /// <param name="limit">The maximum number of comments to retrieve.</param>
        /// <param name="cursor">A cursor for pagination, if applicable.</param>
        /// <param name="cancellationToken">A cancellation token to cancel the operation.</param>
        /// <returns>A task representing the asynchronous comment retrieval operation, with a result of type <see cref="VTPagedResponse{Comment}"/>.</returns>
        Task<VTPagedResponse<Comment>> GetFileComments(string id, int limit = 10, string cursor = null, CancellationToken cancellationToken = default);

        /// <summary>
        /// Adds a comment to a file in the VirusTotal service.
        /// </summary>
        /// <param name="id">The identifier of the file to comment on.</param>
        /// <param name="comment">The text of the comment to add.</param>
        /// <param name="cancellationToken">A cancellation token to cancel the operation.</param>
        /// <returns>A task representing the asynchronous comment addition operation, with a result of type <see cref="Comment"/>.</returns>
        Task<Comment> AddFileComment(string id, string comment, CancellationToken cancellationToken);
    }
}
