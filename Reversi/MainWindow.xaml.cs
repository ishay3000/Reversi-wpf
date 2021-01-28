using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Reversi
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        class Tile
        {
            public Brush Brush { get; set; }
            public string Tag { get; set; }

            public Tile(Brush brush, string tag)
            {
                Brush = brush;
                Tag = tag;
            }

            public Tile()
            {
                Brush = Brushes.Transparent;
                Tag = "";
            }
        }
        class Board
        {
            public List<Tile> GameTiles;
            private readonly int boardSize;

            public Board(int boardSize)
            {
                this.boardSize = boardSize;
                GameTiles = new List<Tile>();
                InitializeTiles();
            }

            private void InitializeTiles()
            {
                for (int i = 0; i < boardSize; i++)
                {
                    for (int j = 0; j < boardSize; j++)
                    {
                        GameTiles.Add(new Tile());
                    }
                }

                GameTiles[Convert.ToInt32(Math.Pow(boardSize, 2) / 2)].Brush = Brushes.Red;
                //GameTiles[boardSize / 2 + 1].Brush = Brushes.Blue;
            }
        }
        public MainWindow()
        {
            InitializeComponent();

            var list = new List<int>();

            int boardSize = 6;
            Board board = new Board(boardSize);

            DataContext = board.GameTiles;
        }
    }
}
