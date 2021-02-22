namespace Sinoiov.OpenApi.Models.Location
{
    /// <summary>
    /// 多车最新位置查询 请求
    /// </summary>
    internal record VLastLocationMultiV4OutRequest : SinoiovOutRequest
    {
        /// <summary>
        /// 车牌号车牌颜色 , 列表（以半角逗号连接）车牌颜色，1 ：蓝色 2 ：黄色
        /// </summary>
        public string vclNs { get; set; }
        /// <summary>
        /// 时间范围，单位小时，指返回车辆最近时间范围内的最后定位信息
        /// </summary>
        public int timeNearby { get; set; }
    }
}
