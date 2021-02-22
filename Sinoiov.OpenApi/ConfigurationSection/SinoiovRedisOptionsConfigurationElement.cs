using Microsoft.Extensions.Caching.StackExchangeRedis;
using StackExchange.Redis;
using System.Configuration;

namespace Sinoiov.OpenApi.ConfigurationSection
{
    public partial class SinoiovRedisOptionsConfigurationElement : ConfigurationElement
    {
        private const string ConnectionStringPropertyName = "connectionString";
        private const string InstanceNamePropertyName = "instanceName";

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

        public virtual RedisCacheOptions ToOptions()
        {
            return new RedisCacheOptions
            {
                Configuration = this.ConnectionString,
                InstanceName = this.InstanceName,
                ConfigurationOptions = ConfigurationOptions.Parse(this.ConnectionString)
            };
        }

        public static implicit operator RedisCacheOptions(SinoiovRedisOptionsConfigurationElement configurationElement)
        {
            return configurationElement.ToOptions();
        }
    }
}
