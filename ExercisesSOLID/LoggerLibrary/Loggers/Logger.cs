using System;
using LoggerLibrary.Appenders.Interfaces;
using LoggerLibrary.Loggers.Interfaces;

namespace LoggerLibrary.Loggers
{
	public class Logger : ILogger
	{
        private readonly List<IAppender> appenders;

        public Logger(params IAppender[] appenders)
        {
            this.appenders = appenders.ToList();
        }

        public void Info(string dateTime, string message) => Log("Info", dateTime, message);
        public void Warning(string dateTime, string message) => Log("Warning", dateTime, message);
        public void Error(string dateTime, string message) => Log("Error", dateTime, message);
        public void Critical(string dateTime, string message) => Log("Critical", dateTime, message);
        public void Fatal(string dateTime, string message) => Log("Fatal", dateTime, message);

        private void Log(string level, string dateTime, string message)
        {
            foreach (var appender in appenders)
                appender.Append(dateTime, level, message);
        }
    }
}

