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
using System.Windows.Shapes;

namespace Reversi
{
    /// <summary>
    /// Interaction logic for StartupWindow.xaml
    /// </summary>
    public partial class StartupWindow : Window
    {
        public StartupWindow()
        {
            InitializeComponent();


        }

        private int IsValidBoardSize(string boardSizeString)
        {
            int boardSize;
            const int minimumBoardSize = 4;
            if (int.TryParse(boardSizeString, out boardSize))
            {
                if (boardSize % 2 == 0 && boardSize >= minimumBoardSize)
                {
                    return boardSize;
                }
            }

            return -1;
        }

        private void BtnStart_OnClick(object sender, RoutedEventArgs e)
        {
            string boardSizeString = TextboxBoardSize.Text;
            int boardSize;
            boardSize = IsValidBoardSize(boardSizeString);
            if (boardSize != -1)
            {
                // TODO: Close this window, and open the game board window.
            }
            else
            {
                MessageBox.Show("Invalid board size provided");
            }
        }
    }
}
