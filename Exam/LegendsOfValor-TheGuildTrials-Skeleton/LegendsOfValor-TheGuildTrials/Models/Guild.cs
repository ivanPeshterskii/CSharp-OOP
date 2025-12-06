using System;
using LegendsOfValor_TheGuildTrials.Models.Contracts;
using LegendsOfValor_TheGuildTrials.Utilities.Messages;

namespace LegendsOfValor_TheGuildTrials.Models
{
	public class Guild : IGuild
	{
        private string name;
        private int wealth;
        private readonly List<string> legion;
        private bool isFallen;


		public Guild(string name)
		{
            this.Name = name;
            this.legion = new List<string>();
            this.Wealth = 5000;
            this.IsFallen = false;
		}

        public string Name
        {
            get => this.name;

            private set
            {
                if(value!= "WarriorGuild" && value!= "SorcererGuild"&&value!= "ShadowGuild")
                {
                    throw new ArgumentException(ErrorMessages.InvalidGuildName);
                }
                this.name = value;
            }
        }

        public int Wealth
        {
            get => this.wealth;

            private set
            {
                this.wealth = value;
            }
        }

        public IReadOnlyCollection<string> Legion => this.legion.AsReadOnly();

        public bool IsFallen
        {
            get => this.isFallen;

            private set
            {
                this.isFallen = value;
            }
        }

        public void LoseWar()
        {
            this.IsFallen = true;
            this.Wealth = 0;
        }

        public void RecruitHero(IHero hero)
        {
            this.legion.Add(hero.Name);
            this.Wealth -= 500;
        }

        public void TrainLegion(ICollection<IHero> heroesToTrain)
        {
            foreach (var h in heroesToTrain)
            {
                this.Wealth -= 200;
                h.Train();
            }
        }

        public void WinWar(int goldAmount)
        {
            this.Wealth += goldAmount;
        }
    }
}