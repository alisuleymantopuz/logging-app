using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using NLog;

namespace LoggingApplication.Infrastructure.Logging.NLog
{
    public class NLogLogger : IEnhancedLogger
    {
        public IObjectSerializer ObjectSerializer { get; private set; }
        public LogConfiguration LogConfiguration { get; private set; }
        public Logger Logger { get; private set; }

        public NLogLogger(IObjectSerializer objectSerializer, LogConfiguration logConfiguration)
        {
            this.LogConfiguration = logConfiguration;
            this.ObjectSerializer = objectSerializer;
            this.Logger = LogManager.GetLogger(this.LogConfiguration.LoggerApplicationName); 
        }

        public void Write(string message, LoggerLevel loggerLevel, MethodBase callerMethod, Exception exception, List<object> arguments, object returnValue, string referenceId = null, string variableFolderName = null, int errorCode = 0)
        {
            LogEventInfo logEventInfo = new LogEventInfo();
            logEventInfo.LoggerName = this.Logger.Name;
            logEventInfo.Message = message;
            logEventInfo.TimeStamp = DateTime.Now;
            logEventInfo.Exception = exception;
            if (!String.IsNullOrEmpty(variableFolderName))
            {
                logEventInfo.Properties.Add("VariableFolderName", variableFolderName);
            }
            if (errorCode != 0)
            {
                logEventInfo.Properties.Add("ErrorCode", errorCode);
            }
            logEventInfo.Properties.Add("ReferenceId", referenceId);
            logEventInfo.Properties.Add("MethodName", callerMethod.Name);
            logEventInfo.Properties.Add("ClassFullName", (callerMethod.DeclaringType != null ? callerMethod.DeclaringType.FullName : ""));
            logEventInfo.Properties.Add("AssemblyFullName", (callerMethod.Module != null && callerMethod.Module.Assembly != null ? callerMethod.Module.Assembly.FullName : ""));
            logEventInfo.Properties.Add("EntryAssemblyFullName", (Assembly.GetEntryAssembly() != null ? Assembly.GetEntryAssembly().FullName : "(no entry assy)"));
            logEventInfo.Properties.Add("ArgumentList", (arguments != null ? this.ObjectSerializer.Serialize(arguments) : ""));
            logEventInfo.Properties.Add("ReturnValue", (returnValue != null ? this.ObjectSerializer.Serialize(returnValue) : ""));
            logEventInfo.Level = LogLevel.FromOrdinal((int)loggerLevel);

            this.Logger.Log(logEventInfo);
        }
    }
}
