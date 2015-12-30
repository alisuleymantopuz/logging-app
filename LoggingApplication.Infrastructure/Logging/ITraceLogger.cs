using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace LoggingApplication.Infrastructure.Logging
{
    public interface ITraceLogger
    {
        /// <summary>
        /// Logs info message.
        /// </summary>
        /// <param name="message">Message to be logged</param>
        /// <param name="callerMethod">The method that is entered or to be entered.</param>
        /// <param name="referenceId">Request reference id is optional.</param>
        /// <param name="variableFolderName">Optional sub-folder name, the log file will be put. Each Write method call can specify a different sub-folder for 
        /// its log and as variableFolderName parameter differs at each call, logs would be put in different files in different folders.
        /// </param>
        void WriteInfo(string message, MethodBase callerMethod, string referenceId = null, string variableFolderName = null);

        /// <summary>
        /// Log message.
        /// </summary>
        /// <param name="message">Message to be logged</param>
        /// <param name="loggerLevel">Logger level type informatioan</param>
        /// <param name="callerMethod">The method that is entered or to be entered.</param>
        /// <param name="referenceId">Request reference id is optional.</param>
        /// <param name="variableFolderName">Optional sub-folder name, the log file will be put. Each Write method call can specify a different sub-folder for 
        /// its log and as variableFolderName parameter differs at each call, logs would be put in different files in different folders.
        /// </param>
        void Write(string message, LoggerLevel loggerLevel, MethodBase callerMethod, string referenceId = null, string variableFolderName = null);

    }
}
