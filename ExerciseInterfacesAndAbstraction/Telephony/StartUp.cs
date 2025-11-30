namespace Telephony.Models
{
	public class StartUp
	{
		public static void Main(string[] args)
		{
			string[] phoneNumbers = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string[] urls = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

			foreach (string phoneNumber in phoneNumbers)
			{
					try
					{
						if (phoneNumber.Length == 10)
						{
							Smartphone sm = new Smartphone();
							Console.WriteLine(sm.Call(phoneNumber));
						}
						else
						{
							StationaryPhone st = new StationaryPhone();
							Console.WriteLine(st.Call(phoneNumber));
						}
                        
					}
					catch (ArgumentException ex)
					{
						Console.WriteLine(ex.Message);
					}
				
			}

			foreach (string url in urls)
			{
				try
				{
					Smartphone smartphone = new Smartphone();
					Console.WriteLine(smartphone.Browse(url));
				}
				catch (ArgumentException ex)
				{
					Console.WriteLine(ex.Message);
				}
			}
        }
	}
}