using System.Configuration;
using Microsoft.Extensions.Options;
using Sinoiov.OpenApi.ConfigurationSection;
using Sinoiov.OpenApi.Options;

namespace Sinoiov.OpenApi.Tests.TestBase
{
    public class LegacyConfigTestBase
    {
        protected IOptions<SinoiovOptions> SinoiovOptions { get; init; }

        public LegacyConfigTestBase()
        {
            var section = ConfigurationManager.GetSection(SinoiovConfigurationSection.DefaultConfigurationSectionName);
            if (section is SinoiovConfigurationSection sinoiovConfigurationSection)
            {
                SinoiovOptions = sinoiovConfigurationSection.ToOptionsWrapper();
            }
        }
    }
}
