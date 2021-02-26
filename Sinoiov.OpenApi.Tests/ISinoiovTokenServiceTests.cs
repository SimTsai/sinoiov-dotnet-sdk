using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Sinoiov.OpenApi.Interfaces;
using Xunit;

namespace Sinoiov.OpenApi.Tests
{
    public class ISinoiovTokenServiceTests : TestBase.DITestBase
    {
        private readonly ISinoiovTokenService tokenService;
        public ISinoiovTokenServiceTests()
        {
            tokenService = ServiceProvider.Value.GetRequiredService<ISinoiovTokenService>();
        }

        [Fact]
        async public Task GetTokenAsyncTest()
        {
            var token = await tokenService.GetTokenAsync().ConfigureAwait(false);
            Assert.NotNull(token);
        }
    }
}
