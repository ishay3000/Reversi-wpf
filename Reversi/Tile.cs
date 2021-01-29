using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Reversi
{
    public class Tile : BasePropertyChanged
    {
        private Brush _brush;
        private string _tag;
        private bool _conquered;
        private Player _occupyingPlayer;
        public int Index { get; }

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

        public string Tag
        {
            get => _tag;
            set
            {
                _tag = value;
                OnPropertyChanged();
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

        public Tile(string tag)
        {
            Brush = Brushes.Transparent;
            Tag = tag;
            var coordination = tag.Split(':');
            Index = Convert.ToInt32(coordination[0]) * ReversiGame.BoardSize + Convert.ToInt32(coordination[1]);
        }

        public void Conquer(Player player)
        {
            OccupyingPlayer = player;
        }
    }
}
