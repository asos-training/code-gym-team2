namespace CodeGymTests;

using CodeGym;
using Microsoft.VisualStudio.CodeCoverage;

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
        Assert.That(game.AddPlayer("Player1", []), Is.EqualTo("Added Player Player1"));
    }

    [Test]
    public void AddASecondPLayer()
    {
        var game = new Game();
        game.AddPlayer("Player1", []);
        Assert.That(game.AddPlayer("Player2", []), Is.EqualTo("Added Player Player2"));
    }

    [Test]
    public void ThrowWhenAddingAThirdPLayer()
    {
        var game = new Game();
        game.AddPlayer("Player1", []);
        game.AddPlayer("Player2", []);
        Assert.That(() => game.AddPlayer("Player3", []), Throws.TypeOf<ArgumentOutOfRangeException>().With.Message.EqualTo("Specified argument was out of the range of valid values."));
    }

    [Test]
    public void StartAGameWithOneSingleSpaceShip()
    {
        var game = new Game();
        var ships = new List<Ship>() { new Ship('g', 0, 0, false) };
        game.AddPlayer("Player1", ships);
        game.Start("Player1");
        Assert.That(game.GetPlayer("Player1").Board[0, 0], Is.EqualTo('g'));
    }

    [Test]
    public void TwoPlayersStartAGameWithAGunboatEach()
    {
        var game = new Game();
        var playerOneShips = new List<Ship>() { new Ship('g', 0, 0, false) };
        var playerTwoShips = new List<Ship>() { new Ship('g', 5, 5, false) };
        game.AddPlayer("Player1", playerOneShips);
        game.AddPlayer("Player2", playerTwoShips);
        game.Start("Player1");
        game.Start("Player2");
        Assert.That(game.GetPlayer("Player1").Board[0, 0], Is.EqualTo('g'));
        Assert.That(game.GetPlayer("Player2").Board[5, 5], Is.EqualTo('g'));
    }

    [Test]
    public void StartTheGameWithOneMultiVerticalSpaceShip()
    {
        var game = new Game();
        var ships = new List<Ship>() { new Ship('d', 0, 0, true) };
        game.AddPlayer("Player1", ships);
        game.Start("Player1");
        Assert.That(game.GetPlayer("Player1").Board[0, 0], Is.EqualTo('d'));
        Assert.That(game.GetPlayer("Player1").Board[1, 0], Is.EqualTo('d'));
        Assert.That(game.GetPlayer("Player1").Board[2, 0], Is.EqualTo('d'));
    }

    [Test]
    public void StartTheGameWithOneMultiHorizontalSpaceShip()
    {
        var game = new Game();
        var ships = new List<Ship>() { new Ship('d', 1, 0, false) };
        game.AddPlayer("Player1", ships);
        game.Start("Player1");
        Assert.That(game.GetPlayer("Player1").Board[1, 0], Is.EqualTo('d'));
        Assert.That(game.GetPlayer("Player1").Board[1, 1], Is.EqualTo('d'));
        Assert.That(game.GetPlayer("Player1").Board[1, 2], Is.EqualTo('d'));
    }

    [Test]
    public void StartTheGameWithTwoShips()
    {
        var game = new Game();
        var ships = new List<Ship>() { new Ship('g', 0, 0, false), new Ship('d', 1, 0, false) };
        game.AddPlayer("Player1", ships);
        game.Start("Player1");
        Assert.That(game.GetPlayer("Player1").Board[0, 0], Is.EqualTo('g'));
        Assert.That(game.GetPlayer("Player1").Board[1, 0], Is.EqualTo('d'));
        Assert.That(game.GetPlayer("Player1").Board[1, 1], Is.EqualTo('d'));
        Assert.That(game.GetPlayer("Player1").Board[1, 2], Is.EqualTo('d'));
    }

    [Test]
    public void StartTheGameWithAllShips()
    {
        var game = new Game();
        var ships = new List<Ship>() { new Ship('g', 0, 0, false), new Ship('d', 1, 0, false), new Ship('c', 6, 0, false) };
        game.AddPlayer("Player1", ships);
        game.Start("Player1");
        Assert.That(game.GetPlayer("Player1").Board[0, 0], Is.EqualTo('g'));
        Assert.That(game.GetPlayer("Player1").Board[1, 0], Is.EqualTo('d'));
        Assert.That(game.GetPlayer("Player1").Board[1, 1], Is.EqualTo('d'));
        Assert.That(game.GetPlayer("Player1").Board[1, 2], Is.EqualTo('d'));
        Assert.That(game.GetPlayer("Player1").Board[6, 0], Is.EqualTo('c'));
        Assert.That(game.GetPlayer("Player1").Board[6, 1], Is.EqualTo('c'));
        Assert.That(game.GetPlayer("Player1").Board[6, 2], Is.EqualTo('c'));
        Assert.That(game.GetPlayer("Player1").Board[6, 3], Is.EqualTo('c'));
    }

    [Test]
    public void TwoPlayersStartAGameWithAGunboatEachAndFiresAndMisses()
    {
        var game = new Game();
        var playerOneShips = new List<Ship>() { new Ship('g', 0, 0, false) };
        var playerTwoShips = new List<Ship>() { new Ship('g', 5, 5, false) };
        game.AddPlayer("Player1", playerOneShips);
        game.AddPlayer("Player2", playerTwoShips);
        game.Start("Player1");
        game.Start("Player2");
        game.Fire("Player1", 3, 2);
        Assert.That(game.GetPlayer("Player2").Board[3, 2], Is.EqualTo('o'));
    }
}