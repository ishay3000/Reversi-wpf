using System;
using System.Collections.Generic;
using System.Windows.Documents;
using System.Windows.Media;

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

            // Right
            ConquerTilesInDirection(1);
            // Left
            ConquerTilesInDirection(-1);
            // Down
            ConquerTilesInDirection(BoardSize);
            // Up
            ConquerTilesInDirection(-BoardSize);
            // South west
            ConquerTilesInDirection(BoardSize - 1);
            // South east
            ConquerTilesInDirection(BoardSize + 1);
            // North east
            ConquerTilesInDirection(-BoardSize + 1);
            // North west
            ConquerTilesInDirection(-BoardSize - 1);

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
                if (tile.OccupyingPlayer.PlayerID == CurrentPlayer.PlayerID)
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

            ConqueredAnyTile = true;
            foreach (Tile opponentTile in opponentTiles)
            {
                opponentTile.Conquer(CurrentPlayer);
            }
        }
    }
}