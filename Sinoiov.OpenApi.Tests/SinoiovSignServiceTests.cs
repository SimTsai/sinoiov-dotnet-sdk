#if NETFRAMEWORK
using Sinoiov.OpenApi.Implements;
using Sinoiov.OpenApi.Tests.TestBase;
using Xunit;

namespace Sinoiov.OpenApi.Tests
{
    public class SinoiovSignServiceTests : LegacyConfigTestBase
    {
        private readonly SinoiovSignService sinoiovSignService;

        public SinoiovSignServiceTests()
        {
            sinoiovSignService = new SinoiovSignService(base.SinoiovOptions);
        }

        [Fact]
        public void SignTest()
        {
            var sign = sinoiovSignService.Sign(new Class());
        }
    }
}
#endif