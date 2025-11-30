using System;
namespace BirthdayCelebrations.Models.Interfaces
{
	public class Citizen : IIdentifiable, IBirthable
	{
        public Citizen(string name, int age, string id, string birthdate)
        {
            Name = name;
            Age = age;
            Id = id;
            BirthDay = birthdate;
        }

        public string Name { get; }
        public int Age { get; }
        public string Id { get; }
        public string BirthDay { get; }
    }
}

