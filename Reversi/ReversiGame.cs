using System.Windows;

namespace Reversi
{
    public class ReversiGame : BasePropertyChanged
    {
        public GameEntities GameEntities { get; set; }
        public int BoardSize { get; }
        private int _playersCount = 2;
        private int _currentPlayerTurn;

        public string CurrentPlayerColor
        {
            get => GameEntities.Players[_currentPlayerTurn].PlayerColorName;
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
        public void InitializeGame()
        {
            GameEntities = new GameEntities(BoardSize);
            CurrentPlayerTurn = GameEntities.Players[0].PlayerId;
            ReversiGameStrategy.InitializeStrategy(GameEntities.GameBoard.GameTiles, BoardSize);
        }

        private bool CurrentPlayerCantMove()
        {
            return !ReversiGameStrategy.PlayerHasMovesLeft(GameEntities.Players[CurrentPlayerTurn]);
        }

        public bool IsGameOver()
        {
            return !ReversiGameStrategy.PlayerHasMovesLeft(GameEntities.Players[0]) &&
                   !ReversiGameStrategy.PlayerHasMovesLeft(GameEntities.Players[1]);
        }

        public void FinalizeGame()
        {
            int player1TilesCount = 0, player2TilesCount = 0;
            for (int i = 0; i < BoardSize; i++)
            {
                for (int j = 0; j < BoardSize; j++)
                {
                    Tile tile = GameEntities.GameBoard.GameTiles[i][j];
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

            string winner;
            if (player1TilesCount > player2TilesCount)
            {
                winner = GameEntities.Players[0].PlayerColorName;
            }
            else
            {
                winner = GameEntities.Players[1].PlayerColorName;
            }
            MessageBox.Show("Game Over! The winner is the " + winner + " player!");
        }

        public void MakeMove(int row, int column)
        {
            if (IsGameOver())
            {
                FinalizeGame();
            }
            else if (CurrentPlayerCantMove())
            {
                MessageBox.Show("Current player can't move. Switching to the other player.");
                CurrentPlayerTurn = _playersCount - CurrentPlayerTurn - 1;
            }
            else if (!GameEntities.GameBoard.ConquerTile(GameEntities.Players[CurrentPlayerTurn], GameEntities.GameBoard.GameTiles[row][column]))
            {
                MessageBox.Show("Invalid move! Pick a different tile.");
            }
            else
            {
                CurrentPlayerTurn = _playersCount - CurrentPlayerTurn - 1;
                if (IsGameOver())
                {
                    FinalizeGame();
                }
            }
        }
    }
}