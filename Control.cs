using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    class Control
    {
        public Board b = new Board();
        string[,] display = new string[10, 9]; //为了打印棋盘而创建的string数组
        string color = "red";

        //打印棋盘
        public void Display()
        {
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    if (i == 4 || i == 5)
                    {
                        if (b.chess[i, j] == null)
                        {
                            display[i, j] = "—";
                            Console.Write(display[i, j]);
                        }
                        else
                        {
                            display[i, j] = b.chess[i, j].GettheNameOfChess();
                            Console.Write(display[i, j]);
                        }
                    }else
                    {
                        if (b.chess[i, j] == null)
                        {
                            display[i, j] = "＋";
                            Console.Write(display[i, j]);
                        }
                        else
                        {
                            display[i, j] = b.chess[i, j].GettheNameOfChess();
                            Console.Write(display[i, j]);
                        }
                    }


                }
                Console.WriteLine("");
            }
        }

        public void PlayerSelection()
        {
            int beginX;
            int beginY;
            int endX;
            int endY;
            bool inputcondition1 = false;
            bool inputcondition2 = false;
            //请求用户输入要走的棋子位置
            Console.WriteLine($"You are {color} side now!");
            Console.WriteLine($"Please choose a {color} Piece you want to move\n");
            Console.Write("x:");
            string beginx = Console.ReadLine();
            beginX = Convert.ToInt32(beginx);
            Console.Write("y:");
            string beginy = Console.ReadLine();
            beginY = Convert.ToInt32(beginy);
            //判断用户输入位置是否有棋子可选，若有，该位置所对应的棋子，是否超出棋盘范围，是否为当前方的颜色
            while (!inputcondition1)
            {
                //超出棋盘范围
                bool condition1;
                if (beginX < 0 || beginX > 9 || beginY < 0 || beginY > 8)
                {
                    Console.WriteLine("This is not a good choice, it is out of the board!!");
                    Console.WriteLine("");
                    Console.WriteLine("Please choose from colum 0-8 and row  0-9 to move");
                    Console.Write("x:");
                    string beginx1 = Console.ReadLine();
                    beginX = Convert.ToInt32(beginx1);
                    Console.Write("y:");
                    string beginy1 = Console.ReadLine();
                    beginY = Convert.ToInt32(beginy1);
                }
                condition1 = true;
               
                //该位置没有棋子可以选
                bool condition2;
                if (b.chess[beginX, beginY] == null)
                {
                    Console.WriteLine("There is no chess you can choose!!");
                    Console.WriteLine("");
                    Console.WriteLine("Please choose a place which exists a chess");
                    Console.Write("x:");
                    string beginx1 = Console.ReadLine();
                    beginX = Convert.ToInt32(beginx1);
                    Console.Write("y:");
                    string beginy1 = Console.ReadLine();
                    beginY = Convert.ToInt32(beginy1);
                    condition1 = false;
                }
                condition2 = true;
                
                
                
                //选的不是当前颜色棋子
                bool condition3;
                if (b.GetChessColor(beginX, beginY) != color)
                {
                    Console.WriteLine($"You are {color} side!!");
                    Console.WriteLine("");
                    Console.WriteLine($"Please choose a {color} piece ");
                    Console.Write("x:");
                    string beginx1 = Console.ReadLine();
                    beginX = Convert.ToInt32(beginx1);
                    Console.Write("y:");
                    string beginy1 = Console.ReadLine();
                    beginY = Convert.ToInt32(beginy1);
                    condition2 = false;
                }
                condition3 = true;
                
                inputcondition1 = condition1 && condition2 && condition3;             
             }
            Console.WriteLine("-----------------------------------------------------------"); 
            Console.WriteLine($"You have chosen : {b.GetChessName(beginX,beginY)}");
            Console.WriteLine("-----------------------------------------------------------");

            Display();
            Console.WriteLine("-----------------------------------------------------------");

            //请求用户输入所选棋子要去的位置
            Console.WriteLine("Where do you want to go?\n");
            Console.Write("x:");
            string endx = Console.ReadLine();
            endX = Convert.ToInt32(endx);
            Console.Write("y:");
            string endy = Console.ReadLine();
            endY = Convert.ToInt32(endy);

            //超出棋盘范围
            while (!inputcondition2)
            {
                bool condition1;
                if (endX < 0 || endX > 9 || endY < 0 || endY > 8)
                {
                    Console.WriteLine("This is not a good choice, it is out of the board!!");
                    Console.WriteLine("");
                    Console.WriteLine("Please choose from colum 0-8 and row  0-9 to move");
                    Console.Write("x:");
                    string endx1 = Console.ReadLine();
                    endX = Convert.ToInt32(endx1);
                    Console.Write("y:");
                    string endy1 = Console.ReadLine();
                    endY = Convert.ToInt32(endy1);
                }
                condition1 = true;
               
                //要去的点是否与现在相同
                bool condition2;
                if ((beginX == endX) && (beginY == endY))
                {
                    Console.WriteLine("Don't stay in the original place!!");
                    Console.WriteLine("");
                    Console.WriteLine("Please choose another place which is different from where you are now");
                    Console.Write("x:");
                    string endx1 = Console.ReadLine();
                    endX = Convert.ToInt32(endx1);
                    Console.Write("y:");
                    string endy1 = Console.ReadLine();
                    endY = Convert.ToInt32(endy1);
                    condition1 = false;
                }
                condition2 = true;
                
                //能否去,关系到每个棋子种类的走法问题
                bool condition3;
                if (b.Movemethod(beginX, beginY, endX, endY)==false)
                {
                    Console.WriteLine( "You can't go there!");
                    Console.WriteLine("");
                    Console.WriteLine("Where do you want to go? ");
                    Console.Write("x:");
                    string endx1 = Console.ReadLine();
                    endX = Convert.ToInt32(endx1);
                    Console.Write("y:");
                    string endy1 = Console.ReadLine();
                    endY = Convert.ToInt32(endy1);
                    condition2 = false;
                }
                condition3 = true;

                inputcondition2 = condition1 && condition2 && condition3;

            }

            b.MoveChess(beginX, beginY, endX, endY);
        
            Display();   
        }

        public void SwitchPlayer()
        {
            switch (color)
            {
                case "red":
                    color = "black";
                    break;
                case "black":
                    color = "red";
                    break;   
            }
        }


    }
}
