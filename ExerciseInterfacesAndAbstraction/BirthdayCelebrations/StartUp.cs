using System;
using BirthdayCelebrations.Models.Interfaces;

namespace BirthdayCelebrations
{
	public class StartUp
	{
		public static void Main()
		{
            List<IBirthable> birthables = new List<IBirthable>();

            string input;
            while ((input = Console.ReadLine()) != "End")
            {
                string[] parts = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string type = parts[0];

                if (type == "Citizen")
                {
                    string name = parts[1];
                    int age = int.Parse(parts[2]);
                    string id = parts[3];
                    string birthdate = parts[4];

                    birthables.Add(new Citizen(name, age, id, birthdate));
                }
                else if (type == "Pet")
                {
                    string name = parts[1];
                    string birthdate = parts[2];

                    birthables.Add(new Pet(name, birthdate));
                }
                
            }

            string year = Console.ReadLine();

            foreach (var entity in birthables)
            {
                if (entity.BirthDay.EndsWith(year))
                {
                    Console.WriteLine(entity.BirthDay);
                }
            }
        }
	}
}

