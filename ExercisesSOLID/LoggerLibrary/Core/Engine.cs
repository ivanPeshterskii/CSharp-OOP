using System;
using LoggerLibrary.Appenders;
using LoggerLibrary.Appenders.Interfaces;
using LoggerLibrary.Core.Interfaces;
using LoggerLibrary.Enums;
using LoggerLibrary.Files;
using LoggerLibrary.Layouts;
using LoggerLibrary.Layouts.Interfaces;
using LoggerLibrary.Loggers;
using LoggerLibrary.Loggers.Interfaces;

namespace LoggerLibrary.Core
{
    public class Engine : IEngine
    {
        public void Run()
        {
            int numberOfAppenders = int.Parse(Console.ReadLine());
            List<IAppender> appenders = new();

            for (int i = 0; i < numberOfAppenders; i++)
            {
                string[] parts = Console
                    .ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string type = parts[0];
                string layout = parts[1];

                ReportLevel reportLevel = parts.Length == 3
                    ? Enum.Parse<ReportLevel>(parts[2], true)
                    : ReportLevel.Info;

                ILayout layout1 = layout switch
                {
                    "SimpleLayout" => new SimpleLayout(),
                    "XmlLayout" => new XmlLayout(),
                    _ => throw new Exception("Invalid layout type!")
                };

                IAppender appender = type switch
                {
                    "ConsoleAppender" => new ConsoleAppender(layout1) { ReportLevel = reportLevel },
                    "FileAppender" => new FileAppender(layout1, new LogFile()) { ReportLevel = reportLevel },
                    _ => throw new Exception("Invalid appender!")
                };
                appenders.Add(appender);
            }

            ILogger logger = new Logger(appenders.ToArray());

            string input = string.Empty;
            while((input = Console.ReadLine()) != "END")
            {
                string[] tokens = input
                    .Split('|', StringSplitOptions.RemoveEmptyEntries);

                string type = tokens[0];
                string dateTime = tokens[1];
                string message = tokens[2];

                switch (type)
                {
                    case "INFO": logger.Info(dateTime, message); break;
                    case "WARNING": logger.Warning(dateTime, message); break;
                    case "ERROR": logger.Error(dateTime, message); break;
                    case "CRITICAL": logger.Critical(dateTime, message); break;
                    case "FATAL": logger.Fatal(dateTime, message); break;
                }
            }

            Console.WriteLine("Logger info");
            foreach (var appender in appenders)
            {
                Console.WriteLine(appender.ToString());
            }

            Console.ReadKey();
        }
    }
}

