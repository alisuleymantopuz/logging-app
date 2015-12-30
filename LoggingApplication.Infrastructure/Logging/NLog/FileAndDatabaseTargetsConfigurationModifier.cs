using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NLog.Config;
using NLog.Targets;
using NLog;

namespace LoggingApplication.Infrastructure.Logging.NLog
{
    public class FileAndDatabaseTargetsConfigurationModifier : ILoggingConfigurationModifier
    {
        private readonly LogConfiguration logConfiguration;

        public FileAndDatabaseTargetsConfigurationModifier(LogConfiguration logConfiguration)
        {
            this.logConfiguration = logConfiguration;
        }

        public LoggingConfiguration ModifyLoggingConfiguration(LoggingConfiguration loggingConfiguration)
        {
            if (loggingConfiguration == null)
            {
                loggingConfiguration = new LoggingConfiguration();
            }

            Target targetDb = new ExceptionLogDatabaseTarget(this.logConfiguration);
            loggingConfiguration.AddTarget(targetDb.Name, targetDb);

            Target targetExceptionFile = new ExceptionFileTarget(this.logConfiguration);
            loggingConfiguration.AddTarget(targetExceptionFile.Name, targetExceptionFile);

            Target variableFolderTarget = new VariableFolderFileTarget(this.logConfiguration);
            loggingConfiguration.AddTarget(variableFolderTarget.Name, variableFolderTarget);

            loggingConfiguration.LoggingRules.Add(new LoggingRule(this.logConfiguration.LoggerApplicationName, LogLevel.Error, targetExceptionFile));
            loggingConfiguration.LoggingRules.Add(new LoggingRule(logConfiguration.LoggerApplicationName, LogLevel.Trace, variableFolderTarget));
            loggingConfiguration.LoggingRules.Add(new LoggingRule(this.logConfiguration.LoggerApplicationName, LogLevel.Error, targetDb));

            return loggingConfiguration;
        }
    }
}
