namespace Sinoiov.OpenApi.Models.Auth
{
    internal partial record SinoiovLoginOutRequest
    {
        /// <summary>
        /// 账号
        /// </summary>
        public string user { get; init; }
        /// <summary>
        /// 密码
        /// </summary>
        public string pwd { get; init; }
        /// <summary>
        /// 客户端 id
        /// </summary>
        public string cid { get; init; }
        /// <summary>
        /// 私钥
        /// </summary>
        public string srt { get; init; }
    }
}
