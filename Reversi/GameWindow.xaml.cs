using System;
using System.Windows;
using System.Windows.Controls;

namespace Reversi
{
    /// <summary>
    /// Interaction logic for GameWindow.xaml
    /// </summary>
    public partial class GameWindow : Window
    {
        private ReversiGame _reversiGame;
        public GameWindow(int boardSize)
        {
            InitializeComponent();
            
            _reversiGame = new ReversiGame(boardSize);

            DataContext = _reversiGame;
        }

        private void TileButton_Click(object sender, RoutedEventArgs e)
        {
            var btn = (Button)sender;

            var coordination = btn.Tag.ToString().Split(':');
            int row = Convert.ToInt32(coordination[0]), col = Convert.ToInt32(coordination[1]);

            _reversiGame.MakeMove(row, col);
        }
    }
}
