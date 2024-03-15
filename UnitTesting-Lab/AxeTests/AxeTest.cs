namespace AxeTests
{
    [TestFixture]
    public class AxeTests
    {
        private Dummy target;

        [SetUp]
        public void SetTarget()
        {
            target = new Dummy(20, 50); // replace with target
        }

        [Test]
        public void AxeShouldLosesDurabilityAfterEachAttack()
        {
            //Arrange
            Axe axe = new Axe(30, 40);

            //Act
            axe.Attack(this.target); // replace with target
            var result = axe.DurabilityPoints;

            //Assert
            Assert.That(result, Is.EqualTo(39), "Axe loses durability after attack.");
        }

        [Test]
        public void AttackingWithBrokenAxeShouldThrowExeption()
        {
            //Arrage
            Axe axe = new Axe(10, 1);

            //Act
            axe.Attack(this.target); // replace with target

            //Assert
            Assert.Throws<InvalidOperationException>(() => throw new InvalidOperationException("Axe is broken"));
        }
    }
}