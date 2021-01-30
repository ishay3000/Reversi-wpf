using System.Collections.Generic;

namespace Reversi
{
    public class GameBoard
    {
        public List<Tile> GameTiles { get; }
        public int BoardSize { get; }

        public GameBoard(int boardSize, List<Player> players)
        {
            this.BoardSize = boardSize;
            GameTiles = new List<Tile>();
            InitializeTiles(players);
        }

        private void InitializeTiles(List<Player> players)
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
            GameTiles[middleOfBoard - middleOfBoardRow].Conquer(players[1]);
            GameTiles[middleOfBoard + middleOfBoardRow - 1].Conquer(players[1]);
            GameTiles[middleOfBoard + middleOfBoardRow].Conquer(players[0]);
            GameTiles[middleOfBoard - middleOfBoardRow - 1].Conquer(players[0]);
        }

        public bool ConquerTile(Player player, int row, int col)
        {
            var anchorTile = (BoardSize * row) + col;
            return ReversiGameStrategy.StartConquering(player, anchorTile);
        }
    }
}
