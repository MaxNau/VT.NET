using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using VT.NET.Constants;
using VT.NET.Http;
using VT.NET.Responses;
using VT.NET.Responses.Files.Comments;
using VT.NET.Responses.Files.FileReport;
using VT.NET.Responses.Files.UploadFile;
using VT.NET.Validators;

namespace VT.NET.Endpoints
{
    public class VTFiles : RestClient, IVTFiles
    {
        private readonly IValidator<string> _vtFileValidator;
        private readonly IValidator<Stream> _vtStreamValidator;
        private readonly IValidator<string> _hashValidator;

        public VTFiles(HttpClient httpClient, string apiKey) : base(httpClient)
        {
            var validatorFactory = new ValidatorFactory();
            _vtFileValidator = validatorFactory.Get<string>(typeof(VTFileValidator));
            _vtStreamValidator = validatorFactory.Get<Stream>(typeof(StreamValidator));
            _hashValidator = validatorFactory.Get<string>(typeof(FileHashValidator));

            AddDefaultRequestHeader(VTHeaderNames.ApiKey, apiKey);
        }

        public async Task<FileAnalysis> UploadFileAsync(string filePath, bool forceUploadUrl = false, CancellationToken cancellationToken = default)
        {
            var validationResult = _vtFileValidator.Validate(filePath);
            validationResult.ThrowIfAny();

            VTResponse<FileAnalysis> response = null;

            using (var fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.Read, 4096, true))
            {
                var fileName = Path.GetFileName(fileStream.Name);
                var endpoint = fileStream.Length == SupportedFileSizes.RegularFileSizeLimit && !forceUploadUrl
                    ? "files" : await GetUploadUrlAsync(cancellationToken).ConfigureAwait(false);

                response = await UploadFileAsync<VTResponse<FileAnalysis>>(endpoint, fileStream, fileName, cancellationToken).ConfigureAwait(false);
            }

            return response.Data;
        }

        public async Task<FileAnalysis> UploadFileAsync<T>(Stream stream, string filename, bool forceUploadUrl = false, CancellationToken cancellationToken = default)
        {
            var validationResult = _vtStreamValidator.Validate(stream);
            validationResult.ThrowIfAny();

            VTResponse<FileAnalysis> response = null;
            var endpoint = stream.Length == SupportedFileSizes.RegularFileSizeLimit && !forceUploadUrl
                    ? "files" : await GetUploadUrlAsync(cancellationToken).ConfigureAwait(false);

            response = await UploadFileAsync<VTResponse<FileAnalysis>>(endpoint, stream, filename, cancellationToken).ConfigureAwait(false);

            return response.Data;
        }

        public async Task<FileAnalysis> RescanFile(string id, CancellationToken cancellationToken = default)
        {
            var validationResult = _hashValidator.Validate(id);
            validationResult.ThrowIfAny();

            var response = await Self.GetAsync<VTResponse<FileAnalysis>>($"files/{id}/analyse", cancellationToken);
            return response.Data;
        }

        public async Task<FileReport> GetFileReportAsync(string id, CancellationToken cancellationToken = default)
        {
            var validationResult = _hashValidator.Validate(id);
            validationResult.ThrowIfAny();

            var response = await Self.GetAsync<VTResponse<FileReport>>($"files/{id}", cancellationToken);
            return response.Data;
        }

        public async Task<VTPagedResponse<Comment>> GetFileComments(string id, int limit = 10, string cursor = null, CancellationToken cancellationToken = default)
        {
            var validationResult = _hashValidator.Validate(id);
            validationResult.ThrowIfAny();

            return await Self.GetAsync<VTPagedResponse<Comment>>(string.IsNullOrWhiteSpace(cursor) ? $"files/{id}/comments?limit={limit}" : $"files/{id}/comments?limit={limit}&cursor={cursor}", cancellationToken);
        }

        public async Task<Comment> AddFileComment(string id, string comment, CancellationToken cancellationToken)
        {
            var validationResult = _hashValidator.Validate(id);
            validationResult.ThrowIfAny();

            var json = JsonSerializer.Serialize(new VTResponse<CreateComment>(new CreateComment(comment)), new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase });
            using (var content = new StringContent(json))
            {
                var response = await Self.PostAsync<VTResponse<Comment>>($"files/{id}/comments", content, cancellationToken);
                return response.Data;
            }
        }

        private async Task<T> UploadFileAsync<T>(string requestUri, Stream stream, string filename, CancellationToken cancellationToken)
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

                    return await Self.PostAsync<T>(requestUri, formDataContent, cancellationToken).ConfigureAwait(false);
                }
            }
        }

        private async Task<string> GetUploadUrlAsync(CancellationToken cancellationToken)
        {
            var result = await Self.GetAsync<VTResponse<string>>("files/upload_url", cancellationToken);
            return result.Data;
        }
    }
}
