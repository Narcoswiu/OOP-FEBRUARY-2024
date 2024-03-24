using System;
using System.Linq;
using System.Runtime.CompilerServices;
using NUnit.Framework.Legacy;

namespace FightingArena.Tests
{
    using NUnit.Framework;

    [TestFixture]
    public class ArenaTests
    {
        private Arena arena;

        [SetUp]
        public void Setup()
        {
            arena = new Arena();
        }

        [Test]
        public void ArenaConstructorShouldWorkCorrectly()
        {
            ClassicAssert.IsNotNull(arena);
            ClassicAssert.IsNotNull(arena.Warriors);
        }

        [Test]
        public void ArenaCountShouldWorkCorrectly()
        {
            int expectedResult = 1;

            Warrior warrior = new Warrior("Gosho", 5, 100);

            arena.Enroll(warrior);
            ClassicAssert.AreEqual(expectedResult,arena.Count);
        }

        [Test]
        public void ArenaEnrollShouldWorkCorrectly()
        {

            Warrior warrior = new Warrior("Gosho", 5, 100);

            arena.Enroll(warrior);
            ClassicAssert.IsNotEmpty(arena.Warriors); 
            ClassicAssert.AreEqual(warrior, arena.Warriors.Single());
        }


        [Test]
        public void ArenaEnrollShouldThrowExceptionIfWarriorIsAlreadyEnrolled()
        {
            Warrior warrior = new("Gosho", 5, 100);

            arena.Enroll(warrior);

            InvalidOperationException exception = Assert.Throws<InvalidOperationException>(()
                => arena.Enroll(warrior));

            ClassicAssert.AreEqual("Warrior is already enrolled for the fights!", exception.Message);
        }

        [Test]
        public void ArenaFightShouldWorkCorrectly()
        {
            Warrior attacker = new("Gosho", 15, 100);
            Warrior defender = new("Pesho", 5, 50);

            arena.Enroll(attacker);
            arena.Enroll(defender);

            int expectedAttackerHp = 95;
            int expectedDefenderHp = 35;

            arena.Fight(attacker.Name, defender.Name);

            ClassicAssert.AreEqual(expectedAttackerHp, attacker.HP);
            ClassicAssert.AreEqual(expectedDefenderHp, defender.HP);
        }

        [Test]
        public void ArenaFightShouldThrowExceptionIfAttackerNotFound()
        {
            Warrior attacker = new("Gosho", 15, 100);
            Warrior defender = new("Pesho", 5, 50);

            arena.Enroll(defender);

            InvalidOperationException exception = Assert.Throws<InvalidOperationException>(()
                => arena.Fight(attacker.Name, defender.Name));

            ClassicAssert.AreEqual($"There is no fighter with name {attacker.Name} enrolled for the fights!", exception.Message);
        }

        [Test]
        public void ArenaFightShouldThrowExceptionIfDefenderNotFound()
        {
            Warrior attacker = new("Gosho", 15, 100);
            Warrior defender = new("Pesho", 5, 50);

            arena.Enroll(attacker);

            InvalidOperationException exception = Assert.Throws<InvalidOperationException>(()
                => arena.Fight(attacker.Name, defender.Name));

            ClassicAssert.AreEqual($"There is no fighter with name {defender.Name} enrolled for the fights!", exception.Message);
        }

    }
}
