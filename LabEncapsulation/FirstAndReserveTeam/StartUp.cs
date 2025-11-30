namespace PersonsInfo
{
	public class StartUp
	{
		public static void Main(string[] args)
		{
			int count = int.Parse(Console.ReadLine());

			for (int i = 0; i < count; i++)
			{
				string[] line = Console.ReadLine().Split();

				string firstName = line[0];
                string lastName = line[1];
				int age = int.Parse(line[2]);
				decimal salary = decimal.Parse(line[3]);

            }
        }
	}
}

