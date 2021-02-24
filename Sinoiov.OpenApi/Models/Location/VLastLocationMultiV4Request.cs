using System.Collections.Generic;

namespace Sinoiov.OpenApi.Models.Location
{
    /// <summary>
    /// 多车最新位置请求
    /// </summary>
    public class VLastLocationMultiV4Request
    {
        /// <summary>
        /// 多车辆
        /// </summary>
        public List<SinoiovVehicle> Vehicles { get; init; }
        /// <summary>
        /// 时间范围，单位小时，指返回车辆最近时间范围内的最后定位信息
        /// </summary>
        public int TimeNearby { get; set; }
    }
}
