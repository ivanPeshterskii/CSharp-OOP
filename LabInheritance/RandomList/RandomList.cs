using System;
namespace CustomRandomList
{
	public class RandomList : List<string>
	{
		private Random random;

		public RandomList()
		{
			this.random = new Random();
		}

		public string RandomString()
		{
			var randomIndex = this.random.Next(0, this.Count);

			var value = this[randomIndex];

			this.RemoveAt(randomIndex);

			return value;
		}
	}
}

