using System.Threading.Tasks;
using System.Threading;
using VT.NET.Responses.Files.UploadFile;
using System.IO;
using VT.NET.Responses.Files.FileReport;
using VT.NET.Responses.Files.Comments;
using VT.NET.Responses;

namespace VT.NET.Endpoints
{
    public interface IVTFiles
    {
        Task<FileAnalysis> UploadFileAsync(string filePath, string password = null, bool forceUploadUrl = false, CancellationToken cancellationToken = default);
        Task<FileAnalysis> UploadFileAsync<T>(Stream stream, string filename, string password, bool forceUploadUrl = false, CancellationToken cancellationToken = default);
        Task<FileAnalysis> RescanFile(string id, CancellationToken cancellationToken = default);
        Task<FileReport> GetFileReportAsync(string id, CancellationToken cancellationToken = default);
        Task<VTPagedResponse<Comment>> GetFileComments(string id, int limit = 10, string cursor = null, CancellationToken cancellationToken = default);
        Task<Comment> AddFileComment(string id, string comment, CancellationToken cancellationToken);
    }
}
