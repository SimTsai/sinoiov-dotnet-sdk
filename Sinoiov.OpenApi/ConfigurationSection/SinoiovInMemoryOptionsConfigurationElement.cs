using Microsoft.Extensions.Caching.Memory;
using System;
using System.Configuration;

namespace Sinoiov.OpenApi.ConfigurationSection
{
    public partial class SinoiovInMemoryOptionsConfigurationElement : ConfigurationElement
    {
        private const string ExpirationScanFrequencyPropertyName = "expirationScanFrequency";
        private const string SizeLimitPropertyName = "sizeLimit";
        private const string CompactionPercentagePropertyName = "compactionPercentage";

        [ConfigurationProperty(ExpirationScanFrequencyPropertyName)]
        public virtual TimeSpan ExpirationScanFrequency
        {
            get
            {
                return (TimeSpan)base[ExpirationScanFrequencyPropertyName];
            }
            set
            {
                base[ExpirationScanFrequencyPropertyName] = value;
            }
        }

        [ConfigurationProperty(SizeLimitPropertyName)]
        public virtual long? SizeLimit
        {
            get
            {
                return (long?)base[SizeLimitPropertyName];
            }
            set
            {
                base[SizeLimitPropertyName] = value;
            }
        }

        [ConfigurationProperty(CompactionPercentagePropertyName)]
        public virtual double CompactionPercentage
        {
            get
            {
                return (double)base[CompactionPercentagePropertyName];
            }
            set
            {
                base[CompactionPercentagePropertyName] = value;
            }
        }

        public virtual MemoryDistributedCacheOptions ToOptions()
        {
            return new MemoryDistributedCacheOptions
            {
                ExpirationScanFrequency = this.ExpirationScanFrequency,
                SizeLimit = this.SizeLimit,
                CompactionPercentage = this.CompactionPercentage
            };
        }

        public static implicit operator MemoryDistributedCacheOptions(SinoiovInMemoryOptionsConfigurationElement configurationElement)
        {
            return configurationElement.ToOptions();
        }
    }
}
