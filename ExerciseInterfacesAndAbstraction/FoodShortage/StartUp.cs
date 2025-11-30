using System;
namespace FoodShortage.Models.Interfaces
{
	public class StartUp
	{
		public static void Main()
		{
			Dictionary<string, IBuyer> people = new();

			int n = int.Parse(Console.ReadLine());
			for (int i = 0; i < n; i++)
			{
				string[] parts = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

				if(parts.Length == 4)
				{
					string name = parts[0];
					int age = int.Parse(parts[1]);
					string id = parts[2];
					string date = parts[3];

					people[name] = new Citizen(name, age, id, date);
				}
				else if(parts.Length == 3)
				{
					string name = parts[0];
                    int age = int.Parse(parts[1]);
					string group = parts[2];

					people[name] = new Rebel(name, age, group);
                }
			}

			string input = string.Empty;
			while((input = Console.ReadLine()) != "End")
			{
				if (people.ContainsKey(input))
				{
					people[input].BuyFood();
				}
			}

			int totalFood = people.Values.Sum(p => p.Food);
			Console.WriteLine(totalFood);
		}
	}
}

