using System;
namespace PizzaCalories.Models
{
	public class Dough
	{
		private string flourType;
		private string bakingTechnique;
		private double weight;

		private Dictionary<string, double> flourTypesCalories;
        private Dictionary<string, double> bakingTechniquesCalories;

        public string FlourType { get; private set; }

        public string BakingType { get; private set; }

        public double Weight { get; private set; }

        public Dough(string flourType, string bakingType, double weight)
		{
			this.FlourType = flourType;
			this.BakingType = bakingType;
			this.Weight = weight;

			flourTypesCalories = new()
			{
				{"white", 1.5 },
				{ "wholegrain", 1.0}
			};

			bakingTechniquesCalories = new()
			{
				{ "crispy", 0.9},
				{ "chewy", 1.1},
				{ "homemade", 1.0}
			};
		}
	}
}