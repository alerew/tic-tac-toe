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
    }
    public enum Obj
    {
        Cross,
        Zero
    }
}
