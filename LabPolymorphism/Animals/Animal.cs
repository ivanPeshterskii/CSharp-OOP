namespace Animals
{
	public class Animal
	{
		public string Name { get; protected set; }

		public string FavouriteFood { get; protected set; }

		public Animal(string name, string food)
		{
			this.Name = name;
			this.FavouriteFood = food;
		}

		public virtual string ExplainSelf()
		{
			return $"I am {this.Name} and my fovourite food is {this.FavouriteFood}";
		}
    }
}