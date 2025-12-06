namespace MythicLegion.Tests
{
    using System;
    using NUnit.Framework;
    using MythicLegion;

    [TestFixture]
    public class LegionTests
    {
        private Hero CreateHero(string name)
        {
            return new Hero(name, "Type");
        }

        [Test]
        public void AddHero_ShouldAddHeroSuccessfully()
        {
            
            var legion = new Legion();
            var hero = CreateHero("Thorne");

            
            legion.AddHero(hero);
            var result = legion.GetLegionInfo();

            
            Assert.That(result, Does.Contain("Thorne"));
        }

        [Test]
        public void AddHero_NullHero_ShouldThrowArgumentNullException()
        {
            
            var legion = new Legion();

            
            Assert.Throws<ArgumentNullException>(() => legion.AddHero(null));
        }

        [Test]
        public void AddHero_DuplicateHero_ShouldThrowArgumentException()
        {
            
            var legion = new Legion();
            var hero = CreateHero("Thorne");
            legion.AddHero(hero);

            
            Assert.Throws<ArgumentException>(() => legion.AddHero(hero));
        }

        [Test]
        public void RemoveHero_ShouldRemoveExistingHero()
        {
            
            var legion = new Legion();
            var hero = CreateHero("Thorne");
            legion.AddHero(hero);

           
            bool removed = legion.RemoveHero("Thorne");
            var info = legion.GetLegionInfo();

            
            Assert.IsTrue(removed);
            Assert.That(info, Does.Not.Contain("Thorne"));
        }

        [Test]
        public void RemoveHero_NonExistingHero_ShouldReturnFalse()
        {
            
            var legion = new Legion();

            
            bool removed = legion.RemoveHero("NonExistent");

            
            Assert.IsFalse(removed);
        }

        [Test]
        public void TrainHero_ShouldIncreaseStats()
        {
            
            var legion = new Legion();
            var hero = CreateHero("Thorne");
            legion.AddHero(hero);

            
            string result = legion.TrainHero("Thorne");

            
            Assert.AreEqual("Thorne has been trained.", result);
            Assert.AreEqual(10, hero.Power);
            Assert.AreEqual(1, hero.Health);
            Assert.IsTrue(hero.IsTrained);
        }

        [Test]
        public void TrainHero_NonExistingHero_ShouldReturnErrorMessage()
        {
            
            var legion = new Legion();

            string result = legion.TrainHero("NonExistent");

            
            Assert.AreEqual("Hero with name NonExistent not found.", result);
        }

        [Test]
        public void GetLegionInfo_EmptyLegion_ShouldReturnNoHeroesMessage()
        {
            
            var legion = new Legion();

           
            string result = legion.GetLegionInfo();

           
            Assert.AreEqual("No heroes in the legion.", result);
        }
    }
}
