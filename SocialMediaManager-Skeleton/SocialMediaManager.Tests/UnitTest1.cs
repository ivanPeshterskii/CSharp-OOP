using System;
using NUnit.Framework;
using System.Linq;
using System.Collections.Generic;

namespace SocialMediaManager.Tests
{
    public class Tests
    {
        private InfluencerRepository repo;
        private Influencer inf;

        [SetUp]
        public void Setup()
        {
            repo = new InfluencerRepository();
            inf = new Influencer("Ivan", 1000);
        }

        [Test]
        public void Constructor_ShouldInitializeEmptyCollection()
        {
            Assert.AreEqual(0, repo.Influencers.Count);
        }

        [Test]
        public void RegisterInfluencer_ShouldThrow_WhenNullIsPassed()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                repo.RegisterInfluencer(null);
            });
        }

        [Test]
        public void RegisterInfluencer_ShouldThrow_WhenUsernameExists()
        {
            repo.RegisterInfluencer(inf);

            Assert.Throws<InvalidOperationException>(() =>
            {
                repo.RegisterInfluencer(new Influencer("Ivan", 500));
            });
        }

        [Test]
        public void RegisterInfluencer_ShouldAddInfluencer()
        {
            string result = repo.RegisterInfluencer(inf);

            Assert.AreEqual(1, repo.Influencers.Count);
            Assert.AreEqual("Ivan", repo.Influencers.First().Username);
        }

        [Test]
        public void RegisterInfluencer_ShouldReturnCorrectMessage()
        {
            string result = repo.RegisterInfluencer(inf);

            Assert.AreEqual("Successfully added influencer Ivan with 1000", result);
        }

        [Test]
        public void RemoveInfluencer_ShouldThrow_WhenUsernameIsNull()
        {
            Assert.Throws<ArgumentNullException>(() => repo.RemoveInfluencer(null));
            Assert.Throws<ArgumentNullException>(() => repo.RemoveInfluencer(""));
        }

        [Test]
        public void RemoveInfluencer_ShouldReturnTrue_WhenRemoved()
        {
            repo.RegisterInfluencer(inf);

            bool removed = repo.RemoveInfluencer("Ivan");

            Assert.IsTrue(removed);
            Assert.AreEqual(0, repo.Influencers.Count);
        }

        [Test]
        public void RemoveInfluencer_ShouldReturnFalse_WhenUsernameDoesNotExist()
        {
            bool removed = repo.RemoveInfluencer("Nonexistent");

            Assert.IsFalse(removed);
        }

        [Test]
        public void GetInfluencer_ShouldReturnCorrectInfluencer()
        {
            repo.RegisterInfluencer(inf);

            var result = repo.GetInfluencer("Ivan");

            Assert.AreEqual(inf, result);
        }

        [Test]
        public void GetInfluencer_ShouldReturnNull_WhenNotFound()
        {
            var result = repo.GetInfluencer("Unknown");

            Assert.IsNull(result);
        }

        [Test]
        public void GetInfluencerWithMostFollowers_ShouldReturnCorrectInfluencer()
        {
            repo.RegisterInfluencer(new Influencer("A", 100));
            repo.RegisterInfluencer(new Influencer("B", 500));
            repo.RegisterInfluencer(new Influencer("C", 300));

            var result = repo.GetInfluencerWithMostFollowers();

            Assert.AreEqual("B", result.Username);
        }

        [Test]
        public void GetInfluencerWithMostFollowers_ShouldThrow_WhenEmpty()
        {
            Assert.Throws<IndexOutOfRangeException>(() =>
            {
                repo.GetInfluencerWithMostFollowers();
            });
        }
    }
}