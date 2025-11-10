using System;
using LoggerLibrary.Appenders.Interfaces;
using LoggerLibrary.Enums;
using LoggerLibrary.Layouts.Interfaces;

namespace LoggerLibrary.Appenders
{
	public class ConsoleAppender : IAppender
	{
        private readonly ILayout layout;
        public ReportLevel ReportLevel { get; set; } = ReportLevel.Info;
        private int messagesAppended;

        public ConsoleAppender(ILayout layout)
        {
            this.layout = layout;
        }

        public void Append(string dateTime, string reportLevel, string message)
        {
            if (Enum.Parse<ReportLevel>(reportLevel) < ReportLevel) return;

            Console.WriteLine(layout.Format(dateTime, reportLevel, message));
            messagesAppended++;
        }

        public override string ToString()
        {
            return $"Appender type: {GetType().Name}, Layout type: {layout.GetType().Name}, Report level: {ReportLevel}, Messages appended: {messagesAppended}";
        }
    }
}

