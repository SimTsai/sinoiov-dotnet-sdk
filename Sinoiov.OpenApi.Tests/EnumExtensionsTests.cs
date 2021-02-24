using Sinoiov.OpenApi.Enums;
using Sinoiov.OpenApi.Extensions;
using Xunit;

namespace Sinoiov.OpenApi.Tests
{
    public class EnumExtensionsTests
    {
        [Fact]
        public void DescriptionTest()
        {
            var desc = Direction.East.GetDescription();
        }
    }
}
