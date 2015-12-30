using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Castle.MicroKernel.SubSystems.Configuration; 
using LoggingApplication.Infrastructure.Configuration;

namespace LoggingApplication.Infrastructure.Logging
{
    public class LogConfiguration
    {
        public IConfigurationBase ConfigurationStore { get; private set; }

        public LogConfiguration(IConfigurationBase configurationStore)
        {
            ConfigurationStore = configurationStore;
        }

        public int LoggerLevel
        {
            get
            {
                return this.ConfigurationStore.GetValue<int>("LoggerLevel", KeyRequirement.Required);
            }
        }

        public string LogFilesRootFolder
        {
            get
            {
                return this.ConfigurationStore.GetValue<string>("LogFilesRootFolder", KeyRequirement.Required); 
            }
        }

        public string LoggerApplicationName
        {
            get
            {
                return this.ConfigurationStore.GetValue<string>("LoggerApplicationName", KeyRequirement.Required); 
            }
        }

        public string LogDatabaseConnectionString
        {
            get 
            {
                return this.ConfigurationStore.GetValue<string>("LogDatabaseConnectionString", KeyRequirement.Optional); 
            }
        }

        public string LogDatabaseProvider
        {
            get 
            {
                return this.ConfigurationStore.GetValue<string>("LogDatabaseProvider", KeyRequirement.Optional); 
            }
        }
    }
}
