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
        private static Player CurrentPlayerType { get; set; }


        public static void StartConquering(Player player, List<Tile> tiles, int anchorTile)
        {
            CurrentPlayerType = player;
            CurrentAnchorTile = anchorTile;
            CurrentTiles = tiles;

            CurrentTiles[CurrentAnchorTile].Conquer(CurrentPlayerType);

            // ConquerHorizontal(1);
            // ConquerHorizontal(-1);
            // ConquerVertical(1);
            // ConquerVertical(-1);
            // ConquerNorthEast();
            // ConquerNorthWest();
            // ConquerSouthEast();
            // ConquerSouthWest();
        }

        private static void ConquerHorizontal(int increment)
        {
            int column = CurrentAnchorTile;
            while (column % BoardSize != 0)
            {
                // if (CurrentTiles[column].)
                // {
                //     
                // }
                column += increment;
            }
            if (column == CurrentAnchorTile)
            {
                CurrentTiles[column].Conquer(CurrentPlayerType);
            }
        }

        private static void ConquerVertical(int increment)
        {
            for (int row = CurrentAnchorTile - BoardSize; row >= 0; row -= BoardSize)
            {
                CurrentTiles[row].Brush = Brushes.Red;
            }
        }

        private static void ConquerNorthWest()
        {

        }

        private static void ConquerNorthEast()
        {

        }

        private static void ConquerSouthWest()
        {

        }

        private static void ConquerSouthEast()
        {

        }


    }
}