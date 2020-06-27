using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FifteenGUIDynamic
{
	public partial class Fifteen : Form
	{
        GameLibrary.Game game;
        Random Rand;
        private int count;
        private int size = 4;
        DateTime timeDate;
        TimeSpan sec;
        public Fifteen()
        { 
            InitializeComponent();
            game = new GameLibrary.Game(size);
            Rand = new Random();
            timer1.Interval = 500;
        }

        private void Button_Click(object sender, EventArgs e)
        {
            int position = Convert.ToInt32(((Button)sender).Tag);
            if (game.Shift(position))//перемещение
            {
                RefreshButtonField();
                count++;
                CountStatus.Text = count.ToString();
            }
            if (game.Check())//Завершение игры 
            {
                Victory victory = new Victory(count, sec);
                victory.ShowDialog();
            }
            this.ActiveControl = null;
        }

        private Button GetButton(int index)//по номеру возвращает кнопку
        {
            return (Button) tableLayoutPanel1.Controls[index];
        }

        private void RefreshButtonField() //метод обновления поля кнопок
        {
            for (int position = 0; position < size * size; position++)
            {
                GetButton(position).Text = game.GetNumber(position).ToString();
                if (game.GetNumber(position) == 0) GetButton(position).Hide();
                else GetButton(position).Show();
            }
        }

        private void GameStart()
        {
            game.Start();
            for (int i = 0; i < Rand.Next(100, 500); i++) game.ShiftRandom();
            RefreshButtonField();
            count = 0;
            CountStatus.Text = count.ToString();
            timeDate = DateTime.Now; //текущее время
            timer1.Start();
        }
  
        private void Restore()
        {
            if (count > 0)
            {
                game.GameRestore(); //загрузить прошлый ход
                count--;
                CountStatus.Text = count.ToString();
                RefreshButtonField(); //обновление измененных полей
            }
        }

        private void startMenu_Click_1(object sender, EventArgs e)
        {
            GameStart();
        }

        private void отменаХодаToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Restore();
        }

        private void ИзменитьРазмерtoolStripMenuItem_Click(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            ReSize form = new ReSize();
            form.ShowDialog();
            int _size = form.Size;
            if (_size != -1)
            {
                NewField(_size);
                game = new GameLibrary.Game(_size);
                GameStart();
            }
            timer1.Enabled = true;
        }
        private void NewField(int _size)
        {
            size = _size;
            tableLayoutPanel1.RowCount = size;
            tableLayoutPanel1.ColumnCount = size;
            tableLayoutPanel1.RowStyles.Clear();
            tableLayoutPanel1.ColumnStyles.Clear();
          
            for (int i = 0; i < tableLayoutPanel1.RowCount; i++)
                tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, (float)100 / tableLayoutPanel1.RowCount));
              for (int i = 0; i < tableLayoutPanel1.ColumnCount; i++)
                tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, (float)100 / tableLayoutPanel1.ColumnCount));
            tableLayoutPanel1.Controls.Clear();
            for (int i = 0; i < tableLayoutPanel1.RowCount; i++)
                for (int j = 0; j < tableLayoutPanel1.ColumnCount; j++)
                {
                    Button button = new Button()
                    {
                        Text = (i * tableLayoutPanel1.RowCount + j + 1).ToString(),
                        Font = new Font("Times New Roman", 20),
                        Dock = DockStyle.Fill,
                        Tag = i * tableLayoutPanel1.RowCount + j,
                        TabStop = false,
                    };
                    button.Click += Button_Click;
                    tableLayoutPanel1.Controls.Add(button, j, i);
                }
        }
        private void Fifteen_Load_1(object sender, EventArgs e)
        {
            NewField(size);
            this.ActiveControl = null;
            GameStart();
        }

        private void Fifteen_FormClosing_1(object sender, FormClosingEventArgs e)
        {
            MessageBoxButtons change = MessageBoxButtons.YesNo;
            DialogResult result = MessageBox.Show(this, "Вы действительно хотите закрыть приложение?", "Закрыть приложение", change);
            if (result == DialogResult.No) e.Cancel = true;
            else Application.ExitThread();
        }

        private void timer1_Tick_1(object sender, EventArgs e)
        {
            sec = DateTime.Now.Subtract(timeDate); //секунд с начала игры
            TimeStatus.Text = sec.ToString(@"hh\:mm\:ss");
        }

        private void Fifteen_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 8) Restore(); // клавиша Backspace отменяет ход
            if (e.KeyValue == 32) // читы 
            {
                Victory victory = new Victory(count, sec);
                victory.ShowDialog();
                GameStart();
            }
        }
    }
}
