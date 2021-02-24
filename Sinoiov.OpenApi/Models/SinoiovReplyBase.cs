namespace Sinoiov.OpenApi.Models
{
    /// <summary>
    /// 中交兴路响应基类
    /// </summary>
    public abstract record SinoiovReplyBase
    {
        /// <summary>
        /// 是否成功
        /// </summary>
        public bool Success { get; init; }
        /// <summary>
        /// 信息
        /// </summary>
        public string Message { get; init; }
    }
}
