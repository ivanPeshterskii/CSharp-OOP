using NUnit.Framework;
using System;

namespace Skeleton.Tests
{
    [TestFixture]
    public class DummyTests
    {
        [Test]
        public void DummyLosesHealthIfAttacked()
        {
            // Arrange
            var axe = new Axe(10, 100);
            var dummy = new Dummy(100, 200);

            // Act
            axe.Attack(dummy);

            // Assert
            Assert.That(dummy.Health, Is.EqualTo(90));
        }

        [Test]
        public void DummyShouldNotBeAttackedWhenDead()
        {
            var axe = new Axe(10, 100);
            var dummy = new Dummy(0,200);

            Assert.Throws<InvalidOperationException>(() =>
            {
                axe.Attack(dummy);

            }, "Dummy is dead!");
        }

        [Test]
        public void DeadDummyCanGiveXp()
        {
            var dummy = new Dummy(0, 200);

            var result = dummy.GiveExperience();

            Assert.That(result, Is.EqualTo(200));
        }

        [Test]
        public void AliveDummyCannotGiveEx()
        {
            var dummy = new Dummy(100, 200);

            Assert.Throws<InvalidOperationException>(() =>
            {
                var result = dummy.GiveExperience();
            }, "Dummy can't give ex when alive!");
        }
    }
}