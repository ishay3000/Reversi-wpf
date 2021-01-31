using System.Windows.Media;

namespace Reversi
{
    public class Tile : BasePropertyChanged
    {
        private Brush _brush;
        private bool _conquered;
        private Player _occupyingPlayer;
        private Coordination _coordination;


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

        public Coordination Coordination
        {
            get
            {
                return _coordination;
            }
        }

        public string Tag
        {
            get
            {
                return _coordination.Row.ToString() + ":" + _coordination.Column.ToString();
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

        public Tile(Coordination coordination)
        {
            Brush = Brushes.Transparent;
            _coordination = coordination;
        }

        public void Conquer(Player player)
        {
            OccupyingPlayer = player;
        }
    }
}
