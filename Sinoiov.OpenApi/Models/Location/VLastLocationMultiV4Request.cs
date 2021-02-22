using System.Collections.Generic;

namespace Sinoiov.OpenApi.Models.Location
{
    public class VLastLocationMultiV4Request
    {
        public List<SinoiovVehicle> Vehicles { get; init; }
        public int TimeNearby { get; set; }
    }
}
