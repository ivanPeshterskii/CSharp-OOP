using System;
using NUnit.Framework;

namespace Skeleton.Tests
{
    [TestFixture]
    public class AxeTests
    {
        [Test]
        public void AxeShouldLooseDurabilityAfterAttack()
        {
            // Arrange
            var axe = new Axe(10, 10);
            var dummy = new Dummy(10, 10);

            // Act
            axe.Attack(dummy);

            // Assert
            Assert.That(axe.DurabilityPoints, Is.EqualTo(9));
        }

        [Test]
        public void AxeShouldNotAttackWhenBroken()
        {
            // Arrange
            var axe = new Axe(10, -5);
            var dummy = new Dummy(100, 200);

            // Act
            axe.Attack(dummy);

            // Assert
            Assert.Throws<InvalidOperationException>(() =>
            {
                // Act
                axe.Attack(dummy);

            }, "Axe is broken.");
        }
    }
}