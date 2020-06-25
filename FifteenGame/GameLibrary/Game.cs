using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLibrary
{
    public class Game
    {
        int[,] field;
        int size;
        public int count = 0, x0, y0; 
        Random Rand = new Random();
        Carataker Save = new Carataker();

        public Game(int size) 
        {
            this.size = size;
            field = new int[size, size];
        }
        private int CoordinatesToPosition(int x, int y)//метод преобразования координат двумерного массива в номер кнопки
        {
            if (x < 0) x = 0;
            if (y < 0) y = 0;
            if (x > size - 1) x = size - 1;
            if (y > size - 1) y = size - 1;
            return x + y * size;
        }
        private void PositionToCoordinates(int position, out int x, out int y)//метод преобразования номера кнопки в координаты двумерного массива
        {
            if (position < 0) position = 0;
            if (position > Math.Pow(size, 2) - 1) position = size * size - 1;
            x = position % size;
            y = position / size;
        }
        public void Start()
        {
            for (int x = 0; x < size; ++x) //заполняем поле field значениями от 1 до 16.
                for (int y = 0; y < size; ++y)
                    field[x, y] = CoordinatesToPosition(x, y) + 1;
            x0 = size - 1;
            y0 = size - 1;
            field[x0, y0] = 0;
        }
        public int GetNumber(int position) //функция по позиции нажатой кнопки возвращает значение, хранящееся в соответствующей ячейке поля
        {
            int x, y;
            PositionToCoordinates(position, out x, out y);
            if (x < 0 && x >= size * size) return 0;//проверка корректности значений координат x, y
            if (y < 0 && y >= size * size) return 0;
            return field[x, y];
        }
        public bool Shift(int position)
        {
            int x, y;
            PositionToCoordinates(position, out x, out y);//находим координаты x, y ячейки массива, которую нужно поменять с нулевой ячейкой.
            if (Math.Abs(x - x0) + Math.Abs(y - y0) != 1) return false; // проверка на то, что перемещается соседняя кнопка
            GameSave();
            field[x0, y0] = field[x, y]; //меняем местами ячейки
            field[x, y] = 0;
            x0 = x;
            y0 = y;
            return true;
        }
        public void ShiftRandom() //при старте игры поля перемешиваются 
        {
            int a = Rand.Next(0, 4);
            int x = x0;
            int y = y0; 
            if (a == 0) x++; //ход на одну из четырех соседних клеток
            else if (a == 1) x--;
            else if (a == 2) y++;
            else y--;
            Shift(CoordinatesToPosition(x, y));
        }
        public bool Check() //метод проверки завершения игры
        {
            if (!(x0 != 0 && y0 != 0)) return false;
            for (int x = 0; x < size; ++x)
                for (int y = 0; y < size; ++y)
                {
                    if (x == size - 1 && y == size - 1) return true;
                    else if (field[x, y] != CoordinatesToPosition(x, y) + 1) return false;
                }
            return true;
        }
        public void GameSave() //сохранить ход
        { 
            Save.SaveStep(new Memento(field, size)); 
        }
        public void GameRestore() //вывод сохранения
        {
            Memento memento = Save.BackStep();
            int[,] fieldSave = memento.Getfield();
            for (int i = 0; i < size; ++i)
                for (int j = 0; j < size; ++j)
                {
                    field[i, j] = fieldSave[i, j];
                    if (field[i, j] == 0)
                    {
                        x0 = i; y0 = j;
                    }
                }
        }
    }
}
