using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reversi
{
    public class GameBoard
    {
        public List<Tile> GameTiles;
        private readonly int boardSize;

        public GameBoard(int boardSize)
        {
            this.boardSize = boardSize;
            GameTiles = new List<Tile>();
            InitializeTiles();
        }

        private void InitializeTiles()
        {
            for (int i = 0; i < boardSize; i++)
            {
                for (int j = 0; j < boardSize; j++)
                {
                    GameTiles.Add(new Tile());
                }
            }
        }
    }
}
