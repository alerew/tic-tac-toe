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
    }
    public enum Obj
    {
        Cross,
        Zero
    }
}
