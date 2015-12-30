using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NLog.Targets;
using NLog.Targets.Wrappers;

namespace LoggingApplication.Infrastructure.Logging.NLog
{
    public class DefaultEventLogTarget : AsyncTargetWrapper
    {
        private readonly LogConfiguration logConfiguration;

        public DefaultEventLogTarget(LogConfiguration logConfiguration)
        {
            if (logConfiguration == null)
            {
                throw new ConfigurationErrorsException("LogConfiguration is not injected to DefaultEventLogTarget.");
            }

            this.logConfiguration = logConfiguration;

            string loggerName = logConfiguration.LoggerApplicationName;

            if (String.IsNullOrEmpty(loggerName))
            {
                loggerName = "DefaultEventLogTarget";
            }

            EventLogTarget eventLogTarget = new EventLogTarget();
            eventLogTarget.Category = "";
            eventLogTarget.Log = "";
            eventLogTarget.Source = "";

            this.Name = loggerName + "AsyncWrapper";
            this.QueueLimit = 9000;
            this.OverflowAction = AsyncTargetWrapperOverflowAction.Discard;
            this.WrappedTarget = eventLogTarget;
        }
    }
}
