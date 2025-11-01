using System;
namespace PersonInfo
{
	public class Citizen : IPerson ,IIdentifiable, IBirthable
	{
        private string name;
        private int age;
        private string id;
        private string birthdate;


		public Citizen(string name, int age, string id, string birthDate)
		{
            this.Name = name;
            this.Age = age;
            this.Id = id;
            this.Birthdate = birthDate;
		}

        public string Id
        {
            get
            {
                return this.id;
            }
            private set
            {
                this.id = value;
            }
        }

        public string Birthdate
        {
            get
            {
                return this.birthdate;
            }
            private set
            {
                this.birthdate = value;
            }
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                this.name = value;
            }
        }

        public int Age
        {
            get
            {
                return this.age;
            }
            private set
            {
                this.age = value;
            }
        }
    }
}