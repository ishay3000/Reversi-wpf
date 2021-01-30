namespace Reversi
{
    public class ReversiGame : BasePropertyChanged
    {
        public GameEntities GameEntities { get; set; }
        public int BoardSize { get; }

        public string CurrentPlayerColor
        {
            get => GameEntities.Players[_currentPlayerTurn].PlayerColorName;
            set
            {
                _currentPlayerColor = value;
                OnPropertyChanged();
            }
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

        private int PlayersCount = 2;
        private int _currentPlayerTurn;
        private string _currentPlayerColor;

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

        public bool IsGameOver()
        {
            if (ReversiGameStrategy.PlayerHasMovesLeft(GameEntities.Players[0]) &&
                ReversiGameStrategy.PlayerHasMovesLeft(GameEntities.Players[1]))
            {
                return true;
            }

            return false;
        }

        public void FinalizeGame()
        {
            // TODO: Check which player won/draw, and announce it.
        }

        public bool MakeMove(int row, int column)
        {
            if (IsGameOver())
            {
                FinalizeGame();
            }
            else if (!GameEntities.GameBoard.ConquerTile(GameEntities.Players[CurrentPlayerTurn], row, column))
            {
                return false;
            }
            CurrentPlayerTurn = PlayersCount - CurrentPlayerTurn - 1;
            return true;
        }
    }
}