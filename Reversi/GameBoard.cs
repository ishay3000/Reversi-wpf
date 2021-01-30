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
        public int BoardSize { get; }

        public GameBoard(int boardSize)
        {
            this.BoardSize = boardSize;
            ReversiGameStrategy.BoardSize = boardSize;
            GameTiles = new List<Tile>();
            InitializeTiles();
        }

        private void InitializeTiles()
        {
            for (int i = 0; i < BoardSize; i++)
            {
                for (int j = 0; j < BoardSize; j++)
                {
                    GameTiles.Add(new Tile($"{i}:{j}"));
                }
            }

            int middleOfBoard = GameTiles.Count / 2;
            int middleOfBoardRow = BoardSize / 2;
            GameTiles[middleOfBoard - middleOfBoardRow].Conquer(ReversiGame.Players[1]);
            GameTiles[middleOfBoard + middleOfBoardRow - 1].Conquer(ReversiGame.Players[1]);
            GameTiles[middleOfBoard + middleOfBoardRow].Conquer(ReversiGame.Players[0]);
            GameTiles[middleOfBoard - middleOfBoardRow - 1].Conquer(ReversiGame.Players[0]);
        }

        public bool ConquerTile(Player player, int row, int col)
        {
            var anchorTile = (BoardSize * row) + col;
            return ReversiGameStrategy.StartConquering(player, GameTiles, anchorTile);
        }
    }
}
