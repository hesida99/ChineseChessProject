using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Control game = new Control();
            game.b.Initialization();//初始化
            game.Display();//展示棋盘
            //要写一个循环在这里
            int i = 0;
            while(i == 0)
            {
                Console.WriteLine("-----------------------------------------------------------");
                game.PlayerSelection();
                game.SwitchPlayer();
                Console.WriteLine("-----------------------------------------------------------");
            }
           

        }
    }
}
