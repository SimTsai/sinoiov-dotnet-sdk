using Sinoiov.OpenApi.Models;
using Sinoiov.OpenApi.Models.Auth;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sinoiov.OpenApi.Interfaces
{
    internal interface ISinoiovOutRequestService
    {
        Task<SinoiovOutReplyWrapper<TReply>> RequestAsync<TRequest, TReply>(TRequest request, string apiName)
            where TRequest : SinoiovOutRequest;
        Task<SinoiovOutReplyWrapper<TReply>> RequestAsync<TReply>(Dictionary<string, string> dict, string apiName);
        Task<string> GetTokenAsync();
        Task<SinoiovLoginOutReply> LoginRequestAsync();
    }
}
