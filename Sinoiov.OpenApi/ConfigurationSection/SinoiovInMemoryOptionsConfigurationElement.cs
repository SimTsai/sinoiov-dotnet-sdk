using System;
using System.Configuration;
using Microsoft.Extensions.Caching.Memory;

namespace Sinoiov.OpenApi.ConfigurationSection
{
    /// <summary>
    /// 进程内Token存储相关配置元素
    /// </summary>
    public partial class SinoiovInMemoryOptionsConfigurationElement : ConfigurationElement
    {
        private const string ExpirationScanFrequencyPropertyName = "expirationScanFrequency";
        private const string SizeLimitPropertyName = "sizeLimit";
        private const string CompactionPercentagePropertyName = "compactionPercentage";

        /// <summary>
        /// <seealso cref="MemoryCacheOptions.ExpirationScanFrequency"/>
        /// </summary>
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

        /// <summary>
        /// <seealso cref="MemoryCacheOptions.SizeLimit"/>
        /// </summary>
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

        /// <summary>
        /// <seealso cref="MemoryCacheOptions.CompactionPercentage"/>
        /// </summary>
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

        /// <summary>
        /// 将配置元素转换为对应OptionsWrapper
        /// </summary>
        /// <returns></returns>
        public virtual MemoryDistributedCacheOptions ToOptions()
        {
            return new MemoryDistributedCacheOptions
            {
                ExpirationScanFrequency = this.ExpirationScanFrequency,
                SizeLimit = this.SizeLimit,
                CompactionPercentage = this.CompactionPercentage
            };
        }

        /// <summary>
        /// 隐式转换为Options
        /// </summary>
        /// <param name="configurationElement"></param>
        public static implicit operator MemoryDistributedCacheOptions(SinoiovInMemoryOptionsConfigurationElement configurationElement)
        {
            return configurationElement.ToOptions();
        }
    }
}
