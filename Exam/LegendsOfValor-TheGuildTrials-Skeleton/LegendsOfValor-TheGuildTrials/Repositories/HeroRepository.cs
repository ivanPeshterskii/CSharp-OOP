using System;
using LegendsOfValor_TheGuildTrials.Models.Contracts;
using LegendsOfValor_TheGuildTrials.Repositories.Contratcs;

namespace LegendsOfValor_TheGuildTrials.Repositories
{
	public class HeroRepository : IRepository<IHero>
	{
        private readonly List<IHero> heroes;

        public HeroRepository()
        {
            this.heroes = new List<IHero>();
        }

        public void AddModel(IHero entity)
        {
            this.heroes.Add(entity);
        }

        public IReadOnlyCollection<IHero> GetAll()
        {
            return this.heroes.AsReadOnly();
        }

        public IHero GetModel(string runeMarkOrGuildName)
        {
            return this.heroes.FirstOrDefault(h => h.RuneMark == runeMarkOrGuildName);
        }
    }
}