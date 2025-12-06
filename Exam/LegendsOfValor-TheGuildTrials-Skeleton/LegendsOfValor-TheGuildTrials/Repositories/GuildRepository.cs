using System;
using LegendsOfValor_TheGuildTrials.Models.Contracts;
using LegendsOfValor_TheGuildTrials.Repositories.Contratcs;

namespace LegendsOfValor_TheGuildTrials.Repositories
{
	public class GuildRepository : IRepository<IGuild>
	{
        private readonly List<IGuild> guilds;

		public GuildRepository()
		{
            this.guilds = new List<IGuild>();
		}

        public void AddModel(IGuild entity)
        {
            this.guilds.Add(entity);
        }

        public IReadOnlyCollection<IGuild> GetAll()
        {
            return this.guilds.AsReadOnly();
        }

        public IGuild GetModel(string runeMarkOrGuildName)
        {
            return this.guilds.FirstOrDefault(g => g.Name == runeMarkOrGuildName);
        }
    }
}

