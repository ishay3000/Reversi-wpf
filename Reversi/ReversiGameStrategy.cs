using System;
using System.Collections.Generic;

namespace Reversi
{
    public static class ReversiGameStrategy
    {
        private static int BoardSize;
        private static int CurrentAnchorTile;
        public static List<Tile> GameTiles;
        private static Player CurrentPlayer;
        private static bool ConqueredAnyTile = false;
        private static int _right,
            _left,
            _down,
            _up,
            _southWest,
            _southEast,
            _northEast,
            _northWest;

        public static void InitializeStrategy(List<Tile> tiles, int boardSize)
        {
            GameTiles = tiles;
            BoardSize = boardSize;
            _right = 1;
            _left = -1;
            _down = BoardSize;
            _up = -BoardSize;
            _southWest = BoardSize - 1;
            _southEast = BoardSize + 1;
            _northEast = -BoardSize + 1;
            _northWest = -BoardSize - 1;
        }

        public static bool StartConquering(Player player, int conqueringTile)
        {
            CurrentPlayer = player;
            CurrentAnchorTile = conqueringTile;

            ConquerTilesInDirection(_right);
            ConquerTilesInDirection(_left);
            ConquerTilesInDirection(_down);
            ConquerTilesInDirection(_up);
            ConquerTilesInDirection(_southWest);
            ConquerTilesInDirection(_southEast);
            ConquerTilesInDirection(_northWest);
            ConquerTilesInDirection(_northEast);

            if (ConqueredAnyTile)
            {
                GameTiles[CurrentAnchorTile].Conquer(CurrentPlayer);
                ConqueredAnyTile = false;

                return true;
            }
            else
            {
                return false;
            }
        }

        private static bool IsValidTile(int index)
        {
            return index > 0 && index < GameTiles.Count;
        }

        private static List<Tile> FindOpposingTiles(int startIndex, int offset)
        {
            List<Tile> opponentTiles = new List<Tile>();
            bool encounteredBlankTile = false, encounteredAllyTile = false;
            do
            {
                startIndex += offset;
                if (!IsValidTile(startIndex))
                {
                    break;
                }
                var tile = GameTiles[startIndex];
                if (!tile.Conquered)
                {
                    encounteredBlankTile = true;
                    break;
                }
                if (tile.OccupyingPlayer.PlayerId == CurrentPlayer.PlayerId)
                {
                    encounteredAllyTile = true;
                    break;
                }

                opponentTiles.Add(GameTiles[startIndex]);
            } while (startIndex % BoardSize != 0);

            if (encounteredBlankTile || !encounteredAllyTile)
            {
                return null;
            }

            return opponentTiles;
        }

        private static void ConquerTilesInDirection(int offset)
        {
            List<Tile> opponentTiles = FindOpposingTiles(CurrentAnchorTile, offset);

            if (opponentTiles == null)
            {
                return;
            }

            if (opponentTiles.Count > 0)
            {
                ConqueredAnyTile = true;
                foreach (Tile opponentTile in opponentTiles)
                {
                    opponentTile.Conquer(CurrentPlayer);
                }
            }

        }

        public static bool PlayerHasMovesLeft(Player player)
        {
            return false;
        }
    }
}