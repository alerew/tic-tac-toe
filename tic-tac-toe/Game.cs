using System;
using System.Collections.Generic;
using System.Text;

namespace tic_tac_toe
{
    public class Game
    {
        char[,] Field;
        public static Dictionary<char, Obj> CharToObj = new() { ['x'] = Obj.Cross, ['o'] = Obj.Zero };
        public static Dictionary<Obj, char> ObjToChar = new() { [Obj.Cross] = 'x', [Obj.Zero] = 'o' };
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
                    Field[x, y] = ObjToChar[o];
                    return true;
                }
                Console.WriteLine("Клетка уже занята. Выберите другую");
                return false;
            }
            Console.WriteLine("Такой клетки не существует. Выберите другую");
            return false;
        }
        public Obj? CheckWin()
        {
            for (int i = 0; i < 3; i++)
            {
                if (Field[i, 0] != ' ' && Field[i, 0] == Field[i, 1] && Field[i, 1] == Field[i, 2]) // проверка строк
                    return CharToObj[Field[i, 0]];
                if (Field[0, i] != ' ' && Field[0, i] == Field[1, i] && Field[1, i] == Field[2, i]) // проверка столбцов
                    return CharToObj[Field[0, i]];
            }
            if (Field[1, 1] != ' ' && 
                ((Field[0, 0] == Field[1, 1] && Field[1, 1] == Field[2, 2]) ||
                (Field[2, 0] == Field[1, 1] && Field[1, 1] == Field[0, 2])))    // проверка диагоналей
                return CharToObj[Field[1, 1]];
            return null;
        }
        public bool CheckDraw()
        {
            for (int i = 0; i < 3; i++)
                for(int j = 0; j < 3; j++)
                    if (Field[i, j] == ' ')
                        return false;
            return true;
        }
    }
}
