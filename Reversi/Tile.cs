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

        public bool Conquered { get; set; } = false;

        public Tile()
        {
            Brush = Brushes.Transparent;
            Tag = "H";
        }
    }
}
