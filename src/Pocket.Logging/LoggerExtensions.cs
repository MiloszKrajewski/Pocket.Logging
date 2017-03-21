using System;

namespace Pocket.Logging 
{
	public static partial class LoggerExtensions
	{
		#region Debug

		public static void Debug(this Logger logger, Func<string> builder) =>
			logger.Debug().Log(builder);
		public static void Debug(this Logger logger, string message) =>
			logger.Debug().Log(message);
		public static void Debug(this Logger logger, string pattern, params object[] args) =>
			logger.Debug().Log(pattern, args);
		public static void Debug(this Logger logger, Exception exception) =>
			logger.Debug().Log(exception);

		#endregion

		#region Trace

		public static void Trace(this Logger logger, Func<string> builder) =>
			logger.Trace().Log(builder);
		public static void Trace(this Logger logger, string message) =>
			logger.Trace().Log(message);
		public static void Trace(this Logger logger, string pattern, params object[] args) =>
			logger.Trace().Log(pattern, args);
		public static void Trace(this Logger logger, Exception exception) =>
			logger.Trace().Log(exception);

		#endregion

		#region Info

		public static void Info(this Logger logger, Func<string> builder) =>
			logger.Info().Log(builder);
		public static void Info(this Logger logger, string message) =>
			logger.Info().Log(message);
		public static void Info(this Logger logger, string pattern, params object[] args) =>
			logger.Info().Log(pattern, args);
		public static void Info(this Logger logger, Exception exception) =>
			logger.Info().Log(exception);

		#endregion

		#region Warn

		public static void Warn(this Logger logger, Func<string> builder) =>
			logger.Warn().Log(builder);
		public static void Warn(this Logger logger, string message) =>
			logger.Warn().Log(message);
		public static void Warn(this Logger logger, string pattern, params object[] args) =>
			logger.Warn().Log(pattern, args);
		public static void Warn(this Logger logger, Exception exception) =>
			logger.Warn().Log(exception);

		#endregion

		#region Error

		public static void Error(this Logger logger, Func<string> builder) =>
			logger.Error().Log(builder);
		public static void Error(this Logger logger, string message) =>
			logger.Error().Log(message);
		public static void Error(this Logger logger, string pattern, params object[] args) =>
			logger.Error().Log(pattern, args);
		public static void Error(this Logger logger, Exception exception) =>
			logger.Error().Log(exception);

		#endregion

		#region Fatal

		public static void Fatal(this Logger logger, Func<string> builder) =>
			logger.Fatal().Log(builder);
		public static void Fatal(this Logger logger, string message) =>
			logger.Fatal().Log(message);
		public static void Fatal(this Logger logger, string pattern, params object[] args) =>
			logger.Fatal().Log(pattern, args);
		public static void Fatal(this Logger logger, Exception exception) =>
			logger.Fatal().Log(exception);

		#endregion
	}
}
