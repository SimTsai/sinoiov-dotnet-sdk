using System;

namespace Sinoiov.OpenApi.Models
{
    [System.Diagnostics.DebuggerDisplay("{CoordinateSystem}(Longitude={Longitude},Latitude={Latitude})")]
    public class Geography
    {
        public Geography(
            (double lon,
            double lat) coord,
            GeographyCoordinateSystem coordinateSystem = GeographyCoordinateSystem.WGS84
            ) : this(coord.lon, coord.lat, coordinateSystem)
        {

        }

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

        public Geography ToWGS84()
        {
            return this.CoordinateSystem switch
            {
                GeographyCoordinateSystem.WGS84 => this,
                GeographyCoordinateSystem.GCJ02 => new Geography(Coordtransform.Gcj02towgs84(this.Longitude, this.Latitude), GeographyCoordinateSystem.WGS84),
                GeographyCoordinateSystem.BD09 => new Geography(Coordtransform.Bd09towgs84(this.Longitude, this.Latitude), GeographyCoordinateSystem.WGS84),
                _ => throw new IndexOutOfRangeException($"{this.CoordinateSystem} not a vaild coordinateSystem")
            };
        }

        public Geography ToGCJ02()
        {
            return this.CoordinateSystem switch
            {
                GeographyCoordinateSystem.GCJ02 => this,
                GeographyCoordinateSystem.WGS84 => new Geography(Coordtransform.Wgs84togcj02(this.Longitude, this.Latitude), GeographyCoordinateSystem.GCJ02),
                GeographyCoordinateSystem.BD09 => new Geography(Coordtransform.Bd09togcj02(this.Longitude, this.Latitude), GeographyCoordinateSystem.GCJ02),
                _ => throw new IndexOutOfRangeException($"{this.CoordinateSystem} not a vaild coordinateSystem")
            };
        }

        public Geography ToBD09()
        {
            return this.CoordinateSystem switch
            {
                GeographyCoordinateSystem.BD09 => this,
                GeographyCoordinateSystem.GCJ02 => new Geography(Coordtransform.Gcj02tobd09(this.Longitude, this.Latitude), GeographyCoordinateSystem.BD09),
                GeographyCoordinateSystem.WGS84 => new Geography(Coordtransform.Wgs84tobd09(this.Longitude, this.Latitude), GeographyCoordinateSystem.BD09),
                _ => throw new IndexOutOfRangeException($"{this.CoordinateSystem} not a vaild coordinateSystem")
            };
        }
    }

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
        BD09
    }
}
