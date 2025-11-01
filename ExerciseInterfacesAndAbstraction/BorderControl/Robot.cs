using System;
namespace BorderControl
{
	public class Robot : IIdentifiable
	{
		public string Model { get; }

		public string Id { get; }


		public Robot(string model, string id)
		{
			Model = model;
			Id = id;
		}
	}
}

