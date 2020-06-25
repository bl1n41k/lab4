using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace FifteenWPFDynamic
{
	/// <summary>
	/// Логика взаимодействия для MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
        DockPanel dockPanel;
        Menu menu;
        StatusBar info;
        UniformGrid gameGrid;
        DispatcherTimer timer1;
        Random Rand = new Random();
        GameLibrary.Game game;
        int count, size;
        DateTime timeDate;
        TimeSpan sec;
        public MainWindow()
        {
            InitializeComponent();
            dockPanel = new DockPanel() { LastChildFill = true };
            AddChild(dockPanel);
            menu = new Menu();
            DockPanel menuDockPanel = new DockPanel() { HorizontalAlignment = HorizontalAlignment.Stretch };
            menu.Items.Add(new MenuItem() { Header = "Начать игру", FontSize = 16 });
            (menu.Items[0] as MenuItem).Click += StartEvent;
            menu.Items.Add(new MenuItem() { Header = "Изменить размер", FontSize = 16 });
            (menu.Items[1] as MenuItem).Click += ChangeSizeClick;
            KeyDown += Button_KeyDown;
            menu.Items.Add(new MenuItem()
            {
                Header = "Отменa хода",
                FontSize = 16,
                IsEnabled = false,
                HorizontalAlignment = HorizontalAlignment.Stretch
            });
            (menu.Items[2] as MenuItem).Click += CancelMove;
            info = new StatusBar();
            info.Items.Add(new StatusBarItem() { Content = "Ход: ", FontSize = 16 });
            info.Items.Add(new StatusBarItem() { Content = "0", FontSize = 16 });
            info.Items.Add(new Separator());
            info.Items.Add(new StatusBarItem() { Content = "Таймер: ", FontSize = 16 });
            info.Items.Add(new StatusBarItem() { Content = "0", FontSize = 16 });
            gameGrid = new UniformGrid();
            dockPanel.Children.Add(menu);
            DockPanel.SetDock(menu, Dock.Top);
            dockPanel.Children.Add(info);
            DockPanel.SetDock(info, Dock.Bottom);
            dockPanel.Children.Add(gameGrid);
            DockPanel.SetDock(gameGrid, Dock.Bottom);
            game = new GameLibrary.Game(4);
            timer1 = new DispatcherTimer();
            timer1.Tick += TimerTick;
            timer1.Interval = TimeSpan.FromSeconds(1);
           
            size = 4;
            ChangeGameField(size);
            Loaded += StartEvent;
        }

        private void StartGame(object sender, RoutedEventArgs e)
        {
            count = 0;
            timeDate = DateTime.Now; //текущее время
            timer1.Start();
            game.Start();
            for (int i = 0; i < Rand.Next(100); i++) game.ShiftRandom();
            RefreshButtonField();

        }
        private void StartEvent(object sender, RoutedEventArgs e)
        {
            StartGame(sender, e);
        }

        private void RefreshButtonField()
        {
            for (int position = 0; position < size * size; position++)
            {
                GetButton(position).Content = game.GetNumber(position).ToString();
                if (game.GetNumber(position) == 0) GetButton(position).Visibility = Visibility.Hidden;
                else  GetButton(position).Visibility = Visibility.Visible;
            }
        }
        private void ChangeGameField(int _size)
        {
            size = _size;
            gameGrid.Children.Clear();
            gameGrid.Columns = size;
            gameGrid.Rows = size;
            for (int i = 0; i < gameGrid.Rows; i++)
                for (int j = 0; j < gameGrid.Columns; j++)
                {
                    Button button = new Button()
                    {
                        Content = (i * gameGrid.Rows + j + 1).ToString(),
                        FontSize = 12,
                        Tag = i * gameGrid.Rows + j,
                        Focusable = false,
                        Margin = new Thickness(2, 2, 2, 2),
                    };
                    button.Click += Button_Click;
                    gameGrid.Children.Add(button);
                }
        }
        private void ChangeSizeClick(object sender, RoutedEventArgs e)
        {
            ReSize window = new ReSize();
            window.ShowDialog();
            int _size = window.Size;
            if (_size != -1)
            {
                ChangeGameField(_size);
                game = new GameLibrary.Game(_size);
                StartGame(sender, e);
            }
        }
        private void TimerTick(object sender, EventArgs e)
        {
            sec = DateTime.Now.Subtract(timeDate); //секунд с начала игры
            (info.Items[4] as StatusBarItem).Content = sec.ToString(@"hh\:mm\:ss");
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
                (info.Items[1] as StatusBarItem).Content = count.ToString();
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
                (info.Items[1] as StatusBarItem).Content = count.ToString();
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
                    (info.Items[1] as StatusBarItem).Content = "0";
                    (info.Items[4] as StatusBarItem).Content = "0";
                }
                else
                    Close();
            }
        }

        private void Button_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Back) Restore(); // клавиша Backspace отменяет ход
            if (e.Key == Key.Space) // читы 
            {
                MessageBoxResult result = MessageBox.Show("Вы хотите начать новую игру?", "Победа!", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    object s = sender;
                    RoutedEventArgs e1 = e;
                    count = 0;
                    timer1.Start();
                    StartGame(s, e1);
                    (info.Items[1] as StatusBarItem).Content = "0";
                    (info.Items[4] as StatusBarItem).Content = "0";
                }
                else
                    Close();
            }
        }

        private Button GetButton(int index)
        {
            return (Button)gameGrid.Children[index];
        }
    }
}

