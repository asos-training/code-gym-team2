namespace CodeGymTests;

using CodeGym;

public class AGameShould
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void AddAFirstPlayer()
    {
        var game = new Game();
        Assert.That(game.AddPlayer("Player1"), Is.EqualTo("Added Player Player1"));
    }

    [Test]
    public void AddASecondPLayer()
    {
        var game = new Game();
        game.AddPlayer("Player1");
        Assert.That(game.AddPlayer("Player2"), Is.EqualTo("Added Player Player2"));
    }

    [Test]
    public void ThrowWhenAddingAThirdPLayer()
    {
        var game = new Game();
        game.AddPlayer("Player1");
        game.AddPlayer("Player2");
        Assert.That(() => game.AddPlayer("Player3"), Throws.TypeOf<ArgumentOutOfRangeException>().With.Message.EqualTo("Specified argument was out of the range of valid values."));
    }

    }