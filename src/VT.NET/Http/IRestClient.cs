using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace VT.NET.Http
{
    internal interface IRestClient
    {
        Task<T> GetAsync<T>(string requestUri, CancellationToken cancellationToken);
        Task<T> PostAsync<T>(string requestUri, HttpContent content, CancellationToken cancellationToken);
    }
}
