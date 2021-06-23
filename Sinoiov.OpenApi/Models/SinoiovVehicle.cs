using Sinoiov.OpenApi.Enums;

namespace Sinoiov.OpenApi.Models
{
    /// <summary>
    /// 车牌信息
    /// </summary>
    [System.Diagnostics.DebuggerDisplay("{VehicleNO}_{VehicleColor}")]
    public partial class SinoiovVehicle : System.IComparable<SinoiovVehicle>, System.IEquatable<SinoiovVehicle>
    {
        /// <summary>
        /// 车牌号
        /// </summary>
        public virtual string VehicleNO { get; init; }
        /// <summary>
        /// 车牌颜色
        /// </summary>
        public virtual SinoiovVehicleColor VehicleColor { get; init; }

        /// <summary>
        /// IComparable
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public int CompareTo(SinoiovVehicle other) => this.VehicleNO.CompareTo(other.VehicleNO) + this.VehicleColor.CompareTo(other.VehicleColor);

        /// <summary>
        /// IEquatable
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public bool Equals(SinoiovVehicle other) => this.VehicleNO == other.VehicleNO && this.VehicleColor == other.VehicleColor;

        /// <summary>
        /// ==
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static bool operator ==(SinoiovVehicle a, SinoiovVehicle b) => a.Equals(b);
        /// <summary>
        /// !=
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static bool operator !=(SinoiovVehicle a, SinoiovVehicle b) => !a.Equals(b);
    }
}
