using Microsoft.Extensions.Options;
using Sinoiov.OpenApi.Extensions;
using Sinoiov.OpenApi.Interfaces;
using Sinoiov.OpenApi.Models;
using Sinoiov.OpenApi.Models.Auth;
using Sinoiov.OpenApi.Options;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sinoiov.OpenApi.Implements
{
    internal class SinoiovOutRequestService : ISinoiovOutRequestService
    {
        private readonly SinoiovOptions sinoiovOptions;
        private readonly ISinoiovHttpClient sinoiovHttpClient;
        private readonly ISinoiovSignService sinoiovSignService;
        private readonly ISinoiovTokenStorageService sinoiovTokenStorageService;

        public SinoiovOutRequestService(
            IOptions<SinoiovOptions> sinoiovOptions,
            ISinoiovHttpClient sinoiovHttpClient,
            ISinoiovSignService sinoiovSignService,
            ISinoiovTokenStorageService sinoiovTokenStorageService
            )
        {
            this.sinoiovOptions = sinoiovOptions.Value;
            this.sinoiovHttpClient = sinoiovHttpClient;
            this.sinoiovSignService = sinoiovSignService;
            this.sinoiovTokenStorageService = sinoiovTokenStorageService;
        }

        async public Task<SinoiovOutReplyWrapper<TReply>> RequestAsync<TRequest, TReply>(TRequest request, string apiName)
            where TRequest : SinoiovOutRequest
        {
            try
            {
                if (request.token is null)
                {
                    request.token = await GetTokenAsync().ConfigureAwait(false);
                }

                if (request.srt is null)
                {
                    request.srt = this.sinoiovOptions.Account.Secret;
                }

                if (request.cid is null)
                {
                    request.cid = this.sinoiovOptions.Account.ClientID;
                }

                return await this
                    .RequestAsync<TReply>(request.ToStringDictionary<TRequest>(), apiName)
                    .ConfigureAwait(false);
            }
            catch (Exception)
            {
                throw;
            }
        }

        async public Task<SinoiovOutReplyWrapper<TReply>> RequestAsync<TReply>(Dictionary<string, string> dict, string apiName)
        {
            try
            {
                var apiUri = sinoiovOptions.Apis[apiName];

                if (!dict.ContainsKey(nameof(SinoiovOutRequest.token)))
                {
                    dict.Add(nameof(SinoiovOutRequest.token), await GetTokenAsync());
                }

                if (!dict.ContainsKey(nameof(SinoiovOutRequest.srt)))
                {
                    dict.Add(nameof(SinoiovOutRequest.srt), sinoiovOptions.Account.Secret);
                }

                if (!dict.ContainsKey(nameof(SinoiovOutRequest.cid)))
                {
                    dict.Add(nameof(SinoiovOutRequest.cid), sinoiovOptions.Account.ClientID);
                }

                string sign;
#if NET5_0
                sign = await sinoiovSignService.SignAsync(dict).ConfigureAwait(false);
#else
                sign = sinoiovSignService.Sign(dict);
#endif
                if (dict.ContainsKey(nameof(sign)))
                {
                    dict[nameof(sign)] = sign;
                }
                else
                {
                    dict.Add(nameof(sign), sign);
                }

                var reply = await sinoiovHttpClient
                    .PostFormAsync<SinoiovOutReplyWrapper<TReply>>(dict, apiUri)
                    .ConfigureAwait(false);

                return reply;
            }
            catch (Exception)
            {
                throw;
            }
        }

        async public Task<string> GetTokenAsync()
        {
            var token = await sinoiovTokenStorageService.LoadTokenAsync().ConfigureAwait(false);
            if (token is null or { Length: 0 })
            {
                var loginReply = await LoginRequestAsync().ConfigureAwait(false);
                await sinoiovTokenStorageService.SaveTokenAsync(loginReply.Token).ConfigureAwait(false);
                return loginReply.Token;
            }
            return token;
        }

        async public Task<SinoiovLoginOutReply> LoginRequestAsync()
        {
            var apiUri = sinoiovOptions.Apis["登录"];

            var dict = new SinoiovLoginOutRequest
            {
                cid = this.sinoiovOptions.Account.ClientID,
                pwd = this.sinoiovOptions.Account.Password,
                srt = this.sinoiovOptions.Account.Secret,
                user = this.sinoiovOptions.Account.User,
            }.ToStringDictionary();
            string sign;
#if NET5_0
            sign = await sinoiovSignService.SignAsync(dict).ConfigureAwait(false);
#else
            sign = sinoiovSignService.Sign(dict);
#endif
            dict.Add(nameof(sign), sign);

            var reply = await sinoiovHttpClient
                .PostFormAsync<SinoiovLoginOutReply>(dict, apiUri)
                .ConfigureAwait(false);

            return reply;
        }
    }
}
