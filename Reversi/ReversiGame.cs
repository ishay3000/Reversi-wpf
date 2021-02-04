using System.Collections.Generic;
using System.Windows;
using System.Windows.Media;

namespace Reversi
{
    // המחלקה הזו מסמלת את המשחק, ומכילה את ישויות המשחק, לוח המשחק,
    // רשימת השחקנים, גודל הלוח, תור השחקן הנוכחי, וכותרת החלון של המשחק אשר מתעדכנת עם הניקוד המשתנה
    public class ReversiGame : BasePropertyChanged
    {
        public GameBoard GameBoard { get; set; }
        public List<Player> Players { get; set; }
        public int BoardSize { get; }
        private const int PlayersCount = 2;
        private int _currentPlayerTurn;
        private string _gameTitle;


        public string GameTitle
        {
            get
            {
                return _gameTitle;
            }

            set
            {
                _gameTitle = value;
                OnPropertyChanged();
            }
        }

        public string CurrentPlayerColor
        {
            get => Players[_currentPlayerTurn].PlayerColorName;
            set => OnPropertyChanged();
        }

        public int CurrentPlayerTurn
        {
            get => _currentPlayerTurn;
            private set
            {
                _currentPlayerTurn = value;
                CurrentPlayerColor = CurrentPlayerColor;
            }
        }


        public ReversiGame(int boardSize)
        {
            BoardSize = boardSize;
            InitializeGame();
        }

        // פעולה זו מאתחלת את המשחק, בכך שמאתחלת 2 שחקנים בצבעים שונים, וכן מאתחלת את לוח המשחק, ואת אסטרטגיית המשחק.
        public void InitializeGame()
        {
            Players = new List<Player>(PlayersCount);
            Players.Add(new Player(Brushes.Blue, 0, "Blue"));
            Players.Add(new Player(Brushes.Red, 1, "Red"));

            GameBoard = new GameBoard(BoardSize, Players);
            CurrentPlayerTurn = Players[0].PlayerId;
            ReversiGameStrategy.InitializeStrategy(GameBoard.GameTiles, BoardSize);

            UpdateGameStats();
        }

        private bool CurrentPlayerCantMove()
        {
            return !ReversiGameStrategy.PlayerHasMovesLeft(Players[CurrentPlayerTurn]);
        }

        public bool IsGameOver()
        {
            return !ReversiGameStrategy.PlayerHasMovesLeft(Players[0]) &&
                   !ReversiGameStrategy.PlayerHasMovesLeft(Players[1]);
        }
        
        // פעולה זו מונה את הניקוד של כל אחד מהשחקנים, ומכריזה על זוכה.
        public void FinalizeGame()
        {
            int player1TilesCount = 0, player2TilesCount = 0;
            for (int i = 0; i < BoardSize; i++)
            {
                for (int j = 0; j < BoardSize; j++)
                {
                    Tile tile = GameBoard.GameTiles[i][j];
                    if (tile.Conquered)
                    {
                        if (tile.OccupyingPlayer.PlayerId == 0)
                        {
                            ++player1TilesCount;
                        }
                        else
                        {
                            ++player2TilesCount;
                        }
                    }
                }
            }

            if (player1TilesCount == player2TilesCount)
            {
                MessageBox.Show("Game Over! The game ended with a draw of " + player2TilesCount + " points to each player.");
            }
            else
            {
                Player winner;
                if (player1TilesCount > player2TilesCount)
                {
                    winner = Players[0];
                }
                else
                {
                    winner = Players[1];
                }
                MessageBox.Show("Game Over! The winner is the " + winner.PlayerColorName + " player, with a score of " + winner.Score);
            }

        }

        private int GetNextPlayerTurn()
        {
            return PlayersCount - CurrentPlayerTurn - 1;
        }

        private void UpdateGameStats()
        {
            foreach (Player player in Players)
            {
                player.Score = 0;
            }

            foreach (List<Tile> row in GameBoard.GameTiles)
            {
                foreach (Tile tile in row)
                {
                    if (tile.Conquered)
                    {
                        Players[tile.OccupyingPlayer.PlayerId].Score++;
                    }
                }
            }

            string tmpTitle = "Reversi    ";
            foreach (var player in Players)
            {
                tmpTitle += player.PlayerColorName + "'s score: " + player.Score + "    ";
            }

            GameTitle = tmpTitle;
        }

        public void MakeMove(int row, int column)
        {
            if (!GameBoard.ConquerTile(Players[CurrentPlayerTurn], GameBoard.GameTiles[row][column]))
            {
                MessageBox.Show("Invalid move! Pick a different tile.");
            }
            else
            {
                UpdateGameStats();
                CurrentPlayerTurn = GetNextPlayerTurn();
                if (IsGameOver())
                {
                    FinalizeGame();
                }
                else if (CurrentPlayerCantMove())
                {
                    MessageBox.Show(Players[CurrentPlayerTurn].PlayerColorName +
                                    " player can't move. Switching to the " +
                                    Players[PlayersCount - CurrentPlayerTurn - 1].PlayerColorName + " player.");
                    CurrentPlayerTurn = PlayersCount - CurrentPlayerTurn - 1;
                }
            }
        }
    }
}