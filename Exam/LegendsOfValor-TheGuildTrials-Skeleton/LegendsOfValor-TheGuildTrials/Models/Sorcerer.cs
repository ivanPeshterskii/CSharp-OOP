using System;
namespace LegendsOfValor_TheGuildTrials.Models
{
	public class Sorcerer : Hero
	{
        private const int power = 40;
        private const int mana = 120;
        private const int stamina = 0;

        public Sorcerer(string name, string runeMark)
            :base(name, runeMark, power, mana, stamina)
		{
		}

        public override void Train()
        {
            Power += 20;
            Mana += 25;
        }
    }
}

