using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Sinoiov.OpenApi.Enums;
using Sinoiov.OpenApi.Extensions;
using Sinoiov.OpenApi.Interfaces;
using Sinoiov.OpenApi.Models;
using Sinoiov.OpenApi.Models.Location;

namespace Sinoiov.OpenApi.Implements
{
    /// <summary>
    /// 中交兴路位置信息类接口服务
    /// </summary>
    public class SinoiovLocationService : ISinoiovLocationService
    {
        private readonly ISinoiovOutRequestService sinoiovOutRequestService;
        static DateTime UnixEpoch =
#if NET5_0
            DateTime.UnixEpoch;
#else
            new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
#endif

        /// <summary>
        /// DI CTOR
        /// </summary>
        /// <param name="serviceProvider"></param>
        public SinoiovLocationService(
            IServiceProvider serviceProvider
            ) : this(serviceProvider.GetRequiredService<ISinoiovOutRequestService>())
        {

        }

        internal SinoiovLocationService(
            ISinoiovOutRequestService sinoiovOutRequestService
            )
        {
            this.sinoiovOutRequestService = sinoiovOutRequestService;
        }

        /// <summary>
        /// 多车最新位置查询
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        async public Task<VLastLocationMultiV4Reply> VLastLocationMultiV4Async(VLastLocationMultiV4Request request)
        {
            var vclNs = string.Join(",",
                request.Vehicles.Select(s => $"{s.VehicleNO}_{(int)s.VehicleColor}")
            );

            var outReply = await VLastLocationMultiV4Async(new VLastLocationMultiV4OutRequest
            {
                vclNs = vclNs,
                timeNearby = request.TimeNearby,
            }).ConfigureAwait(false);

            Dictionary<SinoiovVehicle, VLastLocationMultiV4ReplyItem> lastLocations = null;
            VLastLocationMultiV4Reply result = new VLastLocationMultiV4Reply
            {
                Success = outReply.Status == Enums.SinoiovOutReplyStatus.OK,
                Message = outReply.Status.ToMessage(),
                LastLocations = outReply.Status switch
                {
                    SinoiovOutReplyStatus.OK => lastLocations ??= new Dictionary<SinoiovVehicle, VLastLocationMultiV4ReplyItem>(),
                    _ => null
                }
            };

            if (result.Success)
            {
                outReply.Result.ForEach(o =>
                {
                    Enum.TryParse<Enums.SinoiovVehicleColor>(o.vco, out var vco);
                    var key = new SinoiovVehicle
                    {
                        VehicleNO = o.vno,
                        VehicleColor = vco
                    };

                    decimal.TryParse(o.spd, out var speed);

                    var value = new VLastLocationMultiV4ReplyItem
                    {
                        VehicleInfo = key,
                        Location = SinoiovToWGS84(o.lon, o.lat),

                        LatestReportUtc = SinoiovToUtcDateTime(o.utc),
                        Speed = speed,
                        Direction = SinoiovToDirection(o.drc),

                        Province = o.province,
                        City = o.city,
                        Country = o.country,
                        Address = o.adr
                    };

                    lastLocations.Add(key, value);
                });
            }

            return result;
        }

        Geography SinoiovToWGS84(string lon, string lat)
        {
            if (double.TryParse(lon, out var _lon))
                _lon /= 600000;
            if (double.TryParse(lat, out var _lat))
                _lat /= 600000;
            return new Geography(_lon, _lat, GeographyCoordinateSystem.WGS84);
        }

        DateTime SinoiovToUtcDateTime(string utc)
        {
            double.TryParse(utc, out var ms);
            return UnixEpoch.AddMilliseconds(ms);
        }

        Direction SinoiovToDirection(string drc)
        {
            if (drc is not null and { Length: > 0 } && long.TryParse(drc, out var direction))
            {
                return direction switch
                {
                    0 or 360 => Direction.North,
                    > 0 and < 90 => Direction.Northeast,
                    90 => Direction.East,
                    > 90 and < 180 => Direction.Southeast,
                    180 => Direction.South,
                    > 180 and < 270 => Direction.Southwest,
                    270 => Direction.West,
                    > 270 and < 360 => Direction.Northwest,
                    _ => Direction.Unknown
                };
            }
            return Direction.Unknown;
        }

        async private Task<SinoiovOutReplyWrapper<List<VLastLocationMultiV4OutReply>>> VLastLocationMultiV4Async(VLastLocationMultiV4OutRequest request)
        {
            var outReply = await sinoiovOutRequestService
                .RequestAsync<VLastLocationMultiV4OutRequest, List<VLastLocationMultiV4OutReply>>(request, "多车最新位置查询")
                .ConfigureAwait(false);

            return outReply;
        }
    }
}
