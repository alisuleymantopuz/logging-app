using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NLog.Targets;
using NLog.Targets.Wrappers;

namespace LoggingApplication.Infrastructure.Logging.NLog
{
    public class ExceptionLogDatabaseTarget : AsyncTargetWrapper
    {
        private readonly LogConfiguration logConfiguration;

        public ExceptionLogDatabaseTarget(LogConfiguration logConfiguration)
        {
            if (logConfiguration == null)
            {
                throw new ConfigurationErrorsException("LogConfiguration is not injected to ExceptionLogDatabaseTarget.");
            }

            this.logConfiguration = logConfiguration;

            DatabaseTarget databaseTarget = new DatabaseTarget();
            databaseTarget.ConnectionString = logConfiguration.LogDatabaseConnectionString;

            SqlConnectionStringBuilder csBuilder = new SqlConnectionStringBuilder(logConfiguration.LogDatabaseConnectionString);
            databaseTarget.DBDatabase = csBuilder.InitialCatalog;
            databaseTarget.DBHost = csBuilder.DataSource;
            databaseTarget.DBPassword = csBuilder.Password;
            databaseTarget.DBProvider = "sqlserver";
            databaseTarget.DBUserName = csBuilder.UserID;

            databaseTarget.Name = logConfiguration.LoggerApplicationName + "ExceptionLogDatabaseTarget";

            databaseTarget.CommandText =
                "INSERT INTO " + logConfiguration.LoggerApplicationName.Replace(" ", "") + "ExceptionLog " +
                    "(ReferenceID, ExceptionLogDate, MethodName, ClassFullName, AssemblyFullName, EntryAssemblyFullName, ExceptionType, [Message], StackTrace, FullException, ErrorCode) VALUES " +
                    "(@ReferenceId, @ExceptionLogDate, @MethodName, @ClassFullName, @AssemblyFullName, @EntryAssemblyFullName, @ExceptionType, @Message, @StackTrace, @FullException, @ErrorCode)";

            databaseTarget.Parameters.Add(new DatabaseParameterInfo("@ReferenceId", "${event-context:item=ReferenceId}"));
            databaseTarget.Parameters.Add(new DatabaseParameterInfo("@ExceptionLogDate", "${date:format=yyyy-MM-dd HH\\:mm\\:ss.fff:culture=tr-TR}"));
            databaseTarget.Parameters.Add(new DatabaseParameterInfo("@MethodName", "${event-context:item=MethodName}"));
            databaseTarget.Parameters.Add(new DatabaseParameterInfo("@ClassFullName", "${event-context:item=ClassFullName}"));
            databaseTarget.Parameters.Add(new DatabaseParameterInfo("@AssemblyFullName", "${event-context:item=AssemblyFullName}"));
            databaseTarget.Parameters.Add(new DatabaseParameterInfo("@EntryAssemblyFullName", "${event-context:item=EntryAssemblyFullName}"));
            databaseTarget.Parameters.Add(new DatabaseParameterInfo("@ExceptionType", "${exception:format=Type}"));
            databaseTarget.Parameters.Add(new DatabaseParameterInfo("@Message", "${message}"));
            databaseTarget.Parameters.Add(new DatabaseParameterInfo("@StackTrace", "${stacktrace}"));
            databaseTarget.Parameters.Add(new DatabaseParameterInfo("@FullException", "${exception:format=ToString}"));
            databaseTarget.Parameters.Add(new DatabaseParameterInfo("@ErrorCode", "${event-context:item=ErrorCode}"));

            this.Name = databaseTarget.Name + "AsyncWrapper";
            this.QueueLimit = 9000;
            this.OverflowAction = AsyncTargetWrapperOverflowAction.Discard;
            this.WrappedTarget = databaseTarget;
        }
    }
}
