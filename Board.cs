using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    class Board
    {
        public Chess[,] chess = new Chess[10, 9];
        King Kr = new King("red", 9, 4);
        Guard Gr1 = new Guard("red", 9, 3); Guard Gr2 = new Guard("red", 9, 5);
        Elephant Er1 = new Elephant("red", 9, 2); Elephant Er2 = new Elephant("red", 9, 6);
        Horse Hr1 = new Horse("red", 9, 1); Horse Hr2 = new Horse("red", 9, 7);
        Rook Rr1 = new Rook("red", 9, 0); Rook Rr2 = new Rook("red", 9, 8);
        Cannon Cr1 = new Cannon("red", 7, 1); Cannon Cr2 = new Cannon("red", 7, 7);
        Soldier Sr1 = new Soldier("red", 6, 0); Soldier Sr2 = new Soldier("red", 6, 2);
        Soldier Sr3 = new Soldier("red", 6, 4); Soldier Sr4 = new Soldier("red", 6, 6);
        Soldier Sr5 = new Soldier("red", 6, 8);

        King Kb = new King("black", 0, 4);
        Guard Gb1 = new Guard("black", 0, 3); Guard Gb2 = new Guard("black", 0, 5);
        Elephant Eb1 = new Elephant("black", 0, 2); Elephant Eb2 = new Elephant("black", 0, 6);
        Horse Hb1 = new Horse("black", 0, 1); Horse Hb2 = new Horse("black", 0, 7);
        Rook Rb1 = new Rook("black", 0, 0); Rook Rb2 = new Rook("black", 0, 8);
        Cannon Cb1 = new Cannon("black", 2, 1); Cannon Cb2 = new Cannon("black", 2, 7);
        Soldier Sb1 = new Soldier("black", 3, 0); Soldier Sb2 = new Soldier("black", 3, 2);
        Soldier Sb3 = new Soldier("black", 3, 4); Soldier Sb4 = new Soldier("black", 3, 6);
        Soldier Sb5 = new Soldier("black", 3, 8);

        public string GetChessName(int x, int y)
        {

            return chess[x, y].GettheNameOfChess();
        }

        public string GetChessColor(int x, int y)
        {

            return chess[x, y].GetColor();
        }

        public void MoveChess(int beginX, int beginY, int endX, int endY)
        {

            chess[endX, endY] = chess[beginX, beginY];
            chess[beginX, beginY] = null;
        }

        public bool Movemethod(int beginX, int beginY, int endX, int endY)
        {
            bool cango = true;
            switch (chess[beginX, beginY].GettheNameOfChess())
            {
                //炮的普通移动：
                case "Cr":
                    //左右移动
                    if ((beginX == endX) && (beginY != endY))
                    {
                        if (endY < beginY)
                        {
                            if (chess[endX, endY] == null)
                            {
                                for (int j = beginY - 1; j > endY; j--)
                                {
                                    if (chess[endX, j] != null)
                                    {
                                        cango = false;
                                        break;
                                    }
                                    else
                                        cango = true;
                                }
                            }
                            //炮的“吃”法：
                            //去的地方有棋子，且那个棋子颜色是与自己不同的，即敌方的棋子
                            else if ((chess[endX, endY] != null) && (!chess[beginX, beginY].GetColor().Equals(chess[endX, endY].GetColor())))
                            {
                                //判断起点和目的地之间是否有棋子，且只有一个，才能吃目的地的棋子，否则吃不了
                                int account = 0;
                                for (int j = beginY - 1; j > endY; j--)
                                {
                                    if (chess[endX, j] != null)
                                    {
                                        account = account + 1;
                                    }
                                }
                                if (account == 1)
                                {
                                    cango = true;
                                }
                                else
                                    cango = false;
                            }
                            else
                                cango = false;

                        }
                        else if (endY > beginY)
                        {
                            if (chess[endX, endY] == null)
                            {
                                for (int j = endY - 1; j > beginY; j--)
                                {
                                    if (chess[endX, j] != null)
                                    {
                                        cango = false;
                                        break;
                                    }
                                    else
                                        cango = true;
                                }
                            }
                            else if ((chess[endX, endY] != null) && (!chess[beginX, beginY].GetColor().Equals(chess[endX, endY].GetColor())))
                            {
                                int account = 0;
                                for (int j = endY - 1; j > beginY; j--)
                                {
                                    if (chess[endX, j] != null)
                                    {
                                        account = account + 1;
                                    }
                                }
                                if (account == 1)
                                {
                                    cango = true;
                                }
                                else
                                    cango = false;
                            }
                            else
                                cango = false;
                        }

                    }
                    //上下移动
                    else if ((beginY == endY) && (beginX != endX))
                    {
                        if (endX < beginX)
                        {
                            if (chess[endX, endY] == null)
                            {
                                for (int i = beginX - 1; i > endX; i--)
                                {
                                    if (chess[i, endY] != null)
                                    {
                                        cango = false;
                                        break;
                                    }
                                    else
                                        cango = true;
                                }
                            }
                            //炮的“吃”法：
                            //去的地方有棋子，且那个棋子颜色是与自己不同的，即敌方的棋子
                            else if ((chess[endX, endY] != null) && (!chess[beginX, beginY].GetColor().Equals(chess[endX, endY].GetColor())))
                            {
                                //判断起点和目的地之间是否有棋子，且只有一个，才能吃目的地的棋子，否则吃不了
                                int account = 0;
                                for (int i = beginX - 1; i > endX; i--)
                                {
                                    if (chess[i, endY] != null)
                                    {
                                        account = account + 1;
                                    }
                                }
                                if (account == 1)
                                {
                                    cango = true;
                                }
                                else
                                    cango = false;
                            }
                            else
                                cango = false;

                        }

                        else if (endX > beginX)
                        {
                            if (chess[endX, endY] == null)
                            {
                                for (int i = endX - 1; i > beginX; i--)
                                {
                                    if (chess[i, endX] != null)
                                    {
                                        cango = false;
                                        break;
                                    }
                                    else
                                        cango = true;
                                }
                            }
                            else if ((chess[endX, endY] != null) && (!chess[beginX, beginY].GetColor().Equals(chess[endX, endY].GetColor())))
                            {
                                int account = 0;
                                for (int i = endX - 1; i > beginX; i--)
                                {
                                    if (chess[i, endY] != null)
                                    {
                                        account = account + 1;
                                    }
                                }
                                if (account == 1)
                                {
                                    cango = true;
                                }
                                else
                                    cango = false;
                            }
                            else
                                cango = false;
                        }
                        else
                            cango = false;
                    }
                    else
                    {
                        Console.WriteLine("You can only go up or down or left or right!");
                        cango = false;
                    }
                    break;
                //---------------------------------------------------------------------------------------------------------------
                //---------------------------------------------------------------------------------------------------------------
                case "Cb":
                    //左右移动
                    if ((beginX == endX) && (beginY != endY))
                    {
                        if (endY < beginY)
                        {
                            if (chess[endX, endY] == null)
                            {
                                for (int j = beginY - 1; j > endY; j--)
                                {
                                    if (chess[endX, j] != null)
                                    {
                                        cango = false;
                                        break;
                                    }
                                    else
                                        cango = true;
                                }
                            }
                            //炮的“吃”法：
                            //去的地方有棋子，且那个棋子颜色是与自己不同的，即敌方的棋子
                            else if ((chess[endX, endY] != null) && (!chess[beginX, beginY].GetColor().Equals(chess[endX, endY].GetColor())))
                            {
                                //判断起点和目的地之间是否有棋子，且只有一个，才能吃目的地的棋子，否则吃不了
                                int account = 0;
                                for (int j = beginY - 1; j > endY; j--)
                                {
                                    if (chess[endX, j] != null)
                                    {
                                        account = account + 1;
                                    }
                                }
                                if (account == 1)
                                {
                                    cango = true;
                                }
                                else
                                    cango = false;
                            }
                            else
                                cango = false;

                        }
                        else if (endY > beginY)
                        {
                            if (chess[endX, endY] == null)
                            {
                                for (int j = endY - 1; j > beginY; j--)
                                {
                                    if (chess[endX, j] != null)
                                    {
                                        cango = false;
                                        break;
                                    }
                                    else
                                        cango = true;
                                }
                            }
                            else if ((chess[endX, endY] != null) && (!chess[beginX, beginY].GetColor().Equals(chess[endX, endY].GetColor())))
                            {
                                int account = 0;
                                for (int j = endY - 1; j > beginY; j--)
                                {
                                    if (chess[endX, j] != null)
                                    {
                                        account = account + 1;
                                    }
                                }
                                if (account == 1)
                                {
                                    cango = true;
                                }
                                else
                                    cango = false;
                            }
                            else
                                cango = false;
                        }

                    }
                    //上下移动
                    else if ((beginY == endY) && (beginX != endX))
                    {
                        if (endX < beginX)
                        {
                            if (chess[endX, endY] == null)
                            {
                                for (int i = beginX - 1; i > endX; i--)
                                {
                                    if (chess[i, endY] != null)
                                    {
                                        cango = false;
                                        break;
                                    }
                                    else
                                        cango = true;
                                }
                            }
                            //炮的“吃”法：
                            //去的地方有棋子，且那个棋子颜色是与自己不同的，即敌方的棋子
                            else if ((chess[endX, endY] != null) && (!chess[beginX, beginY].GetColor().Equals(chess[endX, endY].GetColor())))
                            {
                                //判断起点和目的地之间是否有棋子，且只有一个，才能吃目的地的棋子，否则吃不了
                                int account = 0;
                                for (int i = beginX - 1; i > endX; i--)
                                {
                                    if (chess[i, endY] != null)
                                    {
                                        account = account + 1;
                                    }
                                }
                                if (account == 1)
                                {
                                    cango = true;
                                }
                                else
                                    cango = false;
                            }
                            else
                                cango = false;

                        }

                        else if (endX > beginX)
                        {
                            if (chess[endX, endY] == null)
                            {
                                for (int i = endX - 1; i > beginX; i--)
                                {
                                    if (chess[i, endX] != null)
                                    {
                                        cango = false;
                                        break;
                                    }
                                    else
                                        cango = true;
                                }
                            }
                            else if ((chess[endX, endY] != null) && (!chess[beginX, beginY].GetColor().Equals(chess[endX, endY].GetColor())))
                            {
                                int account = 0;
                                for (int i = endX - 1; i > beginX; i--)
                                {
                                    if (chess[i, endY] != null)
                                    {
                                        account = account + 1;
                                    }
                                }
                                if (account == 1)
                                {
                                    cango = true;
                                }
                                else
                                    cango = false;
                            }
                            else
                                cango = false;
                        }
                        else
                            cango = false;
                    }
                    else
                    {
                        Console.WriteLine("You can only go up or down or left or right!");
                        cango = false;
                    }
                    break;
                //---------------------------------------------------------------------------------------------------------------
                //---------------------------------------------------------------------------------------------------------------
                case "Rr":
                    //左右移动
                    if ((beginX == endX) && (beginY != endY))
                    {
                        if (endY < beginY)
                        {
                            //要么到的地方没棋子，要么到的地方的是敌方的棋子，但无论如何，出发地和目的地之间必须没有其他棋子
                            if ((chess[endX, endY] == null) || ((chess[endX, endY] != null) && (!chess[beginX, beginY].GetColor().Equals(chess[endX, endY].GetColor()))))
                            {
                                for (int j = beginY - 1; j > endY; j--)
                                {
                                    if (chess[endX, j] != null)
                                    {
                                        cango = false;
                                        break;
                                    }
                                    else
                                        cango = true;
                                }
                            }
                            else
                                cango = false;
                        }
                        else
                        {
                            if ((chess[endX, endY] == null) || ((chess[endX, endY] != null) && (!chess[beginX, beginY].GetColor().Equals(chess[endX, endY].GetColor()))))
                            {
                                for (int j = endY - 1; j > beginY; j--)
                                {
                                    if (chess[beginX, j] != null)
                                    {
                                        cango = false;
                                        break;
                                    }
                                    else
                                        cango = true;
                                }
                            }
                            else
                                cango = false;
                        }
                    }
                    //上下移动
                    else if ((beginY == endY) && (beginX != endX))
                    {
                        if (endX < beginX)
                        {
                            //要么到的地方没棋子，要么到的地方的是敌方的棋子，但无论如何，出发地和目的地之间必须没有其他棋子
                            if ((chess[endX, endY] == null) || ((chess[endX, endY] != null) && (!chess[beginX, beginY].GetColor().Equals(chess[endX, endY].GetColor()))))
                            {
                                for (int i = beginX - 1; i > endX; i--)
                                {
                                    if (chess[i, endY] != null)
                                    {
                                        cango = false;
                                        break;
                                    }
                                    else
                                        cango = true;
                                }
                            }
                            else
                                cango = false;
                        }
                        else
                        {
                            if ((chess[endX, endY] == null) || ((chess[endX, endY] != null) && (!chess[beginX, beginY].GetColor().Equals(chess[endX, endY].GetColor()))))
                            {
                                for (int i = endX - 1; i > beginX; i--)
                                {
                                    if (chess[i, beginY] != null)
                                    {
                                        cango = false;
                                        break;
                                    }
                                    else
                                        cango = true;
                                }
                            }
                            else
                                cango = false;
                        }
                    }
                    else
                    {
                        Console.WriteLine("You can only go up or down or left or right!");
                        cango = false;
                    }
                    break;
                //---------------------------------------------------------------------------------------------------------------
                //---------------------------------------------------------------------------------------------------------------
                case "Rb":
                    //左右移动
                    if ((beginX == endX) && (beginY != endY))
                    {
                        if (endY < beginY)
                        {
                            //要么到的地方没棋子，要么到的地方的是敌方的棋子，但无论如何，出发地和目的地之间必须没有其他棋子
                            if ((chess[endX, endY] == null) || ((chess[endX, endY] != null) && (!chess[beginX, beginY].GetColor().Equals(chess[endX, endY].GetColor()))))
                            {
                                for (int j = beginY - 1; j > endY; j--)
                                {
                                    if (chess[endX, j] != null)
                                    {
                                        cango = false;
                                        break;
                                    }
                                    else
                                        cango = true;
                                }
                            }
                            else
                                cango = false;
                        }
                        else
                        {
                            if ((chess[endX, endY] == null) || ((chess[endX, endY] != null) && (!chess[beginX, beginY].GetColor().Equals(chess[endX, endY].GetColor()))))
                            {
                                for (int j = endY - 1; j > beginY; j--)
                                {
                                    if (chess[beginX, j] != null)
                                    {
                                        cango = false;
                                        break;
                                    }
                                    else
                                        cango = true;
                                }
                            }
                            else
                                cango = false;
                        }
                    }
                    //上下移动
                    else if ((beginY == endY) && (beginX != endX))
                    {
                        if (endX < beginX)
                        {
                            //要么到的地方没棋子，要么到的地方的是敌方的棋子，但无论如何，出发地和目的地之间必须没有其他棋子
                            if ((chess[endX, endY] == null) || ((chess[endX, endY] != null) && (!chess[beginX, beginY].GetColor().Equals(chess[endX, endY].GetColor()))))
                            {
                                for (int i = beginX - 1; i > endX; i--)
                                {
                                    if (chess[i, endY] != null)
                                    {
                                        cango = false;
                                        break;
                                    }
                                    else
                                        cango = true;
                                }
                            }
                            else
                                cango = false;
                        }
                        else
                        {
                            if ((chess[endX, endY] == null) || ((chess[endX, endY] != null) && (!chess[beginX, beginY].GetColor().Equals(chess[endX, endY].GetColor()))))
                            {
                                for (int i = endX - 1; i > beginX; i--)
                                {
                                    if (chess[i, beginY] != null)
                                    {
                                        cango = false;
                                        break;
                                    }
                                    else
                                        cango = true;
                                }
                            }
                            else
                                cango = false;
                        }
                    }
                    else
                    {
                        Console.WriteLine("You can only go up or down or left or right!");
                        cango = false;
                    }
                    break;

            }
            return cango;
        }

        public void Initialization()
        {
            chess[9, 4] = Kr;
            chess[9, 3] = Gr1;
            chess[9, 5] = Gr2;
            chess[9, 2] = Er1;
            chess[9, 6] = Er2;
            chess[9, 1] = Hr1;
            chess[9, 7] = Hr2;
            chess[9, 0] = Rr1;
            chess[9, 8] = Rr2;
            chess[7, 1] = Cr1;
            chess[7, 7] = Cr2;
            chess[6, 0] = Sr1;
            chess[6, 2] = Sr2;
            chess[6, 4] = Sr3;
            chess[6, 6] = Sr4;
            chess[6, 8] = Sr5;

            chess[0, 4] = Kb;
            chess[0, 3] = Gb1;
            chess[0, 5] = Gb2;
            chess[0, 2] = Eb1;
            chess[0, 6] = Eb2;
            chess[0, 1] = Hb1;
            chess[0, 7] = Hb2;
            chess[0, 0] = Rb1;
            chess[0, 8] = Rb2;
            chess[2, 1] = Cb1;
            chess[2, 7] = Cb2;
            chess[3, 0] = Sb1;
            chess[3, 2] = Sb2;
            chess[3, 4] = Sb3;
            chess[3, 6] = Sb4;
            chess[3, 8] = Sb5;

        }
    }
}
