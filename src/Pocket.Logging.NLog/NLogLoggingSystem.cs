using NLog;

namespace Pocket.Logging.NLog
{
    public static class NLogLoggingSystem
    {
        public static LoggerFactory Create()
        {
            return name => {
                var logger = LogManager.GetLogger(name);
                return (severity, builder) => {
                    var level = ToLogLevel(severity);
                    if (logger.IsEnabled(level))
                        logger.Log(level, builder());
                };
            };
        }

        private static LogLevel ToLogLevel(Severity severity)
        {
            switch (severity)
            {
                case Severity.Trace: return LogLevel.Trace;
                case Severity.Debug: return LogLevel.Debug;
                case Severity.Info: return LogLevel.Info;
                case Severity.Warn: return LogLevel.Warn;
                case Severity.Error: return LogLevel.Error;
                case Severity.Fatal: return LogLevel.Fatal;
                default: return LogLevel.Off;
            }
        }
    }
}
