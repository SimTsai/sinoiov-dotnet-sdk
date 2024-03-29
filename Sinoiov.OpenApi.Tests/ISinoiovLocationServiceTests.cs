﻿using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Sinoiov.OpenApi.Interfaces;
using Xunit;

namespace Sinoiov.OpenApi.Tests
{
    public class ISinoiovLocationServiceTests : TestBase.DITestBase
    {
        private readonly ISinoiovLocationService sinoiovLocationService;
        public ISinoiovLocationServiceTests()
        {
            sinoiovLocationService = ServiceProvider.Value.GetRequiredService<ISinoiovLocationService>();
        }

        [Fact]
        async public Task VLastLocationMultiV4AsyncTest()
        {
            var vehicel = new Models.SinoiovVehicle
            {
                VehicleNO = "陕YH0008",
                VehicleColor = Enums.SinoiovVehicleColor.Yellow
            };
            var reply = await sinoiovLocationService
                .VLastLocationMultiV4Async(new Models.Location.VLastLocationMultiV4Request
                {
                    Vehicles = new List<Models.SinoiovVehicle> {
                       vehicel
                    },
                    TimeNearby = 24
                })
                .ConfigureAwait(false);
            if (reply.LastLocations.TryGetValue(vehicel, out var loc))
            {
                var rawLocation = loc.Location.ToSINOIOV();
            }
        }
    }
}
