using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoggingApplication.Infrastructure.Logging
{
    public class ExceptionLogger : IExceptionLogger
    {
        public IEnhancedLogger EnhancedLogger { get; private set; }

        public ExceptionLogger(IEnhancedLogger enhancedLogger)
        {
            this.EnhancedLogger = enhancedLogger;
        }

        public void WriteException(Exception exception, string referenceId = null, string variableFolderName = null, int errorCode = 0)
        {
            this.EnhancedLogger.Write(exception.Message, LoggerLevel.Error, exception.TargetSite, exception, null, null, referenceId: referenceId,
                variableFolderName: variableFolderName, errorCode: errorCode);
        }
    }
}
