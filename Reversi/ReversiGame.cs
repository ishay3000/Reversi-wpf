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
            GameBoard = new GameBoard(boardSize);
            Players = new List<Player>(playersCount);
            Players.Add(new Player(Brushes.Blue, 0));
            Players.Add(new Player(Brushes.Red, 1));
        }

        public static void MakeMove(int row, int column)
        {
            GameBoard.ConquerTile(Players[currentPlayerTurn], row, column);
            currentPlayerTurn = playersCount - currentPlayerTurn - 1;
        }
    }
}