using System.Configuration;
using Microsoft.Extensions.Caching.StackExchangeRedis;
using StackExchange.Redis;

namespace Sinoiov.OpenApi.ConfigurationSection
{
    /// <summary>
    /// Redis Token存储相关配置元素
    /// </summary>
    public partial class SinoiovRedisOptionsConfigurationElement : ConfigurationElement
    {
        private const string ConnectionStringPropertyName = "connectionString";
        private const string InstanceNamePropertyName = "instanceName";

        /// <summary>
        /// 因为配置元素属性不能以config开头所以此处将
        /// Configuration 重命名为 ConnectionString
        /// <seealso cref="RedisCacheOptions.Configuration"/>
        /// </summary>
        [ConfigurationProperty(ConnectionStringPropertyName)]
        public virtual string ConnectionString
        {
            get
            {
                return (string)base[ConnectionStringPropertyName];
            }
            set
            {
                base[ConnectionStringPropertyName] = value;
            }
        }

        /// <summary>
        /// <seealso cref="RedisCacheOptions.InstanceName"/>
        /// </summary>
        [ConfigurationProperty(InstanceNamePropertyName)]
        public virtual string InstanceName
        {
            get
            {
                return (string)base[InstanceNamePropertyName];
            }
            set
            {
                base[InstanceNamePropertyName] = value;
            }
        }

        /// <summary>
        /// 将配置节转换为对应Options
        /// </summary>
        /// <returns></returns>
        public virtual RedisCacheOptions ToOptions()
        {
            return new RedisCacheOptions
            {
                Configuration = this.ConnectionString,
                InstanceName = this.InstanceName,
                ConfigurationOptions = ConfigurationOptions.Parse(this.ConnectionString)
            };
        }

        /// <summary>
        /// 隐式转换为Options
        /// </summary>
        /// <param name="configurationElement"></param>
        public static implicit operator RedisCacheOptions(SinoiovRedisOptionsConfigurationElement configurationElement)
        {
            return configurationElement.ToOptions();
        }
    }
}
