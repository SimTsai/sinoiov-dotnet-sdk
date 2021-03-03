#if NETFRAMEWORK
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sinoiov.OpenApi.Implements;
using Sinoiov.OpenApi.Interfaces;
using Sinoiov.OpenApi.Tests.TestBase;
using Xunit;

namespace Sinoiov.OpenApi.Tests
{
    public class CustomTokenStorageServiceTests : LegacyConfigTestBase
    {
        private readonly ISinoiovLocationService sinoiovLocationService;

        public CustomTokenStorageServiceTests()
        {
            SinoiovOptions.Value.TokenStorageIn = Enums.SinoiovTokenStorageType.Custom;
            var serviceFactory = SinoiovServiceFactory.CreateSinoiovService(SinoiovOptions, new TestSinoiovTokenStorageService());
            sinoiovLocationService = serviceFactory.SinoiovLocationService;
        }

        [Fact]
        async public Task Test()
        {
            var reply = await sinoiovLocationService
                .VLastLocationMultiV4Async(new Models.Location.VLastLocationMultiV4Request
                {
                    Vehicles = new List<Models.SinoiovVehicle> {
                                                new Models.SinoiovVehicle{
                                                    VehicleNO = "陕YH0008",
                                                    VehicleColor = Enums.SinoiovVehicleColor.Yellow
                                                }
                    },
                    TimeNearby = 24
                })
                .ConfigureAwait(false);
        }
    }

    public class TestSinoiovTokenStorageService : ISinoiovTokenStorageService
    {
        static string token;

        public void Dispose()
        {
            return;
        }
        public Task<string> LoadTokenAsync()
        {
            return Task.FromResult(token);
        }

        async public Task SaveTokenAsync(string token)
        {
            TestSinoiovTokenStorageService.token = token;
        }
    }

}
#endif
