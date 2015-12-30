using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace LoggingApplication.Infrastructure.Logging
{
    public interface IEnhancedLogger
    {
        /// <summary>
        /// Log message.
        /// </summary>
        /// <param name="message">Message to be logged</param>
        /// <param name="loggerLevel">Logger level type informatioan</param>
        /// <param name="callerMethod">The method that is entered or to be entered.</param>
        /// <param name="exception">Exception that is throwned.</param>
        /// <param name="arguments">Paramaters that sent to the method that is exited or to be exited.</param>
        /// <param name="returnValue">Returning object that is returned or to be returned from the method that is exited or to be exited.</param>
        /// <param name="referenceId">Request reference id is optional.</param>
        /// <param name="variableFolderName">Optional sub-folder name, the log file will be put. Each Write method call can specify a different sub-folder for 
        /// its log and as variableFolderName parameter differs at each call, logs would be put in different files in different folders.
        /// <param name="errorCode">ErrorCode id is optional. If it is 0 , the transaction is succeded.</param>
        /// </param>
        void Write(string message, LoggerLevel loggerLevel, MethodBase callerMethod, Exception exception, List<object> arguments, object returnValue, string referenceId = null, string variableFolderName = null, int errorCode = 0);
    }
}
