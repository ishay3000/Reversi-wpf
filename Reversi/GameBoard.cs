using System;
using System.Collections.Generic;

namespace Reversi
{
    public class GameBoard
    {
        public List<List<Tile>> GameTiles { get; }
        public int BoardSize { get; }

        public GameBoard(int boardSize, List<Player> players)
        {
            this.BoardSize = boardSize;
            GameTiles = new List<List<Tile>>();
            InitializeTiles(players);
        }

        private void InitializeTiles(List<Player> players)
        {
            for (int i = 0; i < BoardSize; i++)
            {
                GameTiles.Add(new List<Tile>());
                for (int j = 0; j < BoardSize; j++)
                {
                    GameTiles[i].Add(new Tile(new Coordination(i, j)));
                }
            }

            int middleLeft = 0, middleRight = 0;
            // Generic board size middle indexes.
            middleLeft = (int)Math.Floor((double)(BoardSize - 1) / 2);
            middleRight = (int)Math.Floor((double)BoardSize / 2);
            if (BoardSize % 2 != 0)
            {
                middleRight += 1;
            }

            GameTiles[middleLeft][middleLeft].Conquer(players[0]);
            GameTiles[middleLeft][middleRight].Conquer(players[1]);
            GameTiles[middleRight][middleRight].Conquer(players[0]);
            GameTiles[middleRight][middleLeft].Conquer(players[1]);
        }

        public bool ConquerTile(Player player, Tile tile)
        {
            if (tile.Conquered)
            {
                return false;
            }
            return ReversiGameStrategy.StartConquering(player, tile);
        }
    }
}