using System;
using System.Collections.Generic;
using System.Text;

namespace tic_tac_toe
{
    public class Game
    {
        char[,] Field;
        public Game()
        {
            Field = new char[3, 3];
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Field[i, j] = ' ';
                }
            }
        }
        public void Draw()
        {
            Console.Clear();
            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine("-------------");
                for (int j = 0; j < 3; j++)
                {
                    Console.Write($"| {Field[i, j]} ");
                }
                Console.WriteLine('|');
            }
            Console.WriteLine("-------------");
        }
        public bool Set(int x, int y, Obj o)
        {
            x--;
            y--;
            if (x >= 0 && x <= 2 && y >= 0 && y <= 2)
            {
                if (Field[x, y] == ' ')
                {
                    Field[x, y] = o == Obj.Cross ? 'x' : 'o';
                    return true;
                }
                Console.WriteLine("Клетка уже занята. Выберите другую");
                return false;
            }
            Console.WriteLine("Такой клетки не существует. Выберите другую");
            return false;
        }
        public bool CheckWin()
        {
            for (int i = 0; i < 3; i++)
            {
                var r = CheckRow(i);
                var c = CheckCol(i);
                if (Test(r) || Test(c))
                    return true;
            }

            return Test(CheckDiag());
        }
        private Obj? CheckRow(int r)
        {
            if (Field[r,0] != ' ' && Field[r, 0] == Field[r, 1] && Field[r, 1] == Field[r, 2])
            {
                return Field[r, 0] == 'x' ? Obj.Cross : Obj.Zero;
            }
            return null;
        }
        private Obj? CheckCol(int c)
        {
            if (Field[0, c] != ' ' && Field[0, c] == Field[1, c] && Field[1, c] == Field[2, c])
            {
                return Field[0, c] == 'x' ? Obj.Cross : Obj.Zero;
            }
            return null;
        }
        private Obj? CheckDiag()
        {
            if (Field[1, 1] != ' ' && ((Field[0, 0] == Field[1, 1] && Field[1, 1] == Field[2, 2]) ||
                (Field[2, 0] == Field[1, 1] && Field[1, 1] == Field[0, 2])))
            {
                return Field[1, 1] == 'x' ? Obj.Cross : Obj.Zero;
            }
            return null;
        }
        private bool Test(Obj? obj)
        {
            if(obj is not null)
            {
                Console.WriteLine($"Победили {(obj == Obj.Zero ? "нолики" : "крестики")}");
                return true;
            }
            return false;
        }
    }
}
