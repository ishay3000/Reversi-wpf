using System;
using System.Collections.Generic;
using System.Windows.Documents;
using System.Windows.Media;

namespace Reversi
{
    public class ReversiGame
    {
        public GameBoard GameBoard { get; set; }
        public List<Player> Players { get; set; }
        private int currentPlayerTurn;
        private const int playersCount = 2;

        public ReversiGame(int boardSize)
        {
            GameBoard = new GameBoard(boardSize);
            Players = new List<Player>(2);

            InitializePlayers();
            currentPlayerTurn = 0;
        }

        private void InitializePlayers()
        {
            Players.Add(new Player(Brushes.Blue, 0));
            Players.Add(new Player(Brushes.Red, 1));
        }

        public void MakeMove(int row, int column)
        {
            GameBoard.ConquerTile(Players[currentPlayerTurn], row, column);
            currentPlayerTurn = playersCount - currentPlayerTurn - 1;
        }
    }
}