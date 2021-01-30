using System;
using System.Collections.Generic;
using System.Windows.Documents;
using System.Windows.Media;

namespace Reversi
{
    public static class ReversiGame
    {
        public static GameBoard GameBoard { get; set; }
        public static List<Player> Players { get; set; }
        public static int BoardSize;
        private static int currentPlayerTurn;
        private const int playersCount = 2;

        public static void InitializeGame(int boardSize)
        {
            BoardSize = boardSize;
            Players = new List<Player>(playersCount);
            Players.Add(new Player(Brushes.Blue, 0));
            Players.Add(new Player(Brushes.Red, 1));
            GameBoard = new GameBoard(boardSize);
            
        }

        public static bool MakeMove(int row, int column)
        {
            if (!GameBoard.ConquerTile(Players[currentPlayerTurn], row, column))
            {
                return false;
            }
            currentPlayerTurn = playersCount - currentPlayerTurn - 1;
            return true;
        }
    }
}