using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using LegendsOfValor_TheGuildTrials.Core.Contracts;
using LegendsOfValor_TheGuildTrials.Models.Contracts;
using LegendsOfValor_TheGuildTrials.Repositories.Contratcs;
using LegendsOfValor_TheGuildTrials.Repositories;
using LegendsOfValor_TheGuildTrials.Utilities.Messages;
using LegendsOfValor_TheGuildTrials.Models;

namespace LegendsOfValor_TheGuildTrials.Core
{
    public class Controller : IController
    {
        private readonly IRepository<IHero> heroes;
        private readonly IRepository<IGuild> guilds;

        public Controller()
        {
            this.heroes = new HeroRepository();
            this.guilds = new GuildRepository();
        }

        private int CalculateGuildPower(IGuild guild)
        {
            return guild.Legion
                        .Select(r => heroes.GetAll().First(h => h.RuneMark == r))
                        .Sum(h => h.Power + h.Mana + h.Stamina);
        }

        public string AddHero(string heroTypeName, string heroName, string runeMark)
        {
            if (heroTypeName != nameof(Warrior) && heroTypeName != nameof(Sorcerer) && heroTypeName != nameof(Spellblade))
            {
                return string.Format(OutputMessages.InvalidHeroType, heroTypeName);
            }

            if (heroes.GetAll().Any(h => h.RuneMark == runeMark))
            {
                return string.Format(OutputMessages.HeroAlreadyExists, runeMark);
            }

            IHero hero = heroTypeName switch
            {
                nameof(Warrior) => new Warrior(heroName, runeMark),
                nameof(Sorcerer) => new Sorcerer(heroName, runeMark),
                nameof(Spellblade) => new Spellblade(heroName, runeMark),
                _ => null
            };

            heroes.AddModel(hero);
            return string.Format(OutputMessages.HeroAdded, heroTypeName, heroName, runeMark);
        }

        public string CreateGuild(string guildName)
        {
            if (guilds.GetAll().Any(g => g.Name == guildName))
            {
                return string.Format(OutputMessages.GuildAlreadyExists, guildName);
            }

            IGuild guild = new Guild(guildName);
            guilds.AddModel(guild);
            return string.Format(OutputMessages.GuildCreated, guildName);
        }

        public string RecruitHero(string runeMark, string guildName)
        {
            IHero hero = heroes.GetAll().FirstOrDefault(h => h.RuneMark == runeMark);
            if (hero == null)
            {
                return string.Format(OutputMessages.HeroNotFound, runeMark);
            }

            IGuild guild = guilds.GetAll().FirstOrDefault(g => g.Name == guildName);
            if (guild == null)
            {
                return string.Format(OutputMessages.GuildNotFound, guildName);
            }

            if (!string.IsNullOrEmpty(hero.GuildName))
            {
                return string.Format(OutputMessages.HeroAlreadyInGuild, hero.Name);
            }

            if (guild.IsFallen)
            {
                return string.Format(OutputMessages.GuildIsFallen, guild.Name);
            }

            if (guild.Wealth < 500)
            {
                return string.Format(OutputMessages.GuildCannotAffordRecruitment, guild.Name);
            }

            string heroType = hero.GetType().Name;
            bool allowed = heroType switch
            {
                nameof(Warrior) => guildName == "WarriorGuild" || guildName == "ShadowGuild",
                nameof(Sorcerer) => guildName == "SorcererGuild" || guildName == "ShadowGuild",
                nameof(Spellblade) => guildName == "WarriorGuild" || guildName == "SorcererGuild",
                _ => false
            };

            if (!allowed)
            {
                return string.Format(OutputMessages.HeroTypeNotCompatible, heroType, guildName);
            }

            guild.RecruitHero(hero);

            return string.Format(OutputMessages.HeroRecruited, hero.Name, guild.Name);
        }

        public string TrainingDay(string guildName)
        {
            IGuild guild = guilds.GetAll().FirstOrDefault(g => g.Name == guildName);
            if (guild == null)
            {
                return string.Format(OutputMessages.GuildNotFound, guildName);
            }

            if (guild.IsFallen)
            {
                return string.Format(OutputMessages.GuildTrainingDayIsFallen, guildName);
            }

            int countHeroes = guild.Legion.Count;
            int totalCost = 200 * countHeroes;

            if (guild.Wealth < totalCost)
            {
                return string.Format(OutputMessages.TrainingDayFailed, guildName);
            }

            var heroesToTrain = heroes.GetAll()
                                      .Where(h => guild.Legion.Contains(h.RuneMark))
                                      .ToList();

            guild.TrainLegion(heroesToTrain);
            return string.Format(OutputMessages.TrainingDayStarted, guildName, heroesToTrain.Count, totalCost);
        }

        public string StartWar(string attackerGuildName, string defenderGuildName)
        {
            IGuild attacker = guilds.GetAll().FirstOrDefault(g => g.Name == attackerGuildName);
            IGuild defender = guilds.GetAll().FirstOrDefault(g => g.Name == defenderGuildName);

            if (attacker == null || defender == null)
            {
                return string.Format(OutputMessages.OneOfTheGuildsDoesNotExist);
            }

            if (attacker.IsFallen || defender.IsFallen)
            {
                return string.Format(OutputMessages.OneOfTheGuildsIsFallen);
            }

            int attackerPower = CalculateGuildPower(attacker);
            int defenderPower = CalculateGuildPower(defender);

            if (attackerPower > defenderPower)
            {
                int goldTaken = defender.Wealth;
                attacker.WinWar(goldTaken);
                defender.LoseWar();
                return string.Format(OutputMessages.WarWon, attackerGuildName, defenderGuildName, goldTaken);
            }
            else
            {
                int goldTaken = attacker.Wealth;
                defender.WinWar(goldTaken);
                attacker.LoseWar();
                return string.Format(OutputMessages.WarLost, defenderGuildName, goldTaken, attackerGuildName);
            }
        }

        public string ValorState()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Valor State:");

            var orderedGuilds = guilds.GetAll().OrderByDescending(g => g.Wealth).ToList();

            foreach (var guild in orderedGuilds)
            {
                sb.AppendLine($"{guild.Name} (Wealth: {guild.Wealth})");

                var orderedHeroes = guild.Legion
                                         .Select(r => heroes.GetAll().First(h => h.RuneMark == r))
                                         .OrderBy(h => h.Name);

                foreach (var hero in orderedHeroes)
                {
                    sb.AppendLine(hero.ToString());
                    sb.AppendLine(hero.Essence());
                }
            }

            return sb.ToString();
        }
    }
}