using System.Windows.Media;

namespace Reversi
{
    // המחלקה הזו מסמלת משבצת בלוח המשחק, ומורכבת מצבע המשבצת, האם היא כבושה, השחקן שכבש אותה, ומיקום לוגי.
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
        
        // מייצג את התוכן של הכפתור שהיא שייכת אליו. בעזרת התוכן הזה, נדע את מיקום המשבצת כאשר נלחץ על כפתור כלשהו.
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
