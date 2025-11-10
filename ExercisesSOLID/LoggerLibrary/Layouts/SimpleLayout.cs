using System;
using LoggerLibrary.Layouts.Interfaces;

namespace LoggerLibrary.Layouts
{
    public class SimpleLayout : ILayout
    {
        public string Format(string dateTime, string reportLevel, string message)
        {
            return $"{dateTime} - {reportLevel.ToUpper()} - {message}";
        }
    }
}

