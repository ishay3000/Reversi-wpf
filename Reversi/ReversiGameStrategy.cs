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


        public static void StartConquering(Player player, List<Tile> tiles, int anchorTile)
        {
            CurrentPlayer = player;
            CurrentAnchorTile = anchorTile;
            CurrentTiles = tiles;

            CurrentTiles[CurrentAnchorTile].Conquer(CurrentPlayer);
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
        }

        private static bool IsValidTile(int index)
        {
            return index > 0 && index < Math.Pow(BoardSize, 2);
        }

        private static void ConquerTilesInDirection(int increment)
        {
            int index = CurrentAnchorTile;
            List<Tile> opponentTiles = new List<Tile>();
            bool encounteredBlankTile = false, encounteredAllyTile = false;
            do
            {
                index += increment;
                if (!IsValidTile(index))
                {
                    break;
                }
                var tile = CurrentTiles[index];
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

                opponentTiles.Add(CurrentTiles[index]);
            } while (index % BoardSize != 0);

            if (encounteredBlankTile || !encounteredAllyTile)
            {
                return;
            }
            foreach (Tile opponentTile in opponentTiles)
            {
                opponentTile.Conquer(CurrentPlayer);
            }
        }
    }
}