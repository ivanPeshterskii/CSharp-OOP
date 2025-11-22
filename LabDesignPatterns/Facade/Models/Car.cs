using System;
namespace Facade.Models
{
	public class Car
	{
		public string Type { get; set; }

        public string Color { get; set; }

        public string City { get; set; }

        public string Street { get; set; }

        public override string ToString()
        {
            return $"Car: {this.Type}, Color: {this.Color}, Location: {this.City}, {this.Street}";
        }
    }
}

