using Sinoiov.OpenApi.Enums;

namespace Sinoiov.OpenApi.Models
{
    /// <summary>
    /// 车牌信息
    /// </summary>
    [System.Diagnostics.DebuggerDisplay("{VehicleNO}_{VehicleColor}")]
    public partial class SinoiovVehicle
    {
        /// <summary>
        /// 车牌号
        /// </summary>
        public virtual string VehicleNO { get; init; }
        /// <summary>
        /// 车牌颜色
        /// </summary>
        public virtual SinoiovVehicleColor VehicleColor { get; init; }
    }
}
