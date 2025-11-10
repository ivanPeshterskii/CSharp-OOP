using System;
namespace LoggerLibrary.Layouts.Interfaces
{
	public interface ILayout
	{
		string Format(string dateTime, string reportLevel, string message);
	}
}

