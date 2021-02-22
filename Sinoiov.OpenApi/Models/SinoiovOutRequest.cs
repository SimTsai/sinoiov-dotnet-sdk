namespace Sinoiov.OpenApi.Models
{
    internal abstract partial record SinoiovOutRequest
    {
        /// <summary>
        /// 用户令牌
        /// </summary>
        public virtual string token { get; set; }
        /// <summary>
        /// 客户端标识（API 访问凭证），对应账密中的 client_id
        /// </summary>
        public virtual string cid { get; set; }
        /// <summary>
        /// 私钥
        /// </summary>
        public virtual string srt { get; set; }
    }
}
