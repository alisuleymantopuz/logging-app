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
    public class AllFileTarget : AsyncTargetWrapper
    {
        private readonly LogConfiguration logConfiguration;

        public AllFileTarget(LogConfiguration logConfiguration)
        {
            if (logConfiguration == null)
            {
                throw new ConfigurationErrorsException("LogConfiguration is not injected to DefaultFileTarget.");
            }

            this.logConfiguration = logConfiguration;

            string rootFolder = logConfiguration.LogFilesRootFolder;

            if (String.IsNullOrEmpty(rootFolder))
            {
                rootFolder = "${basedir}";
            }

            FileTarget fileTarget = new FileTarget();
            fileTarget.Name = logConfiguration.LoggerApplicationName + "AllFileTarget";
            fileTarget.FileName =
                rootFolder.Remove(rootFolder.Length - 1) +
                rootFolder.Substring(rootFolder.Length - 1, 1).Replace(@"\", "").Replace(@"\", "") +
                "\\${logger}-All\\${logger}-${date:format=yyyy-MM-dd_HH'h':culture=tr-TR}.log";
            fileTarget.Layout =
                "${longdate} | Ref: ${event-context:item=ReferenceId} | Thread: ${threadid} ${threadname}" +
                "${when:when='${exception}'=='':inner=" +
                    "${newline}${message}" +
                "}" +
                "${onexception:inner=" +
                    "${newline}${literal:text=EXCEPTI0N!} ${message}" +
                    "${newline}${literal:text=ErrorCode\\: } ${event-context:item=ErrorCode} " +
                    "${newline}${literal:text=Entry\\: } ${event-context:item=EntryAssemblyFullName} " +
                    "${newline}${literal:text=Assy\\: }${event-context:item=AssemblyFullName} " +
                    "${newline}${literal:text=Class\\: }${event-context:item=ClassFullName} ${literal:text=Method\\: }${event-context:item=MethodName}" +
                    "${newline}${exception:format=ToString}" +
                "}" +
                "${when:when='${event-context:item=ArgumentList}'!='':inner=" +
                    "${newline}${literal:text=Arguments\\:} ${event-context:item=ArgumentList}" +
                "}" +
                "${when:when='${event-context:item=ReturnValue}'!='':inner=" +
                   "${newline}${literal:text=ReturnValue\\:} ${event-context:item=ReturnValue}" +
                "}" +
                "${newline}-------------------------------------------------------------------${newline}";
            fileTarget.ConcurrentWrites = true;
            fileTarget.ArchiveEvery = FileArchivePeriod.Hour;
            fileTarget.ArchiveNumbering = ArchiveNumberingMode.Sequence;
            fileTarget.ArchiveAboveSize = 5242880;
            fileTarget.ArchiveFileName =
                rootFolder.Remove(rootFolder.Length - 1) +
                rootFolder.Substring(rootFolder.Length - 1, 1).Replace(@"\", "").Replace(@"\", "") +
                "\\${logger}-All\\${logger}-${date:format=yyyy-MM-dd_HH'h':culture=tr-TR}.{####}.log"; ;
            fileTarget.MaxArchiveFiles = 9999;
            fileTarget.KeepFileOpen = true;

            this.Name = fileTarget.Name + "AsyncWrapper";
            this.QueueLimit = 500;
            this.OverflowAction = AsyncTargetWrapperOverflowAction.Grow;
            this.WrappedTarget = fileTarget;
        }
    }
}
