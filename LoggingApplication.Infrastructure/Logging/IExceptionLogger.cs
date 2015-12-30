using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoggingApplication.Infrastructure.Logging
{
    public interface IExceptionLogger
    {
        /// <summary>
        /// Logs exception information.
        /// </summary>
        /// <param name="exception">Exception that is throwned.</param>
        /// <param name="referenceId">Request reference id is optional.</param>
        /// <param name="variableFolderName">Optional sub-folder name, the log file will be put. Each Write method call can specify a different sub-folder for 
        /// its log and as variableFolderName parameter differs at each call, logs would be put in different files in different folders.
        /// <param name="errorCode">ErrorCode id is optional. If it is 0 , the transaction is succeded.</param>
        /// </param>
        void WriteException(Exception exception, string referenceId = null, string variableFolderName = null, int errorCode = 0);
    }
}
