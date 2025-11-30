using System;
namespace BirthdayCelebrations.Models.Interfaces
{
    public class Pet : IBirthable
    {
        public Pet(string name, string birthdate)
        {
            Name = name;
            BirthDay = birthdate;
        }

        public string Name { get; }
        public string BirthDay { get; }
    }
}