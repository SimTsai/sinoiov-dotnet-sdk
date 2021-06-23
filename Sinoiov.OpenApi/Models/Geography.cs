using System;

namespace Sinoiov.OpenApi.Models
{
    /// <summary>
    /// 地理坐标
    /// </summary>
    [System.Diagnostics.DebuggerDisplay("{CoordinateSystem}(Longitude={Longitude},Latitude={Latitude})")]
    public class Geography
    {
        /// <summary>
        /// 中交兴路坐标偏移
        /// </summary>
        public int SinoiovCoordinateOffset = 600000;

        /// <summary>
        /// CTOR
        /// </summary>
        /// <param name="coord"></param>
        /// <param name="coordinateSystem"></param>
        public Geography(
            (double lon,
            double lat) coord,
            GeographyCoordinateSystem coordinateSystem = GeographyCoordinateSystem.WGS84
            ) : this(coord.lon, coord.lat, coordinateSystem)
        {

        }

        /// <summary>
        /// CTOR
        /// </summary>
        /// <param name="lon"></param>
        /// <param name="lat"></param>
        /// <param name="coordinateSystem"></param>
        public Geography(
            double lon,
            double lat,
            GeographyCoordinateSystem coordinateSystem = GeographyCoordinateSystem.WGS84
            )
        {
            this.Longitude = lon;
            this.Latitude = lat;
            this.CoordinateSystem = coordinateSystem;
        }

        /// <summary>
        /// 经度坐标
        /// </summary>
        public double Longitude { get; }
        /// <summary>
        /// 纬度坐标
        /// </summary>
        public double Latitude { get; }

        /// <summary>
        /// 坐标系统
        /// </summary>
        public GeographyCoordinateSystem CoordinateSystem { get; set; }

        /// <summary>
        /// 转换成 WGS-84（地球坐标） 坐标系
        /// </summary>
        /// <returns></returns>
        public Geography ToWGS84()
        {
            return this.CoordinateSystem switch
            {
                GeographyCoordinateSystem.WGS84 => this,
                GeographyCoordinateSystem.GCJ02 => new Geography(Coordtransform.Gcj02towgs84(this.Longitude, this.Latitude), GeographyCoordinateSystem.WGS84),
                GeographyCoordinateSystem.BD09 => new Geography(Coordtransform.Bd09towgs84(this.Longitude, this.Latitude), GeographyCoordinateSystem.WGS84),
                GeographyCoordinateSystem.SINOIOV => new Geography(this.Latitude / SinoiovCoordinateOffset, this.Latitude / SinoiovCoordinateOffset, GeographyCoordinateSystem.WGS84),
                _ => throw new IndexOutOfRangeException($"{this.CoordinateSystem} not a vaild coordinateSystem")
            };
        }

        /// <summary>
        /// 转换成 GCT-02（火星坐标） 坐标系
        /// </summary>
        /// <returns></returns>
        public Geography ToGCJ02()
        {
            return this.CoordinateSystem switch
            {
                GeographyCoordinateSystem.GCJ02 => this,
                GeographyCoordinateSystem.WGS84 => new Geography(Coordtransform.Wgs84togcj02(this.Longitude, this.Latitude), GeographyCoordinateSystem.GCJ02),
                GeographyCoordinateSystem.BD09 => new Geography(Coordtransform.Bd09togcj02(this.Longitude, this.Latitude), GeographyCoordinateSystem.GCJ02),
                GeographyCoordinateSystem.SINOIOV => new Geography(Coordtransform.Wgs84togcj02(this.Longitude / SinoiovCoordinateOffset, this.Latitude / SinoiovCoordinateOffset), GeographyCoordinateSystem.GCJ02),
                _ => throw new IndexOutOfRangeException($"{this.CoordinateSystem} not a vaild coordinateSystem")
            };
        }

        /// <summary>
        /// 转换为 BD09（百度坐标） 坐标系
        /// </summary>
        /// <returns></returns>
        public Geography ToBD09()
        {
            return this.CoordinateSystem switch
            {
                GeographyCoordinateSystem.BD09 => this,
                GeographyCoordinateSystem.GCJ02 => new Geography(Coordtransform.Gcj02tobd09(this.Longitude, this.Latitude), GeographyCoordinateSystem.BD09),
                GeographyCoordinateSystem.WGS84 => new Geography(Coordtransform.Wgs84tobd09(this.Longitude, this.Latitude), GeographyCoordinateSystem.BD09),
                GeographyCoordinateSystem.SINOIOV => new Geography(Coordtransform.Wgs84tobd09(this.Longitude / SinoiovCoordinateOffset, this.Latitude / SinoiovCoordinateOffset), GeographyCoordinateSystem.BD09),
                _ => throw new IndexOutOfRangeException($"{this.CoordinateSystem} not a vaild coordinateSystem")
            };
        }

        /// <summary>
        /// 转换为中交兴路原始坐标值（WGS84 * 600000）
        /// </summary>
        /// <returns></returns>
        public Geography ToSINOIOV()
        {
            switch (this.CoordinateSystem)
            {
                case GeographyCoordinateSystem.WGS84:
                    return new Geography(this.Longitude * SinoiovCoordinateOffset, this.Latitude * SinoiovCoordinateOffset, GeographyCoordinateSystem.SINOIOV);
                case GeographyCoordinateSystem.GCJ02:
                    {
                        var wgs84 = Coordtransform.Gcj02towgs84(this.Longitude, this.Latitude);
                        return new Geography(wgs84.lon * SinoiovCoordinateOffset, wgs84.lat * SinoiovCoordinateOffset, GeographyCoordinateSystem.SINOIOV);
                    }
                case GeographyCoordinateSystem.BD09:
                    {
                        var wgs84 = Coordtransform.Bd09towgs84(this.Longitude, this.Latitude);
                        return new Geography(wgs84.lon * SinoiovCoordinateOffset, wgs84.lat * SinoiovCoordinateOffset, GeographyCoordinateSystem.SINOIOV);
                    }
                case GeographyCoordinateSystem.SINOIOV:
                    return this;
                default:
                    throw new IndexOutOfRangeException($"{this.CoordinateSystem} not a vaild coordinateSystem");
            }
        }
    }

    /// <summary>
    /// 坐标系
    /// </summary>
    public enum GeographyCoordinateSystem
    {
        /// <summary>
        /// 地球坐标
        /// </summary>
        WGS84,
        /// <summary>
        /// 火星坐标
        /// </summary>
        GCJ02,
        /// <summary>
        /// 百度坐标
        /// </summary>
        BD09,
        /// <summary>
        /// 中交兴路原始坐标值（WGS84 * 600000）
        /// </summary>
        SINOIOV,
    }
}
