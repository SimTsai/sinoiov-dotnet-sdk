using Sinoiov.OpenApi.Extensions;
using Sinoiov.OpenApi.Interfaces;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using Sinoiov.OpenApi.Options;
using System;
#if NET5_0
using System.Net.Http.Json;
#else
using System.IO;
using System.Text;
using System.Text.Json;
#endif

namespace Sinoiov.OpenApi.Implements
{
    internal class SinoiovHttpClient : ISinoiovHttpClient, IDisposable
    {
        private readonly HttpClient httpClient;

        public SinoiovHttpClient(
            IHttpClientFactory httpClientFactory,
            IOptions<SinoiovOptions> sinoiovOptions
            )
        {
            this.httpClient = httpClientFactory.CreateClient();
            this.httpClient.BaseAddress = new Uri(sinoiovOptions.Value.BaseUri);
        }

        public void Dispose()
        {
            this.httpClient?.Dispose();
        }

        async public Task<TReply> PostFormAsync<TRequest, TReply>(TRequest request, string apiUri)
            => await this.PostFormAsync<TReply>(request.ToStringDictionary<TRequest>(), apiUri).ConfigureAwait(false);

        async public Task<TReply> PostFormAsync<TReply>(Dictionary<string, string> dict, string apiUri)
        {
            var formUrlEncodedContent = new FormUrlEncodedContent(dict);
            var responseMessage = await httpClient
                .PostAsync(apiUri, formUrlEncodedContent)
                .ConfigureAwait(false);
            responseMessage.EnsureSuccessStatusCode();
            TReply reply;
#if NET5_0
            reply = await responseMessage.Content.ReadFromJsonAsync<TReply>().ConfigureAwait(false);
#else
            var json = await responseMessage.Content.ReadAsStringAsync().ConfigureAwait(false);
            using var ms = new MemoryStream(Encoding.UTF8.GetBytes(json), false);
            reply = await JsonSerializer.DeserializeAsync<TReply>(ms, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            }).ConfigureAwait(false);
#endif

            return reply;
        }
    }
}
