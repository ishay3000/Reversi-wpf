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
            ConquerHorizontal(1);
            ConquerHorizontal(-1);
        }

        private static bool IsValidTile(int index)
        {
            return index < 0 || index > BoardSize;
        }

        private static void ConquerHorizontal(int increment)
        {
            int index = CurrentAnchorTile;
            List<Tile> opponentTiles = new List<Tile>();
            bool encounteredBlankTile = false;
            if (index % BoardSize == 0)
            {
                return;
            }

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
                    break;
                }

                opponentTiles.Add(CurrentTiles[index]);
            } while (index % BoardSize != 0);

            if (encounteredBlankTile)
            {
                return;
            }
            foreach (Tile opponentTile in opponentTiles)
            {
                opponentTile.Conquer(CurrentPlayer);
            }
        }

        private static void ConquerDiagonally(int increment)
        {

        }
    }
}