using System;
using System.Reflection;
using System.Text;

namespace Stealer
{
	public class Spy
	{
		public string StealFieldInfo(string className, params string[] fieldName)
		{
			Console.WriteLine($"Class under investigation: {className}");

			var type = Type.GetType(className);

			var fields = type.GetFields(BindingFlags.Instance
				| BindingFlags.NonPublic
				| BindingFlags.Public);

			var searched = fields
				.Where(f => fieldName.Contains(f.Name))
				.ToList();

			var instance = Activator.CreateInstance(type);

			var result = new StringBuilder();

			foreach (var field in searched)
			{
				var value = field.GetValue(instance);

				result.AppendLine($"{field.Name} = {value}");
			}

			return result.ToString();
		}

    }
}

