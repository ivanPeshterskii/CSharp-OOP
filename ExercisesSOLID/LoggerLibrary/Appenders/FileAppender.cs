using System;
using LoggerLibrary.Appenders.Interfaces;
using LoggerLibrary.Enums;
using LoggerLibrary.Files;
using LoggerLibrary.Layouts.Interfaces;

namespace LoggerLibrary.Appenders
{
	public class FileAppender : IAppender
	{
        private readonly ILayout layout;
        private readonly LogFile file;
        public ReportLevel ReportLevel { get; set; } = ReportLevel.Info;
        private int messagesAppended;

        public FileAppender(ILayout layout, LogFile file)
        {
            this.layout = layout;
            this.file = file;
        }

        public void Append(string dateTime, string reportLevel, string message)
        {
            if (Enum.Parse<ReportLevel>(reportLevel) < ReportLevel) return;

            string formatted = layout.Format(dateTime, reportLevel, message);
            file.Write(formatted);
            messagesAppended++;
        }

        public override string ToString()
        {
            return $"Appender type: {GetType().Name}, Layout type: {layout.GetType().Name}, Report level: {ReportLevel}, Messages appended: {messagesAppended}";
        }
    }
}

