using System;
namespace BorderControl
{
	public class StartUp
	{
		public static void Main()
		{
            List<IIdentifiable> entities = new List<IIdentifiable>();

            string input = string.Empty;
			while((input = Console.ReadLine()) != "End")
			{
				string[] parts = input
					.Split(' ', StringSplitOptions.RemoveEmptyEntries);

				if(parts.Length == 3)
				{
					string name = parts[0];
					int age = int.Parse(parts[1]);
					string id = parts[2];

					entities.Add(new Citizen(name, age, id));
				}
				else if(parts.Length == 2)
				{
					string model = parts[0];
					string id = parts[1];

					entities.Add(new Robot(model, id));
				}
			}

			string fake = Console.ReadLine();

			foreach (var entity in entities)
			{
				if (entity.Id.EndsWith(fake))
				{
					Console.WriteLine(entity.Id);
				}
			}
		}
	}
}

