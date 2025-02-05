using System.Net.Http.Headers;

namespace CodeGym;

public class Game
{
    public List<Player> Players { get; set; }
    private Dictionary<char, int> shipLengths = new Dictionary<char, int>()
    {
        {'c', 4},
        {'d', 3},
        {'g', 1}
    };
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

    public Player GetPlayer(string player1)
    {
        return Players.First(x => x.Name == player1);
    }

    public void Start(string player, char ship, int row, int column, bool isVertical = false)
    {
        var playerObject = GetPlayer(player);

        if (isVertical == true)
        {
            var thisShpLength = shipLengths[ship];
            for (int i = row; i <= row + thisShpLength; i++)
            {
                playerObject.Board[i, column] = ship;
            }
        }
        else
        {
            var thisShpLength = shipLengths[ship];
            for (int i = column; i <= column + thisShpLength; i++)
            {
                playerObject.Board[row, i] = ship;
            }
        }
        
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