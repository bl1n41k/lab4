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

namespace FifteenWPF
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        GameLibrary.Game game;
        Random Rand;
        int count;
        public MainWindow()
        {
            InitializeComponent();
            game = new GameLibrary.Game(4);
            Rand = new Random();
        }

        private void StartGame(object sender, RoutedEventArgs e)
        {

        }

    }
}