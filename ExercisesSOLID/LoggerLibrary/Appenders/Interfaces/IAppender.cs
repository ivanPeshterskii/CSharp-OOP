using System;
using LoggerLibrary.Enums;

namespace LoggerLibrary.Appenders.Interfaces
{
	public interface IAppender
	{
		ReportLevel ReportLevel { get; set; }
		void Append(string dateTime, string reportLevel, string message);
	}
}

