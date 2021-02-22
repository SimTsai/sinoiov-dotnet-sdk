using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Caching.StackExchangeRedis;
using Sinoiov.OpenApi.Enums;
using Sinoiov.OpenApi.Implements;
using System.Collections.Generic;

namespace Sinoiov.OpenApi.Options
{
    public partial class SinoiovOptions
    {
        public const string DefaultOptionsName = "Sinoiov";
        public const string DefaultTokenKey = "SinoiovToken";

        private string baseUri;

        public virtual SinoiovEnvironment Environment { get; set; } = SinoiovEnvironment.Test;
        public virtual string BaseUri
        {
            get
            {
                if (baseUri is null or { Length: 0 })
                {
                    baseUri = this.Environment switch
                    {
                        SinoiovEnvironment.Test => "https://openapi-test.sinoiov.cn",
                        SinoiovEnvironment.Production => "https://openapi.sinoiov.cn",
                        SinoiovEnvironment.Custom => baseUri,
                        _ => throw new System.ArgumentOutOfRangeException("Environment not support")
                    };
                }
                return baseUri;
            }
            set
            {
                baseUri = this.Environment switch
                {
                    SinoiovEnvironment.Custom => value,
                    _ => null
                };
            }
        }
        public virtual SinoiovAccountOptions Account { get; set; }
        public virtual Dictionary<string, string> Apis { get; set; } = new Dictionary<string, string>
        {
            { "登录", "/save/apis/login" },
            { "车辆最新位置查询（车牌号）", "/save/apis/vLastLocationV3" },
            { "多车最新位置查询", "/save/apis/vLastLocationMultiV4" }
        };
        public virtual SinoiovTokenStorageType TokenStorageIn { get; set; } = SinoiovTokenStorageType.InMemory;
        public virtual MemoryDistributedCacheOptions InMemoryOptions { get; set; }
        public virtual RedisCacheOptions RedisOptions { get; set; }
        public virtual string TokenKey { get; set; } = DefaultTokenKey;
    }
}
