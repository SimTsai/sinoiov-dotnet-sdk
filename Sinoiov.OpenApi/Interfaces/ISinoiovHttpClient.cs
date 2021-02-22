using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sinoiov.OpenApi.Interfaces
{
    internal interface ISinoiovHttpClient : System.IDisposable
    {
        Task<TReply> PostFormAsync<TRequest, TReply>(TRequest request, string apiUri);
        Task<TReply> PostFormAsync<TReply>(Dictionary<string, string> dict, string apiUri);
    }
}
