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
        private ReversiGame reversiGame;
        public MainWindow()
        {
            InitializeComponent();

            int boardSize = 8;
            reversiGame = new ReversiGame(boardSize);

            DataContext = reversiGame;
        }

        private void TileButton_Click(object sender, RoutedEventArgs e)
        {
            var btn = (Button) sender;
            
                var coordination = btn.Tag.ToString().Split(':');
                int row = Convert.ToInt32(coordination[0]), col = Convert.ToInt32(coordination[1]);

                if (!reversiGame.MakeMove(row, col))
                {
                    MessageBox.Show("Invalid move! Pick a different tile.");
                }
        }
    }
}
