using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
using System.Windows.Threading;

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
        DispatcherTimer timer1;
        DateTime timeDate;
        TimeSpan sec;
        public MainWindow()
        {
            InitializeComponent();
            game = new GameLibrary.Game(4);
            Rand = new Random();
            count = 0;
            timer1 = new DispatcherTimer();
            timer1.Tick += TimerTick;
            timer1.Interval = sec;
            KeyDown += CancelKeyDown;
        }

        private void StartGame(object sender, RoutedEventArgs e)
        {
            count = 0;
            timeDate = DateTime.Now; //текущее время
            timer1.Start();
            game.Start();
            for (int i = 0; i < Rand.Next(100, 500); i++) game.ShiftRandom();
            RefreshButtonField();
            
        }

        private void RefreshButtonField()
        {
            for (int position = 0; position < 16; position++)
            {
                GetButton(position).Content = game.GetNumber(position).ToString();
                if (game.GetNumber(position) == 0) GetButton(position).Visibility = Visibility.Hidden;
                else GetButton(position).Visibility = Visibility.Visible;
            }
        }
        private void TimerTick(object sender, EventArgs e)
        {
            sec = DateTime.Now.Subtract(timeDate); //секунд с начала игры
            TimerStatus.Content = sec.ToString(@"hh\:mm\:ss");
        }
        private void CancelMove(object sender, RoutedEventArgs e)
        {
            Restore();
        }
        private void Restore()
        {
            if (count > 0)
            {
                game.GameRestore(); //загрузить прошлый ход
                count--;
                CountStatus.Content = count.ToString();
                RefreshButtonField(); //обновление измененных полей
            }
        }
     
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int position = Convert.ToInt32(((Button)sender).Tag);
            if (game.Shift(position))//перемещение
            {
                RefreshButtonField();
                count++;
                CountStatus.Content = count.ToString();
            }
            if (game.Check())
            {
                timer1.Stop();
                MessageBoxResult result = MessageBox.Show("Вы хотите начать новую игру?", "Победа!", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    object s = sender;
                    RoutedEventArgs e1 = e;
                    StartGame(s, e1);
                    TimerStatus.Content = "0";
                    CountStatus.Content = "0";
                }
                else 
                    Close();
            }     
        }

        private void CancelKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Back) Restore(); // клавиша Backspace отменяет ход
            if (e.Key == Key.Space) // читы 
            {
                timer1.Stop();
                MessageBoxResult result = MessageBox.Show("Вы хотите начать новую игру?", "Победа!", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    object s = sender;
                    RoutedEventArgs e1 = e;
                    count = 0;
                    timer1.Start();
                    StartGame(s, e1);
                    TimerStatus.Content = "0";
                    CountStatus.Content = "0";
                }
                else
                    Close();
            }
        }

        private Button GetButton(int index)//по номеру возвращает кнопку
        {
            Button[] buttons = new Button[]
             {
                button0,
                button1,
                button2,
                button3,
                button4,
                button5,
                button6,
                button7,
                button8,
                button9,
                button10,
                button11,
                button12,
                button13,
                button14,
                button15
             };
            return buttons[index];
        }
    }
}
