using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace Reversi
{
    public class GameBoard
    {
        public List<Tile> GameTiles { get; }
        public readonly int boardSize;

        public GameBoard(int boardSize)
        {
            this.boardSize = boardSize;
            ReversiGameStrategy.BoardSize = boardSize;
            GameTiles = new List<Tile>();
            InitializeTiles();
        }

        private void InitializeTiles()
        {
            for (int i = 0; i < boardSize; i++)
            {
                for (int j = 0; j < boardSize; j++)
                {
                    GameTiles.Add(new Tile($"{i}:{j}"));
                }
            }
        }

        public void ConquerTile(Player player, int row, int col)
        {
            var anchorTile = (boardSize * row) + col;
            ReversiGameStrategy.StartConquering(player, GameTiles, anchorTile);
        }
    }
}
