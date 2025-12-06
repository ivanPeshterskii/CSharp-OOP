using System;
namespace LegendsOfValor_TheGuildTrials.Models
{
	public class Warrior : Hero
	{
        private const int power = 60;
        private const int mana = 0;
        private const int stamina = 100;

		public Warrior(string name, string runeMark)
            : base(name, runeMark, power, mana, stamina)
		{
		}

        public override void Train()
        {
            Power += 30;
            Stamina += 10;
        }
    }
}

