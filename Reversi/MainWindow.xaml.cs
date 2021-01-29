﻿using System;
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
        public GameBoard GameBoard;
        public MainWindow()
        {
            InitializeComponent();

            int boardSize = 6;
            GameBoard = new GameBoard(boardSize);

            DataContext = GameBoard;
        }

        private void TileButton_Click(object sender, RoutedEventArgs e)
        {
            var btn = sender as Button;
            var coordination = btn.Tag.ToString().Split(':');
            int row = Convert.ToInt32(coordination[0]), col = Convert.ToInt32(coordination[1]);

            GameBoard.ConquerTile(PlayerType.BluePlayer, row, col);
        }
    }
}
