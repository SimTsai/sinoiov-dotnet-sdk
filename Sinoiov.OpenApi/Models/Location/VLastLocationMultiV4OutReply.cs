using Sinoiov.OpenApi.Enums;

namespace Sinoiov.OpenApi.Models.Location
{
    /// <summary>
    /// 多车最新位置查询 响应
    /// </summary>
    internal class VLastLocationMultiV4OutReply
    {
        /// <summary>
        /// 车牌号
        /// </summary>
        public string vno { get; init; }
        /// <summary>
        /// 车牌颜色
        /// </summary>
        public string vco { get; init; }
        /// <summary>
        /// 车辆定位纬度
        /// </summary>
        public string lat { get; init; }
        /// <summary>
        /// 车辆定位经度
        /// </summary>
        public string lon { get; init; }
        /// <summary>
        /// 车辆地理位置名称
        /// </summary>
        public string adr { get; init; }
        /// <summary>
        /// 车辆定位时间
        /// </summary>
        public string utc { get; init; }
        /// <summary>
        /// 速度
        /// </summary>
        public string spd { get; init; }
        /// <summary>
        /// 方向
        /// </summary>
        public string drc { get; init; }
        /// <summary>
        /// 省
        /// </summary>
        public string province { get; init; }
        /// <summary>
        /// 市
        /// </summary>
        public string city { get; init; }
        /// <summary>
        /// 县
        /// </summary>
        public string country { get; init; }

        /// <summary>
        /// 查询状态
        /// </summary>
        public virtual SinoiovOutReplyStatus state { get; init; }
    }
}
