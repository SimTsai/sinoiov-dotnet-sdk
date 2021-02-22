#if NETFRAMEWORK
using Microsoft.Extensions.Caching.Distributed;
using Sinoiov.OpenApi.Implements;
using System;
using System.Threading.Tasks;
using Xunit;

namespace Sinoiov.OpenApi.Tests
{
    public class SinoiovCacheProviderFactoryTests : TestBase.LegacyConfigTestBase
    {
        private readonly SinoiovCacheProviderFactory sinoiovCacheProviderFactory;

        public SinoiovCacheProviderFactoryTests()
        {
            sinoiovCacheProviderFactory = new SinoiovCacheProviderFactory(base.SinoiovOptions);
        }

        [Fact]
        async public Task GetProviderTest()
        {
            var distributedCache = sinoiovCacheProviderFactory.GetProvider();
            Assert.NotNull(distributedCache);

            await distributedCache
                .SetStringAsync("Sinoiov:OpenApi:Tests:ISinoiovCacheProviderFactoryTest:GetProviderTest", Guid.NewGuid().ToString("N"), new DistributedCacheEntryOptions { AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(3) })
                .ConfigureAwait(false);
            var value = await distributedCache
                .GetStringAsync("Sinoiov:OpenApi:Tests:ISinoiovCacheProviderFactoryTest:GetProviderTest")
                .ConfigureAwait(false);
        }
    }
}
#endif
