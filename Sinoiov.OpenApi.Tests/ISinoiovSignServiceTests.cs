using Microsoft.Extensions.DependencyInjection;
using Sinoiov.OpenApi.Interfaces;
using System.Threading.Tasks;
using Xunit;

namespace Sinoiov.OpenApi.Tests
{
    public class ISinoiovSignServiceTests : TestBase.DITestBase
    {
        private readonly ISinoiovSignService sinoiovSignService;

        public ISinoiovSignServiceTests()
        {
            sinoiovSignService = ServiceProvider.Value.GetRequiredService<ISinoiovSignService>();
        }

        [Fact]
        public void SignTest()
        {
            var sign = sinoiovSignService.Sign(new Class());
        }

#if NET5_0
        [Fact]
        async public Task SignAsyncTest()
        {
            var sign = await sinoiovSignService.SignAsync(new Class()).ConfigureAwait(false);
        }
#endif
    }
}
