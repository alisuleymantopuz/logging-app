using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LoggingApplication.Infrastructure.Exceptions;

namespace LoggingApplication.Infrastructure.Configuration
{
    public class ConfigurationBase : IConfigurationBase
    {
        public T GetValue<T>(string key, KeyRequirement keyRequirement)
        {
            var appSetting = ConfigurationManager.AppSettings[key];
            if (string.IsNullOrWhiteSpace(appSetting) && keyRequirement == KeyRequirement.Required)
            {
                throw new ApplicationSettingNotFoundException(key);
            }

            var converter = TypeDescriptor.GetConverter(typeof(T));

            return (T)(converter.ConvertFromInvariantString(appSetting));
        }

        public string GetValue(string key, KeyRequirement keyRequirement)
        {
            var appSetting = ConfigurationManager.AppSettings[key];
            if (string.IsNullOrWhiteSpace(appSetting) && keyRequirement == KeyRequirement.Required)
            {
                throw new ApplicationSettingNotFoundException(key);
            }
            return appSetting;
        }

        public string GetStringValue(string key)
        {
            var appSetting = ConfigurationManager.AppSettings[key];
            return appSetting;
        }
    }
}
