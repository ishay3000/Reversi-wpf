using System.Windows.Media;

namespace Reversi
{
    public class Tile : BasePropertyChanged
    {
        private Brush _brush;
        private bool _conquered;
        private Player _occupyingPlayer;
        private Point _point;
        private int _playersCount = 2;
        private int _currentPlayerTurn;
        private string _currentPlayerColor;


        public Player OccupyingPlayer
        {
            get => _occupyingPlayer;
            set
            {
                _occupyingPlayer = value;
                Conquered = true;
                Brush = _occupyingPlayer.PlayerColor;
            }
        }

        public Brush Brush
        {
            get => _brush;
            set
            {
                _brush = value;
                OnPropertyChanged();
            }
        }

        public string Point
        {
            get
            {
                return _point.X.ToString() + ":" + _point.Y.ToString();
            }
        }

        public bool Conquered
        {
            get => _conquered;
            set
            {
                _conquered = value;
                OnPropertyChanged();
            }
        }

        public Tile(Point point)
        {
            Brush = Brushes.Transparent;
            _point = point;
        }

        public void Conquer(Player player)
        {
            OccupyingPlayer = player;
        }
    }
}
