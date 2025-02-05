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

    [Test]
    public void StartAGameWithOneSingleSpaceShip()
    {
        var game = new Game();
        game.AddPlayer("Player1");
        game.Start("Player1", 'g', 0, 0);
        Assert.That(game.GetPlayer("Player1").Board[0,0], Is.EqualTo('g'));
    }

    [Test]
    public void StartTheGameWithOneMultiVerticalSpaceShip()
    {
        var game = new Game();
        game.AddPlayer("Player1");
        game.Start("Player1", 'd', 0, 0, true);
        Assert.That(game.GetPlayer("Player1").Board[0, 0], Is.EqualTo('d'));
        Assert.That(game.GetPlayer("Player1").Board[1, 0], Is.EqualTo('d'));
        Assert.That(game.GetPlayer("Player1").Board[2, 0], Is.EqualTo('d'));
    }

    [Test]
    public void StartTheGameWithOneMultiHorizontalSpaceShip()
    {
        var game = new Game();
        game.AddPlayer("Player1");
        game.Start("Player1", 'd', 1, 0, false);
        Assert.That(game.GetPlayer("Player1").Board[1, 0], Is.EqualTo('d'));
        Assert.That(game.GetPlayer("Player1").Board[1, 1], Is.EqualTo('d'));
        Assert.That(game.GetPlayer("Player1").Board[1, 2], Is.EqualTo('d'));
    }

}