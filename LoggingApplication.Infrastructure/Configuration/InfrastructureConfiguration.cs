using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoggingApplication.Infrastructure.Configuration
{
    public class InfrastructureConfiguration 
    {
        public IConfigurationBase ConfigurationStore { get; private set; }

        public InfrastructureConfiguration(IConfigurationBase configurationStore)
        {
            ConfigurationStore = configurationStore;
        }

        public string ApplicationKey { get { return this.ConfigurationStore.GetStringValue("ApplicationKey"); } }

        public string ApplicationName { get { return this.ConfigurationStore.GetStringValue("ApplicationName"); } }

        public string ApplicationVersion { get { return this.ConfigurationStore.GetStringValue("ApplicationVersion"); } }

        public string ApplicationDescription { get { return this.ConfigurationStore.GetStringValue("ApplicationDescription"); } }
    }
}
