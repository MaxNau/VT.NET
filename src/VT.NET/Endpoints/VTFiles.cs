using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using VT.NET.Constants;
using VT.NET.Responses;
using VT.NET.Responses.Analysis;
using VT.NET.Responses.Files.Comments;
using VT.NET.Responses.Files.FileReport;
using VT.NET.Validators;

namespace VT.NET.Endpoints
{
    /// <summary>
    /// Provides methods for interacting with the VirusTotal Files API.
    /// </summary>
    /// <remarks>
    /// The <see cref="VTFiles"/> class implements the <see cref="IVTFiles"/> interface 
    /// and allows users to upload files, rescan files, and retrieve reports and comments 
    /// related to files in the VirusTotal service.
    /// </remarks>
    /// 
    public class VTFiles : VTEndpoint, IVTFiles
    {
        private readonly IValidator<string> _vtFileValidator;
        private readonly IValidator<Stream> _vtStreamValidator;
        private readonly IValidator<string> _hashValidator;

        /// <summary>
        /// Initializes a new instance of the <see cref="VTFiles"/> class.
        /// </summary>
        /// <param name="httpClient">The HTTP client used for making requests to the VirusTotal API.</param>
        /// <param name="apiKey">An optional API key for authenticating requests with the VirusTotal service.</param>
        public VTFiles(HttpClient httpClient, string apiKey = null) : base(httpClient, apiKey)
        {
            var validatorFactory = new ValidatorFactory();
            _vtFileValidator = validatorFactory.Get<string>(typeof(VTFileValidator));
            _vtStreamValidator = validatorFactory.Get<Stream>(typeof(StreamValidator));
            _hashValidator = validatorFactory.Get<string>(typeof(FileHashValidator));
        }

        /// <summary>
        /// Uploads a file to the VirusTotal service.
        /// </summary>
        /// <param name="filePath">The path to the file to upload.</param>
        /// <param name="password">An optional password for encrypted files, encoded in Base64.</param>
        /// <param name="forceUploadUrl">Indicates whether to force the upload URL to be used.</param>
        /// <param name="cancellationToken">A cancellation token to cancel the operation.</param>
        /// <returns>A task representing the asynchronous upload operation, with a result of type <see cref="VTAnalysis"/>.</returns>
        public async Task<VTAnalysis> UploadFileAsync(string filePath, string password = null, bool forceUploadUrl = false, CancellationToken cancellationToken = default)
        {
            var validationResult = _vtFileValidator.Validate(filePath);
            validationResult.ThrowIfAny();

            VTResponse<VTAnalysis> response = null;

            using (var fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.Read, 4096, true))
            {
                var fileName = Path.GetFileName(fileStream.Name);
                var endpoint = fileStream.Length == SupportedFileSizes.RegularFileSizeLimit && !forceUploadUrl
                    ? "files" : await GetUploadUrlAsync(cancellationToken).ConfigureAwait(false);

                response = await UploadFileAsync<VTResponse<VTAnalysis>>(endpoint, fileStream, fileName, password, cancellationToken).ConfigureAwait(false);
            }

            return response.Data;
        }

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
        public async Task<VTAnalysis> UploadFileAsync<T>(Stream stream, string filename, string password = null, bool forceUploadUrl = false, CancellationToken cancellationToken = default)
        {
            var validationResult = _vtStreamValidator.Validate(stream);
            validationResult.ThrowIfAny();

            VTResponse<VTAnalysis> response = null;
            var endpoint = stream.Length == SupportedFileSizes.RegularFileSizeLimit && !forceUploadUrl
                    ? "files" : await GetUploadUrlAsync(cancellationToken).ConfigureAwait(false);

            response = await UploadFileAsync<VTResponse<VTAnalysis>>(endpoint, stream, filename, password, cancellationToken).ConfigureAwait(false);

            return response.Data;
        }

        /// <summary>
        /// Rescans a previously submitted file by its identifier.
        /// </summary>
        /// <param name="id">The identifier of the file to rescan.</param>
        /// <param name="cancellationToken">A cancellation token to cancel the operation.</param>
        /// <returns>A task representing the asynchronous rescan operation, with a result of type <see cref="FileReport"/>.</returns>
        public async Task<VTAnalysis> RescanFileAsync(string id, CancellationToken cancellationToken = default)
        {
            var validationResult = _hashValidator.Validate(id);
            validationResult.ThrowIfAny();

            var response = await Self.GetAsync<VTResponse<VTAnalysis>>($"files/{id}/analyse", cancellationToken).ConfigureAwait(false);
            return response.Data;
        }

