using System;
using NLog;
using NLog.Config;
using NLog.Targets;
using Pocket.Logging.NLog;

namespace Pocket.Logging.Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            ConfigureLogging(".", "Pocket.Logging.Demo");

            var loggerFactory = NLogLoggingSystem.Create();

            LogThings(loggerFactory);
        }

        private static void LogThings(LoggerFactory loggerFactory)
        {
            var logger = loggerFactory.Logger();

            try
            {
                logger.Trace().Log("some simple trace");
                logger.Debug().Log("...and debug");
                logger.Info().Log("Current time is: {0}", DateTime.Now);
                logger.Warn().Log("It is going to blow soon!!!");
                logger.Error().Log(new Exception("Minor exception"));
                throw new Exception("Major exception");
            }
            catch (Exception e)
            {
                logger.Fatal().Log(e);
            }

            logger.Info().Log("Press <enter>...");
            Console.ReadLine();
        }

        #region NLog configuration

        private static void ConfigureLogging(string folder, string productName)
        {
            var config = new LoggingConfiguration();
            ConfigureConsoleLogging(config);
            LogManager.Configuration = config;
        }

        private static void ConfigureConsoleLogging(LoggingConfiguration config)
        {
            var console = new ColoredConsoleTarget {
                Name = "console",
                Layout = "[${level}] ${logger}: ${message}",
                UseDefaultRowHighlightingRules = true,
                ErrorStream = false,
            };
            console.RowHighlightingRules.Add(
                new ConsoleRowHighlightingRule(
                    "level == LogLevel.Trace",
                    ConsoleOutputColor.DarkGray,
                    ConsoleOutputColor.NoChange));
            console.RowHighlightingRules.Add(
                new ConsoleRowHighlightingRule(
                    "level == LogLevel.Debug",
                    ConsoleOutputColor.Gray,
                    ConsoleOutputColor.NoChange));
            console.RowHighlightingRules.Add(
                new ConsoleRowHighlightingRule(
                    "level == LogLevel.Info",
                    ConsoleOutputColor.Cyan,
                    ConsoleOutputColor.NoChange));
            console.RowHighlightingRules.Add(
                new ConsoleRowHighlightingRule(
                    "level == LogLevel.Warn",
                    ConsoleOutputColor.Yellow,
                    ConsoleOutputColor.NoChange));
            console.RowHighlightingRules.Add(
                new ConsoleRowHighlightingRule(
                    "level == LogLevel.Error",
                    ConsoleOutputColor.Red,
                    ConsoleOutputColor.NoChange));
            console.RowHighlightingRules.Add(
                new ConsoleRowHighlightingRule(
                    "level == LogLevel.Fatal",
                    ConsoleOutputColor.Magenta,
                    ConsoleOutputColor.NoChange));
            config.AddTarget("console", console);

            config.LoggingRules.Add(new LoggingRule("*", LogLevel.Trace, console));
        }

        #endregion
    }
}
