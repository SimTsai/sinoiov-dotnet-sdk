using System.Configuration;
using Sinoiov.OpenApi.Options;

namespace Sinoiov.OpenApi.ConfigurationSection
{
    /// <summary>
    /// 中交兴路账号配置元素
    /// </summary>
    public partial class SinoiovAccountConfigurationElement : ConfigurationElement
    {
        private const string UserPropertyName = "user";
        private const string PasswordPropertyName = "password";
        private const string ClientIDPropertyName = "clientID";
        private const string SecretPropertyName = "secret";

        /// <summary>
        /// 用户名
        /// </summary>
        [ConfigurationProperty(UserPropertyName, IsRequired = true)]
        public virtual string User
        {
            get
            {
                return (string)base[UserPropertyName];
            }
            set
            {
                base[UserPropertyName] = value;
            }
        }

        /// <summary>
        /// 密码
        /// </summary>
        [ConfigurationProperty(PasswordPropertyName, IsRequired = true)]
        public virtual string Password
        {
            get
            {
                return (string)base[PasswordPropertyName];
            }
            set
            {
                base[PasswordPropertyName] = value;
            }
        }

        /// <summary>
        /// clientId
        /// </summary>
        [ConfigurationProperty(ClientIDPropertyName, IsRequired = true)]
        public virtual string ClientID
        {
            get
            {
                return (string)base[ClientIDPropertyName];
            }
            set
            {
                base[ClientIDPropertyName] = value;
            }
        }

        /// <summary>
        /// 私钥
        /// </summary>
        [ConfigurationProperty(SecretPropertyName, IsRequired = true)]
        public virtual string Secret
        {
            get
            {
                return (string)base[SecretPropertyName];
            }
            set
            {
                base[SecretPropertyName] = value;
            }
        }

        /// <summary>
        /// 将配置元素转换为对应Options
        /// </summary>
        /// <returns></returns>
        public virtual SinoiovAccountOptions ToOptions()
        {
            return new SinoiovAccountOptions
            {
                ClientID = this.ClientID,
                Password = this.Password,
                Secret = this.Secret,
                User = this.User
            };
        }

        /// <summary>
        /// 隐式转换为Options
        /// </summary>
        /// <param name="configurationElement">配置节元素</param>
        public static implicit operator SinoiovAccountOptions(SinoiovAccountConfigurationElement configurationElement)
        {
            return configurationElement.ToOptions();
        }
    }
}
