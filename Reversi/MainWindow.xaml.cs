using System;
using System.Windows;
using System.Windows.Controls;

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
