using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LoggingApplication.Infrastructure.Resources;

namespace LoggingApplication.Infrastructure.Exceptions
{
    public class ApplicationSettingNotFoundException : SystemException
    {
        private string _notFoundedKey;

        public ApplicationSettingNotFoundException(string key)
        {
            this._notFoundedKey = key;
        }

        public override string Message
        {
            get
            {
                if (!string.IsNullOrEmpty(_notFoundedKey))
                {
                    return string.Format(ConfigurationResources.AppSettingNotFoundMessageWithKey, _notFoundedKey);
                }
                else
                {
                    return ConfigurationResources.AppSettingNotFoundMessage;
                }
            }
        }
    }
}
