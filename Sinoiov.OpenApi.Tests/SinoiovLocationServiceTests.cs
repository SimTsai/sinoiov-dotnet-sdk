#if NETFRAMEWORK
using System.Collections.Generic;
using System.Threading.Tasks;
using Sinoiov.OpenApi.Implements;
using Sinoiov.OpenApi.Interfaces;
using Xunit;

namespace Sinoiov.OpenApi.Tests
{
    public class SinoiovLocationServiceTests : TestBase.LegacyConfigTestBase
    {
        private readonly ISinoiovLocationService sinoiovLocationService;

        public SinoiovLocationServiceTests()
        {
            var serviceFactory = SinoiovServiceFactory.CreateSinoiovService(SinoiovOptions);
            sinoiovLocationService = serviceFactory.SinoiovLocationService;
        }

        [Fact]
        async public Task VLastLocationMultiV4AsyncTest()
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
}
#endif
