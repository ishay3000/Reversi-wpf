using System.Windows;

namespace Reversi
{
    public class ReversiGame : BasePropertyChanged
    {
        public GameEntities GameEntities { get; set; }
        public int BoardSize { get; }
        private bool player1HasMoves = false, player2HasMoves = false;
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
            // ReversiGameStrategy.InitializeStrategy(GameEntities.GameBoard.GameTiles, BoardSize);
        }

        public bool IsGameOver()
        {
            player1HasMoves = ReversiGameStrategy.PlayerHasMovesLeft(GameEntities.Players[0]);
            player2HasMoves = ReversiGameStrategy.PlayerHasMovesLeft(GameEntities.Players[1]);

            return !(player1HasMoves && player2HasMoves);
        }

        /*public void FinalizeGame()
        {
            // TODO: Check which player won/draw, and announce it.
            int player1TilesCount = 0, player2TilesCount = 0;
            foreach (Tile tile in GameEntities.GameBoard.GameTiles)
            {
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
        }*/

        public bool MakeMove(int row, int column)
        {
            // if (IsGameOver())
            // {
            //     // FinalizeGame();
            // }
            if (!GameEntities.GameBoard.ConquerTile(GameEntities.Players[CurrentPlayerTurn], row, column))
            {
                return false;
            }
            CurrentPlayerTurn = _playersCount - CurrentPlayerTurn - 1;
            return true;
        }
    }
}