        /// <summary>
        /// Retrieves the report for a file using its identifier.
        /// </summary>
        /// <param name="id">The identifier of the file to retrieve the report for.</param>
        /// <param name="cancellationToken">A cancellation token to cancel the operation.</param>
        /// <returns>A task representing the asynchronous report retrieval operation, with a result of type <see cref="FileReport"/>.</returns>
        public async Task<FileReport> GetFileReportAsync(string id, CancellationToken cancellationToken = default)
        {
            var validationResult = _hashValidator.Validate(id);
            validationResult.ThrowIfAny();

            var response = await Self.GetAsync<VTResponse<FileReport>>($"files/{id}", cancellationToken).ConfigureAwait(false);
            return response.Data;
        }

        /// <summary>
        /// Retrieves comments associated with a file.
        /// </summary>
        /// <param name="id">The identifier of the file to get comments for.</param>
        /// <param name="limit">The maximum number of comments to retrieve.</param>
        /// <param name="cursor">A cursor for pagination, if applicable.</param>
        /// <param name="cancellationToken">A cancellation token to cancel the operation.</param>
        /// <returns>A task representing the asynchronous comment retrieval operation, with a result of type <see cref="VTPagedResponse{Comment}"/>.</returns>
        public async Task<VTPagedResponse<Comment>> GetFileCommentsAsync(string id, int limit = 10, string cursor = null, CancellationToken cancellationToken = default)
        {
            var validationResult = _hashValidator.Validate(id);
            validationResult.ThrowIfAny();

            return await Self.GetAsync<VTPagedResponse<Comment>>(string.IsNullOrWhiteSpace(cursor) ? $"files/{id}/comments?limit={limit}" : $"files/{id}/comments?limit={limit}&cursor={cursor}", cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Adds a comment to a file in the VirusTotal service.
        /// </summary>
        /// <param name="id">The identifier of the file to comment on.</param>
        /// <param name="comment">The text of the comment to add.</param>
        /// <param name="cancellationToken">A cancellation token to cancel the operation.</param>
        /// <returns>A task representing the asynchronous comment addition operation, with a result of type <see cref="Comment"/>.</returns>
        public async Task<Comment> AddFileCommentAsync(string id, string comment, CancellationToken cancellationToken = default)
        {
            var validationResult = _hashValidator.Validate(id);
            validationResult.ThrowIfAny();

            var json = JsonSerializer.Serialize(new VTResponse<CreateComment>(new CreateComment(comment)), new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase });
            using (var content = new StringContent(json))
            {
                var response = await Self.PostAsync<VTResponse<Comment>>($"files/{id}/comments", content, cancellationToken).ConfigureAwait(false);
                return response.Data;
            }
        }

        private async Task<T> UploadFileAsync<T>(string requestUri, Stream stream, string filename, string password = null, CancellationToken cancellationToken = default)
        {
            using (var formDataContent = new MultipartFormDataContent())
            {
                using (var streamContent = new StreamContent(stream))
                {
                    streamContent.Headers.ContentDisposition = new ContentDispositionHeaderValue("form-data")
                    {
                        Name = "file",
                        FileName = $"\"{filename}\""
                    };

                    formDataContent.Add(streamContent);

                    if (!string.IsNullOrEmpty(password))
                    {
                        var passwordContent = new StringContent(password);
                        passwordContent.Headers.ContentDisposition = new ContentDispositionHeaderValue("form-data")
                        {
                            Name = "password"
                        };
                        formDataContent.Add(passwordContent);
                    }

                    return await Self.PostAsync<T>(requestUri, formDataContent, cancellationToken).ConfigureAwait(false);
                }
            }
        }

        private async Task<string> GetUploadUrlAsync(CancellationToken cancellationToken)
        {
            var result = await Self.GetAsync<VTResponse<string>>("files/upload_url", cancellationToken).ConfigureAwait(false);
            return result.Data;
        }
    }
}
