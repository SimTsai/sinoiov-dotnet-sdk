using Microsoft.Extensions.DependencyInjection;
using Sinoiov.OpenApi.Interfaces;
using Sinoiov.OpenApi.Models;
using Sinoiov.OpenApi.Models.Location;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sinoiov.OpenApi.Implements
{
    public class SinoiovLocationService : ISinoiovLocationService
    {
        private readonly ISinoiovOutRequestService sinoiovOutRequestService;

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

        async public Task<object> VLastLocationMultiV4Async(VLastLocationMultiV4Request request)
        {
            var vclNs = string.Join(",",
                request.Vehicles.Select(s => $"{s.VehicleNO}_{(int)s.VehicleColor}")
            );

            var outReply = await VLastLocationMultiV4Async(new VLastLocationMultiV4OutRequest
            {
                vclNs = vclNs,
                timeNearby = request.TimeNearby,
            }).ConfigureAwait(false);

            return outReply;
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
