using System.Collections.Generic;
using System.Windows.Media;

namespace Reversi
{
    public class GameEntities
    {
        public List<Player> Players { get; set; }
        public GameBoard GameBoard { get; set; }

        public GameEntities(int boardSize)
        {
            Players = new List<Player>(2);
            Players.Add(new Player(Brushes.Blue, 0, "Blue"));
            Players.Add(new Player(Brushes.Red, 1, "Red"));

            GameBoard = new GameBoard(boardSize, Players);

        }
    }
}