using System.Diagnostics.Metrics;

namespace ShoppingSpree.Models
{
	public class StartUp
	{
		public static void Main(string[] args)
		{
            try
            {
                // Read people
                var peopleInput = Console.ReadLine().Split(';', StringSplitOptions.RemoveEmptyEntries);
                var people = new List<Person>();
                foreach (var personData in peopleInput)
                {
                    var parts = personData.Split('=');
                    string name = parts[0];
                    decimal money = decimal.Parse(parts[1]);
                    people.Add(new Person(name, money));
                }

                // Read products
                var productInput = Console.ReadLine().Split(';', StringSplitOptions.RemoveEmptyEntries);
                var products = new List<Product>();
                foreach (var productData in productInput)
                {
                    var parts = productData.Split('=');
                    string name = parts[0];
                    decimal cost = decimal.Parse(parts[1]);
                    products.Add(new Product(name, cost));
                }

                string command;
                while ((command = Console.ReadLine()) != "END")
                {
                    var parts = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                    string personName = parts[0];
                    string productName = parts[1];

                    var person = people.FirstOrDefault(p => p.Name == personName);
                    var product = products.FirstOrDefault(p => p.Name == productName);

                    if (person != null && product != null)
                    {
                        person.BuyProduct(product);
                    }
                }

                foreach (var person in people)
                {
                    string productsBought = person.Bag.Count > 0
                        ? string.Join(", ", person.Bag.Select(p => p.Name))
                        : "Nothing bought";

                    Console.WriteLine($"{person.Name} - {productsBought}");
                }
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}