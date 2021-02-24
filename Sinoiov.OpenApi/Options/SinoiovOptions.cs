using System.Collections.Generic;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Caching.StackExchangeRedis;
using Sinoiov.OpenApi.Enums;

namespace Sinoiov.OpenApi.Options
{
    /// <summary>
    /// 中交兴路 Options
    /// </summary>
    public partial class SinoiovOptions
    {
        /// <summary>
        /// 默认Options名
        /// </summary>
        public const string DefaultOptionsName = "Sinoiov";
        /// <summary>
        /// 默认Token缓存名
        /// </summary>
        public const string DefaultTokenKey = "SinoiovToken";

        private string baseUri;

        /// <summary>
        /// 环境
        /// </summary>
        public virtual SinoiovEnvironment Environment { get; set; } = SinoiovEnvironment.Test;
        /// <summary>
        /// 基地址
        /// </summary>
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
        /// <summary>
        /// 账号信息
        /// </summary>
        public virtual SinoiovAccountOptions Account { get; set; }
        /// <summary>
        /// Api列表
        /// </summary>
        public virtual Dictionary<string, string> Apis { get; set; } = new Dictionary<string, string>
        {
            { "登录", "/save/apis/login" },
            { "车辆最新位置查询（车牌号）", "/save/apis/vLastLocationV3" },
            { "多车最新位置查询", "/save/apis/vLastLocationMultiV4" }
        };
        /// <summary>
        /// Token存储位置
        /// </summary>
        public virtual SinoiovTokenStorageType TokenStorageIn { get; set; } = SinoiovTokenStorageType.InMemory;
        /// <summary>
        /// 进程内Token存储相关配置
        /// </summary>
        public virtual MemoryDistributedCacheOptions InMemoryOptions { get; set; }
        /// <summary>
        /// Redis Token存储相关配置
        /// </summary>
        public virtual RedisCacheOptions RedisOptions { get; set; }
        /// <summary>
        /// Token缓存名
        /// </summary>
        public virtual string TokenKey { get; set; } = DefaultTokenKey;
    }
}
