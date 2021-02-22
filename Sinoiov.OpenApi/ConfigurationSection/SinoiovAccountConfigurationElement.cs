using Sinoiov.OpenApi.Options;
using System.Configuration;

namespace Sinoiov.OpenApi.ConfigurationSection
{
    public partial class SinoiovAccountConfigurationElement : ConfigurationElement
    {
        private const string UserPropertyName = "user";
        private const string PasswordPropertyName = "password";
        private const string ClientIDPropertyName = "clientID";
        private const string SecretPropertyName = "secret";

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

        public static implicit operator SinoiovAccountOptions(SinoiovAccountConfigurationElement configurationElement)
        {
            return configurationElement.ToOptions();
        }
    }
}
