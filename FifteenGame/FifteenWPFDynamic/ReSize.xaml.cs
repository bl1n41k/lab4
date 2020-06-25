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

namespace FifteenWPFDynamic
{
	/// <summary>
	/// Логика взаимодействия для ReSize.xaml
	/// </summary>
	public partial class ReSize : Window
    {
        int size;
        public ReSize()
		{
			InitializeComponent();
            size = 4;
		}
        public int Size
        {
            get => size;
        }

        private void Size2Click(object sender, RoutedEventArgs e)
        {
            size = 2;
            Close();
        }
        private void Size3Click(object sender, RoutedEventArgs e)
        {
            size = 3;
            Close();
        }

        private void Size4Click(object sender, RoutedEventArgs e)
        {
            size = 4;
            Close();
        }

        private void Size5Click(object sender, RoutedEventArgs e)
        {
            size = 5;
            Close();
        }

        private void Size6Click(object sender, RoutedEventArgs e)
        {
            size = 6;
            Close();
        }
    }
}
