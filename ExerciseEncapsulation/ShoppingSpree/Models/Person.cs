using System;
namespace ShoppingSpree.Models
{
	public class Person
	{
		private string name;
		private decimal money;

		public List<Product> Bag { get; private set; }

		public string Name
		{
			get => name;

			private set
			{
				if (string.IsNullOrWhiteSpace(value))
				{
					throw new ArgumentException("Name cannot be empty");
				}
				this.name = value;
			}
		}

		public decimal Money
		{
			get => money;

			private set
			{
				if (value < 0)
				{
					throw new ArgumentException("Money cannot be negative");
				}
				this.money = value;
			}
		}

		public Person(string name, decimal money)
		{
			this.Name = name;
			this.Money = money;
			Bag = new();
		}

		public void BuyProduct(Product product)
		{
			if (product.Cost <= Money)
			{
				Money -= product.Cost;
				Bag.Add(product);
				Console.WriteLine($"{Name} bought {product.Name}");
			}
			else
			{
				Console.WriteLine($"{Name} can't afford {product.Name}");
			}
		}

    }
}

