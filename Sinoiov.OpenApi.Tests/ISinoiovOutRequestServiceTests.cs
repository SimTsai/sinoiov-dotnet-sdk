using Microsoft.Extensions.DependencyInjection;
using Sinoiov.OpenApi.Interfaces;
using System.Threading.Tasks;
using Xunit;

namespace Sinoiov.OpenApi.Tests
{
    public class ISinoiovOutRequestServiceTests : TestBase.DITestBase
    {
        private readonly ISinoiovOutRequestService sinoiovOutRequestService;

        public ISinoiovOutRequestServiceTests()
        {
            sinoiovOutRequestService = ServiceProvider.Value.GetRequiredService<ISinoiovOutRequestService>();
        }

        [Fact]
        async public Task LoginRequestAsyncTest()
        {
            var reply = await sinoiovOutRequestService.LoginRequestAsync().ConfigureAwait(false);
        }
    }
}
