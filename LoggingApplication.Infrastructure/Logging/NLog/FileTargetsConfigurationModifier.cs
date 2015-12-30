using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NLog;
using NLog.Config;
using NLog.Targets;

namespace LoggingApplication.Infrastructure.Logging.NLog
{
    public class FileTargetsConfigurationModifier : ILoggingConfigurationModifier
    {
        private readonly LogConfiguration logConfiguration;

        public FileTargetsConfigurationModifier(LogConfiguration logConfiguration)
        {
            this.logConfiguration = logConfiguration;
        }

        public LoggingConfiguration ModifyLoggingConfiguration(LoggingConfiguration loggingConfiguration)
        {
            if (loggingConfiguration == null)
            {
                loggingConfiguration = new LoggingConfiguration();
            }

            Target targetExceptionFile = new ExceptionFileTarget(this.logConfiguration);
            loggingConfiguration.AddTarget(targetExceptionFile.Name, targetExceptionFile);

            Target variableFolderFileTarget = new VariableFolderFileTarget(this.logConfiguration);
            loggingConfiguration.AddTarget(variableFolderFileTarget.Name, variableFolderFileTarget);

            loggingConfiguration.LoggingRules.Add(new LoggingRule(logConfiguration.LoggerApplicationName, LogLevel.Error, targetExceptionFile));
            loggingConfiguration.LoggingRules.Add(new LoggingRule(logConfiguration.LoggerApplicationName, LogLevel.Trace, variableFolderFileTarget));

            return loggingConfiguration;
        }
    }
}
