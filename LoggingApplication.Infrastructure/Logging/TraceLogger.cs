using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace LoggingApplication.Infrastructure.Logging
{
    public class TraceLogger : ITraceLogger
    {
        public IEnhancedLogger EnhancedLogger { get; private set; }

        public TraceLogger(IEnhancedLogger enhancedLogger)
        {
            this.EnhancedLogger = enhancedLogger;
        }

        public void WriteInfo(string message, MethodBase callerMethod, string referenceId = null, string variableFolderName = null)
        {
            this.EnhancedLogger.Write(message, LoggerLevel.Info, callerMethod,null,null,null,referenceId: referenceId, variableFolderName: variableFolderName);
        }

        public void Write(string message, LoggerLevel loggerLevel, MethodBase callerMethod, string referenceId = null, string variableFolderName = null)
        {
            this.EnhancedLogger.Write(message, loggerLevel, callerMethod, null, null, null, referenceId: referenceId, variableFolderName: variableFolderName);
        }
    }
}
