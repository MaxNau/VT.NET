using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;
using VT.NET.Constants;
using VT.NET.Responses;
using VT.NET.Responses.Objects.Analysis;
using VT.NET.Responses.Objects.Files;
using VT.NET.Validators;

namespace VT.NET.Endpoints.IocReputationAndEnrichment
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
        /// <returns>A task representing the asynchronous upload operation, with a result of type <see cref="AnalysisObject"/>.</returns>
        public async Task<AnalysisObject> UploadFileAsync(string filePath, string password = null, bool forceUploadUrl = false, CancellationToken cancellationToken = default)
        {
            var validationResult = _vtFileValidator.Validate(filePath);
            validationResult.ThrowIfAny();

            VTResponse<AnalysisObject> response = null;

            using (var fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.Read, 4096, true))
            {
                var fileName = Path.GetFileName(fileStream.Name);
                var endpoint = fileStream.Length == SupportedFileSizes.RegularFileSizeLimit && !forceUploadUrl
                    ? "files" : await GetUploadUrlAsync(cancellationToken).ConfigureAwait(false);

                response = await UploadFileAsync<VTResponse<AnalysisObject>>(endpoint, fileStream, fileName, password, cancellationToken).ConfigureAwait(false);
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
        /// <returns>A task representing the asynchronous upload operation, with a result of type <see cref="AnalysisObject"/>.</returns>
        public async Task<AnalysisObject> UploadFileAsync<T>(Stream stream, string filename, string password = null, bool forceUploadUrl = false, CancellationToken cancellationToken = default)
        {
            var validationResult = _vtStreamValidator.Validate(stream);
            validationResult.ThrowIfAny();

            VTResponse<AnalysisObject> response = null;
            var endpoint = stream.Length == SupportedFileSizes.RegularFileSizeLimit && !forceUploadUrl
                    ? "files" : await GetUploadUrlAsync(cancellationToken).ConfigureAwait(false);

            response = await UploadFileAsync<VTResponse<AnalysisObject>>(endpoint, stream, filename, password, cancellationToken).ConfigureAwait(false);

            return response.Data;
        }

        /// <summary>
        /// Rescans a previously submitted file by its identifier.
        /// </summary>
        /// <param name="id">The identifier of the file to rescan.</param>
        /// <param name="cancellationToken">A cancellation token to cancel the operation.</param>
        /// <returns>A task representing the asynchronous rescan operation, with a result of type <see cref="FileObject"/>.</returns>
        public async Task<AnalysisObject> RescanFileAsync(string id, CancellationToken cancellationToken = default)
        {
            var validationResult = _hashValidator.Validate(id);
            validationResult.ThrowIfAny();

            var response = await Self.GetAsync<VTResponse<AnalysisObject>>($"files/{id}/analyse", cancellationToken).ConfigureAwait(false);
            return response.Data;
        }

        /// <summary>
        /// Retrieves the report for a file using its identifier.
        /// </summary>
        /// <param name="id">The identifier of the file to retrieve the report for.</param>
        /// <param name="cancellationToken">A cancellation token to cancel the operation.</param>
        /// <returns>A task representing the asynchronous report retrieval operation, with a result of type <see cref="FileObject"/>.</returns>
        public async Task<FileObject> GetFileReportAsync(string id, CancellationToken cancellationToken = default)
        {
            var validationResult = _hashValidator.Validate(id);
            validationResult.ThrowIfAny();

            var response = await Self.GetAsync<VTResponse<FileObject>>($"files/{id}", cancellationToken).ConfigureAwait(false);
            return response.Data;
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
