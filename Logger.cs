using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Flex.Console
{
	using NLog;

	public class Logger
	{
		static NLog.Logger logger
		{
			get {
				if (_logger == null) {
					InitializeConfiguration();
					_logger = NLog.LogManager.GetCurrentClassLogger();
				}

				return _logger;
			}
		}
		static NLog.Logger _logger = null;

		// Properties
		public static void Trace(string msg) => logger.Trace(msg);
		public static void Debug(string msg) => logger.Debug(msg);
		public static void Info(string msg) => logger.Info(msg);
		public static void Warn(string msg) => logger.Warn(msg);
		public static void Error(string msg) => logger.Error(msg);
		public static void Fatal(string msg) => logger.Fatal(msg);


		/// <summary>
		/// NLog.Config Wrapper.
		/// </summary>
		static void InitializeConfiguration()
		{
			var config = new NLog.Config.LoggingConfiguration();

			// Targets where to log to: File and Console
			var date = System.DateTime.Now.ToString("yyyMMdd");
			var logfile = new NLog.Targets.FileTarget("logfile") { FileName = $"logs/{date}.log" };
			var logconsole = new NLog.Targets.ConsoleTarget("logconsole");

			// Rules for mapping loggers to targets            
			config.AddRule(LogLevel.Info, LogLevel.Fatal, logconsole);
			config.AddRule(LogLevel.Debug, LogLevel.Fatal, logfile);

			// Apply config           
			NLog.LogManager.Configuration = config;
		}
	}
}
