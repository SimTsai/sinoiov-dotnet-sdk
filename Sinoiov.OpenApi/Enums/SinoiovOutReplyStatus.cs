namespace Sinoiov.OpenApi.Enums
{
    /// <summary>
    /// 中交兴路接口返回状态
    /// </summary>
    public enum SinoiovOutReplyStatus
    {
        /// <summary>
        /// 接口执行成功
        /// </summary>
        OK = 1001,
        /// <summary>
        /// 参数不正确（参数为空、查询时间范围不正确、参数数量不正确）
        /// </summary>
        InvaildParams = 1002,
        /// <summary>
        /// 无结果
        /// </summary>
        NoResult = 1006,
    }
}
