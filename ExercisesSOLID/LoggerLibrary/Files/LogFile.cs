using System;
using System.Text;

namespace LoggerLibrary.Files
{
	public class LogFile
	{
        private readonly StringBuilder content = new();

        public void Write(string message)
        {
            content.AppendLine(message);
        }

        public int Size => content
            .ToString()
            .Where(char.IsLetter)
            .Sum(ch => ch);
    }
}

