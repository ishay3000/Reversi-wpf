using System;
using System.Collections.Generic;

namespace Reversi
{
    public static class ReversiGameStrategy
    {
        public static int BoardSize { get; set; }
        private static int CurrentAnchorTile { get; set; }
        private static List<Tile> CurrentTiles { get; set; }
        private static Player CurrentPlayer { get; set; }
        private static bool ConqueredAnyTile { get; set; } = false;


        public static bool StartConquering(Player player, List<Tile> tiles, int anchorTile)
        {
            CurrentPlayer = player;
            CurrentAnchorTile = anchorTile;
            CurrentTiles = tiles;

            int right = 1,
                left = -1,
                down = BoardSize,
                up = -BoardSize,
                southWest = BoardSize - 1,
                southEast = BoardSize + 1,
                northEast = -BoardSize + 1,
                northWest = -BoardSize - 1;

            ConquerTilesInDirection(right);
            ConquerTilesInDirection(left);
            ConquerTilesInDirection(down);
            ConquerTilesInDirection(up);
            ConquerTilesInDirection(southWest);
            ConquerTilesInDirection(southEast);
            ConquerTilesInDirection(northWest);
            ConquerTilesInDirection(northEast);

            if (ConqueredAnyTile)
            {
                CurrentTiles[CurrentAnchorTile].Conquer(CurrentPlayer);
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
            return index > 0 && index < Math.Pow(BoardSize, 2);
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
                var tile = CurrentTiles[startIndex];
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

                opponentTiles.Add(CurrentTiles[startIndex]);
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
    }
}