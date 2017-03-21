using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace Pocket.Logging
{
    public enum Severity { Debug, Trace, Info, Warn, Error, Fatal }
    public delegate Logger LoggerFactory(string name);
    public delegate void Logger(Severity severity, Func<string> builder);
    public delegate void Channel(Func<string> factory);

    public static class LoggerFactoryExtensions
    {
        public static Logger Logger(this LoggerFactory factory, string name) =>
            factory(name);

        public static Logger Logger(this LoggerFactory factory, Type type) =>
            factory.Logger(type.FullName);
        public static Logger Logger<T>(this LoggerFactory factory) =>
            factory.Logger(typeof(T));
        [MethodImpl(MethodImplOptions.NoInlining)]
        public static Logger Logger(this LoggerFactory factory) =>
            factory.Logger(new StackTrace().GetFrame(1).GetMethod().DeclaringType);
    }

    public static partial class LoggerExtensions
    {
        public static Channel Channel(this Logger logger, Severity severity) =>
            builder => logger(severity, builder);

        public static Channel Debug(this Logger logger) => logger.Channel(Severity.Debug);
        public static Channel Trace(this Logger logger) => logger.Channel(Severity.Trace);
        public static Channel Info(this Logger logger) => logger.Channel(Severity.Info);
        public static Channel Warn(this Logger logger) => logger.Channel(Severity.Warn);
        public static Channel Error(this Logger logger) => logger.Channel(Severity.Error);
        public static Channel Fatal(this Logger logger) => logger.Channel(Severity.Fatal);
    }

    public static class ChannelExtensions
    {
        public static void Log(this Channel channel, Func<string> factory) =>
            channel(factory);

        public static void Log(this Channel channel, string message) =>
            channel.Log(() => message);
        public static void Log(this Channel channel, string pattern, params object[] args) =>
            channel.Log(() => string.Format(pattern, args));
        public static void Log(this Channel channel, Exception error) =>
            channel.Log(error.ToString);
    }
}
