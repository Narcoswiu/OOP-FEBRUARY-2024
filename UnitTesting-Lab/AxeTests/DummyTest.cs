

using NUnit.Framework;

namespace AxeTests;


public class DummyTest
{
    private Dummy aliveDummy;
    private Dummy deadDummy;

    [SetUp]
    public void SetUpDummies()
    {
        deadDummy = new Dummy(0, 10);
        aliveDummy = new Dummy(40, 10);
    }

    [Test]
    public void DummyShouldLosesHealthIfAttacked()
    {
        // Arrange
        // Act
        aliveDummy.TakeAttack(30);

        // Assert
        Assert.That(this.aliveDummy.Health, Is.EqualTo(10));
    }

    [Test]
    public void DeadDummyShouldThrowsExceptionIfAttacked()
    {
        // Arrange
        // Act
        // Assert
        Assert.That(() => this.deadDummy.TakeAttack(30), Throws.InvalidOperationException.With.Message.EqualTo("Dummy is dead."), "Dead Dummy can't be attacked");
    }

    [Test]
    public void DeadDummyCanGiveXP()
    {
        // Arrange
        // Act
        var experience = this.deadDummy.GiveExperience();

        // Assert
        Assert.That(experience, Is.EqualTo(10), "Dead Dummy Can give experiance");
    }

    [Test]
    public void AliveDummyCantGiveXP()
    {
        // Arrange
        // Act
        // Assert
        Assert.That(() => this.aliveDummy.GiveExperience(), Throws.InvalidOperationException.With.Message.EqualTo("Target is not dead."));
    }
}
