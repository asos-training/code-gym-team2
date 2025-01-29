using System.Net.Http.Headers;

namespace CodeGym;

public class Game
{
    public List<Player> Players { get; set; }
    public Game()
    {
        Players = new List<Player>();
    }

    public string AddPlayer(string playerName)
    {
        if (Players.Count >= 2)
        {
            throw new ArgumentOutOfRangeException();
        }

        var player = new Player();
        player.Name = playerName;
        Players.Add(player);

        return $"Added Player {player.Name}";
    }
}

public class Player
{
    public string Name { get; set; }
    public char[,] Board { get; set; }

    public Player() 
    {
        Board = new char[10,10];
    }

}