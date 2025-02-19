using System.Data.Common;
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

    public string AddPlayer(string playerName, List<Ship> ships)
    {
        if (Players.Count >= 2)
        {
            throw new ArgumentOutOfRangeException();
        }

        var player = new Player(ships);
        player.Name = playerName;
        Players.Add(player);

        return $"Added Player {player.Name}";
    }

    public Player GetPlayer(string player1)
    {
        return Players.First(x => x.Name == player1);
    }

    public void Start(string player)
    {
        var playerObject = GetPlayer(player);

        foreach(var thisShip in playerObject.Ships)
        {
            if (thisShip.IsVertical == true)
            {
                var thisShpLength = shipLengths[thisShip.ShipType];
                for (int i = thisShip.Row; i <= thisShip.Row + thisShpLength; i++)
                {
                    playerObject.Board[i, thisShip.Column] = thisShip.ShipType;
                }
            }
            else
            {
                var thisShpLength = shipLengths[thisShip.ShipType];
                for (int i = thisShip.Column; i <= thisShip.Column + thisShpLength; i++)
                {
                    playerObject.Board[thisShip.Row, i] = thisShip.ShipType;
                }
            }
        }
    }

    public void Fire(string v1, int v2, int v3)
    {
        throw new NotImplementedException();
    }
}

public class Player
{
    public string Name { get; set; }
    public char[,] Board { get; set; }
    public List<Ship> Ships { get; set; }


    public Player(List<Ship> ships) 
    {
        Board = new char[10,10];
        Ships = ships;
    }

}

public class Ship
{
    public Ship(char shipType, int row, int column, bool isVertical)
    {
        ShipType = shipType;
        Row = row;
        Column = column;
        IsVertical = isVertical;
    }

    public char ShipType { get; set; }
    public int Row { get; set; }
    public int Column { get; set; }
    public bool IsVertical { get; set; }


}