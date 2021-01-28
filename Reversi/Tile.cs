using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Reversi
{
    public class Tile
    {
        public Brush Brush { get; set; }
        public string Tag { get; set; }

        public Tile()
        {
            Brush = Brushes.Transparent;
            Tag = "H";
        }
    }
}
