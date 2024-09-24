using VT.NET.Endpoints;
using VT.NET.Utility;

namespace VT.NET.Test
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            var fileHasher = new FileHasher();
            var sha256 = fileHasher.GetHash(@"C:\Users\Governor\Downloads\32MiB.bin", HashAlgorithmEnum.SHA256);
            var sha1 = fileHasher.GetHash(@"C:\Users\Governor\Downloads\32MiB.bin", HashAlgorithmEnum.SHA1);
            var md5 = fileHasher.GetHash(@"C:\Users\Governor\Downloads\32MiB.bin", HashAlgorithmEnum.MD5);

            var httpClient = new HttpClient();
            httpClient.Timeout = TimeSpan.FromMinutes(5);
            httpClient.BaseAddress = new Uri("https://www.virustotal.com/api/v3/");
            var files = new VTFiles(httpClient, "f01e5d876c5465b23171373b80ebb4097093dd4b09021a582168e10a6e512b6a");
            //await files.RescanFile(sha256);
            //var comment = await files.AddFileComment(sha256, "test");

            //var filereport = await files.GetFileReportAsync(sha256);

            await files.UploadFileAsync(@"C:\Users\Governor\Downloads\zt85lcglptCe");
        }
    }
}
