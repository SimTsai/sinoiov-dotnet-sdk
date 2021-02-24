using System;
using System.Collections.Generic;
using Sinoiov.OpenApi.Enums;

namespace Sinoiov.OpenApi.Models.Location
{
    /// <summary>
    /// 多车最新位置响应
    /// </summary>
    public record VLastLocationMultiV4Reply : SinoiovReplyBase
    {
        /// <summary>
        /// 多车最新位置
        /// </summary>
        public Dictionary<SinoiovVehicle, VLastLocationMultiV4ReplyItem> LastLocations { get; init; }
    }

    /// <summary>
    /// 最新位置
    /// </summary>
    public record VLastLocationMultiV4ReplyItem
    {
        /// <summary>
        /// 车牌信息
        /// </summary>
        public SinoiovVehicle VehicleInfo { get; init; }

        /// <summary>
        /// 地理位置信息
        /// </summary>
        public Geography Location { get; init; }

        /// <summary>
        /// 车辆定位时间 UTC
        /// </summary>
        public DateTime LatestReportUtc { get; init; }
        /// <summary>
        /// 速度
        /// </summary>
        public decimal Speed { get; init; }
        /// <summary>
        /// 方向
        /// </summary>
        public Direction Direction { get; init; }
        /// <summary>
        /// 省
        /// </summary>
        public string Province { get; init; }
        /// <summary>
        /// 市
        /// </summary>
        public string City { get; init; }
        /// <summary>
        /// 县
        /// </summary>
        public string Country { get; init; }
        /// <summary>
        /// 车辆地理位置名称
        /// </summary>
        public string Address { get; init; }
    }
}
