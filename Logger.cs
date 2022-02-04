using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flex.Console
{
	using NLog;
	using NLog.Targets;

	public class Logger
	{
		// Singleton
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

		static NLog.Logger? _logger = null;

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
			var encoding = Encoding.UTF8;
			var date = System.DateTime.Now.ToString("yyyMMdd");
			var layout = "${date:format=yyyy-MM-dd HH\\:mm\\:ss} [${uppercase:${level:padding=-5}}] ${message} ${exception} ${event-properties:myProperty}";

			var console = new ColoredConsoleTarget("logconsole") {
				Encoding = encoding,
				Layout = layout,
				UseDefaultRowHighlightingRules = true
			};

			var logfile = new FileTarget("logfile") {
				Encoding = encoding,
				Layout = layout,
				FileName = $"logs/{date}.log"
			};

			// Rules for mapping loggers to targets
			config.AddRule(LogLevel.Trace, LogLevel.Fatal, console);
			config.AddRule(LogLevel.Info, LogLevel.Fatal, logfile);

			// Apply config
			NLog.LogManager.Configuration = config;
		}
	}
}
