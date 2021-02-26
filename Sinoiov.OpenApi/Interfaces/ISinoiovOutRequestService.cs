using System.Collections.Generic;
using System.Threading.Tasks;
using Sinoiov.OpenApi.Models;
using Sinoiov.OpenApi.Models.Auth;

namespace Sinoiov.OpenApi.Interfaces
{
    internal interface ISinoiovOutRequestService : ISinoiovTokenService
    {
        Task<SinoiovOutReplyWrapper<TReply>> RequestAsync<TRequest, TReply>(TRequest request, string apiName)
            where TRequest : SinoiovOutRequest;
        Task<SinoiovOutReplyWrapper<TReply>> RequestAsync<TReply>(Dictionary<string, string> dict, string apiName);

        Task<SinoiovLoginOutReply> LoginRequestAsync();
    }
}
