using System;
using System.Collections.Generic;
using System.Text;

//这个是棋盘类

namespace ConsoleXiangqi
{
    public class board
    {
        //第一步先把所有棋子创建好，我想了下应该只能靠手动输入初始化了···
        public chess[,] Chess = new chess[9,10];

        chess blackRood1 = new rood("black", 0, 0);

        chess blackHorse1 = new horse("black", 1, 0);

        chess blackElephant1 = new elephant("black", 2, 0);

        chess blackguard1 = new guard("black", 3, 0);

        chess blackgeneral = new general("black", 4, 0);

        chess blackguard2 = new guard("black", 5, 0);

        chess blackElephant2 = new elephant("black", 6, 0);

        chess blackHorse2 = new horse("black", 7, 0);

        chess blackRood2 = new rood("black", 8, 0);

        chess blackCannon1 = new cannon("black", 1, 2);

        chess blackCannon2 = new cannon("black", 7, 2);

        chess blacksoldier1 = new soldier("black", 0, 3);

        chess blacksoldier2 = new soldier("black", 2, 3);

        chess blacksoldier3 = new soldier("black", 4, 3);

        chess blacksoldier4 = new soldier("black", 6, 3);

        chess blacksoldier5 = new soldier("black", 8, 3);

        chess redRood1 = new rood("red", 0, 9);

        chess redHorse1 = new horse("red", 1, 9);

        chess redElephant1 = new elephant("red", 2, 9);

        chess redguard1 = new guard("red", 3, 9);

        chess redgeneral = new general("red", 4, 9);

        chess redguard2 = new guard("red", 5, 9);

        chess redElephant2 = new elephant("red", 6, 9);

        chess redHorse2 = new horse("red", 7, 9);

        chess redRood2 = new rood("red", 8, 9);

        chess redCannon1 = new cannon("red", 1, 7);

        chess redCannon2 = new cannon("red", 7, 7);

        chess redsoldier1 = new soldier("red", 0, 6);

        chess redsoldier2 = new soldier("red", 2, 6);

        chess redsoldier3 = new soldier("red", 4, 6);

        chess redsoldier4 = new soldier("red", 6, 6);

        chess redsoldier5 = new soldier("red", 8, 6);

        public board()
        {

        }

        //用坐标可以获得当前点棋子名字
        public string GetChessName(int colum, int row)
        {
            
            return Chess[colum, row].Getname();
        }


        //用坐标可以获得当前点棋子颜色
        public string GetChessColor(int colum, int row)
        {
            return Chess[colum, row].Getcolor();
        }

        //移动棋子类
        public void MoveChess(string strBegincolum, string strBeginrow, string strEndcolum, string strEndrow)//我们之后会利用Split截取用户输入的坐标，所以我就把点搞成String类型
        {
            int begincolum = int.Parse(strBegincolum);//先把这些坐标改成int类型
            int beginrow = int.Parse(strBeginrow);
            int endcolum = int.Parse(strEndcolum);
            int endrow = int.Parse(strEndrow);
            Chess[endcolum, endrow] = Chess[begincolum, beginrow];//把用户想去的点对应“棋盘”的二维数组坐标的棋子换成用户想走的棋子（即初始点的棋子放到终点）
            Chess[endcolum, endrow].row = endrow;
            Chess[endcolum, endrow].colum = endcolum;
            Chess[begincolum, beginrow] = new nochess(begincolum, beginrow);//然后把棋子一开始的点变为空
        }

        public bool Movemethod(int begincolum,int beginrow, int endcolum, int endrow)
        {
            bool cango = true;
            switch (Chess[begincolum, beginrow].Getname())
            {
                case "兵":
                    switch (Chess[begincolum,beginrow].color)
                    {
                        case "red":
                            if (beginrow >= 5)//无过河
                            {
                                if (endcolum == begincolum && (beginrow - endrow) == 1)
                                {
                                    cango = true;
                                }
                                else
                                {
                                    cango = false;
                                }

                            }

                            else//已经过河
                            {
                                if (begincolum - endcolum == 1 || begincolum - endcolum == -1)//兵过河后走左右
                                {
                                    if (endrow - beginrow == 0)
                                    {
                                        cango = true;
                                    }
                                    else
                                    {
                                        cango = false;
                                    }
                                }
                                else if (beginrow - endrow == 1)
                                {
                                    if (begincolum - endcolum == 0)
                                    {
                                        cango = true;
                                    }
                                    else
                                    {
                                        cango = false;
                                    }
                                }
                                else
                                {
                                    cango = false;
                                }
                            }
                            break;

                        case "black":
                            if (beginrow <= 4)//无过河
                            {
                                if (endcolum == begincolum && (endrow - beginrow) == 1)
                                {
                                    cango = true;
                                }
                                else
                                {
                                    cango = false;
                                }

                            }

                            else//已经过河
                            {
                                if (begincolum - endcolum == 1 || begincolum - endcolum == -1)//兵过河后走左右
                                {
                                    if (endrow - beginrow == 0)
                                    {
                                        cango = true;
                                    }
                                    else
                                    {
                                        cango = false;
                                    }
                                }
                                else if (endrow - beginrow == 1)
                                {
                                    if (begincolum - endcolum == 0)
                                    {
                                        cango = true;
                                    }
                                    else
                                    {
                                        cango = false;
                                    }
                                }
                                else
                                {
                                    cango = false;
                                }
                            }
                            break;
                    }
                    break;

               


                //--------------------------------------------------------------------------
                case "象":

                    switch (Chess[begincolum, beginrow].color)

                    {

                        case "black":

                            if (beginrow <= 4)

                            {

                                if ((begincolum == 2) && (beginrow == 0))

                                {

                                    if ((endcolum - begincolum == 2) && (endrow - beginrow == 2))

                                    {

                                        if (Chess[begincolum + 1, beginrow + 1].Getname() == "nochess")

                                        {

                                            cango = true;

                                        }



                                        else

                                        {

                                            cango = false;

                                        }




                                    }
                                    else if ((begincolum - endcolum == 2) && (endrow - beginrow == 2))
                                    {
                                        if (Chess[begincolum - 1, beginrow + 1].Getname() == "nochess")
                                        {
                                            cango = true;
                                        }
                                        else { cango = false; }
                                    }


                                    else

                                    {

                                        cango = false;

                                    }





                                }



                                else if ((begincolum == 4) && (beginrow == 2))

                                {

                                    if ((endcolum - begincolum == 2) && (endrow - beginrow == 2))

                                    {

                                        if ((Chess[begincolum + 1, beginrow + 1].Getname() == "nochess"))

                                        {

                                            cango = true;

                                        }
                                        else
                                        {
                                            cango = false;
                                        }

                                    }
                                    else if ((begincolum - endcolum == 2) && (beginrow - endcolum == 2))
                                    {
                                        if ((Chess[begincolum + 1, beginrow + 1].Getname() == "nochess"))
                                        {
                                            cango = true;
                                        }
                                        else { cango = false; }
                                    }

                                    else

                                    {

                                        cango = false;

                                    }

                                }



                                else if ((begincolum == 6) && (beginrow == 0))

                                {

                                    if ((endcolum - begincolum == 2) && (endrow - beginrow == 2))

                                    {

                                        if (Chess[begincolum + 1, beginrow + 1].Getname() == "nochess")

                                        {

                                            cango = true;

                                        }
                                        else
                                        {
                                            cango = false;
                                        }

                                    }
                                    else if ((begincolum - endcolum == 2) && (endrow - beginrow == 2))
                                    {
                                        if (Chess[begincolum - 1, beginrow + 1].Getname() == "nochess")
                                        {
                                            cango = true;
                                        }
                                        else
                                        {
                                            cango = false;
                                        }
                                    }

                                    else

                                    {

                                        cango = false;

                                    }

                                }



                                else if ((beginrow == 2) && (begincolum == 8))

                                {

                                    if ((begincolum - endcolum == 2) && (endrow - beginrow == 2))

                                    {

                                        if (Chess[begincolum - 1, beginrow + 1].Getname() == "nochess")

                                        {

                                            cango = true;

                                        }
                                        else
                                        {
                                            cango = false;
                                        }

                                    }

                                    else

                                    {

                                        cango = false;

                                    }



                                }





                            }





                            break;





                        case "red":

                            if (beginrow >= 5)

                            {

                                if ((beginrow == 9) && (begincolum == 2))

                                {

                                    if ((beginrow - endrow == 2) && (begincolum - endcolum == 2))

                                    {

                                        if (Chess[begincolum - 1, beginrow - 1].Getname() == "nochess")

                                        {

                                            cango = true;

                                        }
                                        else
                                        {
                                            cango = false;
                                        }

                                    }
                                    else if ((beginrow - endrow == 2) && (endcolum - begincolum == 2))
                                    {
                                        if (Chess[begincolum + 1, beginrow - 1].Getname() == "nochess")
                                        {
                                            cango = true;
                                        }
                                        else
                                        {
                                            cango = false;
                                        }
                                    }

                                    else

                                    {

                                        cango = false;

                                    }


                                }

                                if ((begincolum == 0) && (beginrow == 7))

                                {

                                    if ((endcolum - begincolum == 2) && (beginrow - endrow == 2))

                                    {

                                        if (Chess[begincolum + 1, beginrow - 1].Getname() == "nochess")

                                        {

                                            cango = true;

                                        }
                                        else
                                        {
                                            cango = false;
                                        }

                                    }

                                    else

                                    {

                                        cango = false;

                                    }

                                }

                                if ((beginrow == 9) && (begincolum == 6))

                                {

                                    if ((beginrow - endrow == 2) && (begincolum - endcolum == 2))

                                    {

                                        if (Chess[begincolum - 1, beginrow - 1].Getname() == "nochess")

                                        {

                                            cango = true;

                                        }
                                        else
                                        {
                                            cango = false;
                                        }

                                    }
                                    else if ((beginrow - endrow == 2) && (endcolum - begincolum == 2))
                                    {
                                        if (Chess[begincolum + 1, beginrow - 1].Getname() == "nochess")
                                        {
                                            cango = true;
                                        }
                                        else
                                        {
                                            cango = false;
                                        }
                                    }



                                    else

                                    {

                                        cango = false;

                                    }

                                }

                                if ((begincolum == 4) && (beginrow == 7))

                                {

                                    if ((beginrow - endrow == 2) && (begincolum - endcolum == 2))

                                    {

                                        if (Chess[begincolum - 1, beginrow - 1].Getname() == "nochess")

                                        {

                                            cango = true;

                                        }
                                        else
                                        {
                                            cango = false;
                                        }

                                    }
                                    else if ((beginrow - endrow == 2) && (endcolum - begincolum == 2))
                                    {
                                        if (Chess[begincolum + 1, beginrow - 1].Getname() == "nochess")
                                        {
                                            cango = true;
                                        }
                                        else
                                        {
                                            cango = false;
                                        }
                                    }

                                    else

                                    {

                                        cango = false;

                                    }



                                }



                                if ((beginrow == 7) && (begincolum == 8))

                                {

                                    if ((begincolum - endcolum == 2) && (beginrow - endrow == 2))

                                    {

                                        if (Chess[begincolum - 1, beginrow - 1].Getname() == "nochess")

                                        {

                                            cango = true;

                                        }
                                        else
                                        {
                                            cango = false;
                                        }


                                    }

                                    else

                                    {

                                        cango = false;

                                    }



                                }





                            }









                            break;









                    }

                    break;

                //-------------------------------------------------------------------------------------------------------------------------------------------
                case "马":
                    switch (Chess[begincolum, beginrow].color)
                    {
                        case "red":
                            if (Math.Abs(begincolum - endcolum) == 2 && Math.Abs(beginrow - endrow) == 1)
                            {
                                if (Chess[endrow, beginrow].Getname() == "nochess")
                                { cango = true; }
                                else { cango = false; }
                            }

                            else if (Math.Abs(begincolum - endcolum) == 1 && Math.Abs(beginrow - endrow) == 2)
                            {
                                if (Chess[begincolum, (beginrow + endrow) / 2].Getname() == "nochess")
                                { cango = true; }
                                else { cango = false; }
                            }
                            else cango = false;
                            break;

                        case "black":
                            if (Math.Abs(begincolum - endcolum) == 2 && Math.Abs(beginrow - endrow) == 1)
                            {
                                if (Chess[endrow, beginrow].Getname() == "nochess")

                                { cango = true; }
                                else { cango = false; }

                            }
                            else if (Math.Abs(begincolum - endcolum) == 1 && Math.Abs(beginrow - endrow) == 2)
                            {
                                if (Chess[begincolum, (beginrow + endrow) / 2].Getname() == "nochess")
                                { cango = true; }
                                else { cango = false; }
                            }
                            else cango = false;
                            break;


                    }
                    break;
                //-------------------------------------------------------------------------------------------------------------------------------------------

                case "炮":
                    if ((beginrow == endrow) && (begincolum != endcolum))
                    {
                        if (endcolum < begincolum)//向左
                        {
                            if (Chess[endcolum, endrow].Getname().Equals("nochess"))
                            {
                                for (int j = begincolum - 1; j > endcolum; j--)
                                {
                                    if (!Chess[j, endrow].Getname().Equals("nochess"))
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
                            else if ((!Chess[endcolum, endrow].Getname().Equals("nochess")) && (!Chess[begincolum, beginrow].Getcolor().Equals(Chess[endcolum, endrow].Getcolor())))
                            {
                                //判断起点和目的地之间是否有棋子，且只有一个，才能吃目的地的棋子，否则吃不了
                                int account = 0;
                                for (int j = begincolum - 1; j > endcolum; j--)
                                {
                                    if (!Chess[j, endrow].Getname().Equals("nochess"))
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
                        else if (endcolum > begincolum)//向右
                        {
                            if (Chess[endcolum, endrow].Getname().Equals("nochess"))
                            {
                                for (int j = begincolum + 1; j < endcolum; j++)
                                {
                                    if (!Chess[j, endrow].Getname().Equals("nochess"))
                                    {
                                        cango = false;
                                        break;
                                    }
                                    else
                                        cango = true;
                                }
                            }
                            else if ((!Chess[endcolum, endrow].Getname().Equals("nochess")) && (!Chess[begincolum, beginrow].Getcolor().Equals(Chess[endcolum, endrow].Getcolor())))
                            {
                                int account = 0;
                                for (int j = begincolum + 1; j < endcolum; j++)
                                {
                                    if (!Chess[j, endrow].Getname().Equals("nochess"))
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
                    else if ((begincolum == endcolum) && (beginrow != endrow))
                    {
                        if (endrow < beginrow)//向上
                        {
                            if (Chess[endcolum, endrow].Getname().Equals("nochess"))
                            {
                                for (int i = beginrow - 1; i > endrow; i--)
                                {
                                    if (!Chess[endcolum, i].Getname().Equals("nochess"))
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
                            else if ((!Chess[endcolum, endrow].Getname().Equals("nochess")) && (!Chess[begincolum, beginrow].Getcolor().Equals(Chess[endcolum, endrow].Getcolor())))
                            {
                                //判断起点和目的地之间是否有棋子，且只有一个，才能吃目的地的棋子，否则吃不了
                                int account = 0;
                                for (int i = beginrow - 1; i > endrow; i--)
                                {
                                    if (!Chess[endcolum, i].Getname().Equals("nochess"))
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

                        else if (endrow > beginrow)//向下
                        {
                            if (Chess[endcolum, endrow].Getname().Equals("nochess"))
                            {
                                for (int i = beginrow + 1; i < endrow; i++)
                                {
                                    if (!Chess[endcolum, i].Getname().Equals("nochess"))
                                    {
                                        cango = false;
                                        break;
                                    }
                                    else
                                        cango = true;
                                }
                            }
                            else if ((!Chess[endcolum, endrow].Getname().Equals("nochess")) && (!Chess[begincolum, beginrow].Getcolor().Equals(Chess[endcolum, endrow].Getcolor())))
                            {
                                int account = 0;
                                for (int i = beginrow + 1; i < endrow; i++)
                                {
                                    if (!Chess[endcolum, i].Getname().Equals("nochess"))
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
                        cango = false;

                    break;
                //--------------------------------------------------------------------------
                case "将":
                    switch (Chess[begincolum, beginrow].color)
                    {
                        case "red":
                            if ((endrow >= 7 && endrow <= 9) && (endcolum >= 3 && endcolum <= 5))
                            {
                                if (Math.Pow(endrow - beginrow, 2) + Math.Pow(endcolum - begincolum, 2) == 1)
                                {
                                    if (Chess[endcolum, endrow].Getname().Equals("nochess"))
                                    {
                                        cango = true;
                                    }
                                    else if (!Chess[endcolum, endrow].Getname().Equals("nochess") && (!Chess[endcolum, endrow].Getcolor().Equals(Chess[endcolum, endrow].Getcolor())))
                                    {
                                        cango = true;
                                    }
                                    else
                                        cango = false;
                                }
                                else
                                    cango = false;

                            }
                            //飞将
                            else if (endcolum == blackgeneral.colum && endrow == blackgeneral.row)
                            {
                                int middlePiece = 0;
                                for (int i = beginrow - 1; i > endrow; i--)
                                {
                                    if (Chess[begincolum, i].Getname() != "nochess")
                                    {
                                        middlePiece = middlePiece + 1;
                                    }

                                }
                                if (middlePiece == 0)
                                {
                                    cango = true;
                                }
                                else
                                    cango = false;
                            }
                            else
                                cango = false;
                            break;

                        case "black":
                            if ((endrow >= 0 && endrow <= 2) && (endcolum >= 3 && endcolum <= 5))
                            {
                                if (Math.Pow(endrow - beginrow, 2) + Math.Pow(endcolum - begincolum, 2) == 1)
                                {
                                    if (Chess[endcolum, endrow].Getname().Equals("nochess"))
                                    {
                                        cango = true;
                                    }
                                    else if (!Chess[endcolum, endrow].Getname().Equals("nochess") && (!Chess[endcolum, endrow].Getcolor().Equals(Chess[endcolum, endrow].Getcolor())))
                                    {
                                        cango = true;
                                    }
                                    else
                                        cango = false;
                                }
                                else
                                    cango = false;

                            }
                            //飞将
                            else if (endcolum == redgeneral.colum && endrow == redgeneral.row)
                            {
                                int middlePiece = 0;
                                for (int i = beginrow + 1; i < endrow; i++)
                                {
                                    if (Chess[begincolum, i].Getname() != "nochess")
                                    {
                                        middlePiece = middlePiece + 1;
                                    }

                                }
                                if (middlePiece == 0)
                                {
                                    cango = true;
                                }
                                else
                                    cango = false;
                            }
                            else
                                cango = false;
                            break;
                    }

                    break;
                //--------------------------------------------------------------------------
                case "士":
                    switch (Chess[begincolum, beginrow].color)
                    {
                        case "red":
                            if ((endrow >= 7 && endrow <= 9) && (endcolum >= 3 && endcolum <= 5))
                            {
                                if (Math.Pow(endrow - beginrow, 2) + Math.Pow(endcolum - begincolum, 2) == 2)
                                {
                                    if (Chess[endcolum, endrow].Getname().Equals("nochess"))
                                    {
                                        cango = true;
                                    }
                                    else if (!Chess[endcolum, endrow].Getname().Equals("nochess") && (!Chess[endcolum, endrow].Getcolor().Equals(Chess[endcolum, endrow].Getcolor())))
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
                            break;

                        case "black":
                            if ((endrow >= 0 && endrow <= 2) && (endcolum >= 3 && endcolum <= 5))
                            {
                                if (Math.Pow(endrow - beginrow, 2) + Math.Pow(endcolum - begincolum, 2) == 2)
                                {
                                    if (Chess[endcolum, endrow].Getname().Equals("nochess"))
                                    {
                                        cango = true;
                                    }
                                    else if (!Chess[endcolum, endrow].Getname().Equals("nochess") && (!Chess[endcolum, endrow].Getcolor().Equals(Chess[endcolum, endrow].Getcolor())))
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
                            break;
                    }
                    break;

                case "车":
                    {
                        if (begincolum - endcolum == 0 && endrow - beginrow > 0)
                        {
                            for (int i = beginrow + 1; i < endrow; i++)
                            {
                                if (Chess[begincolum, i].Getname() != "nochess")
                                {
                                    cango = false;
                                    break;
                                }
                                else
                                {
                                    cango = true;

                                }

                            }

                        }
                        else if (beginrow - endrow == 0 && endcolum - begincolum > 0)
                        {
                            for (int j = begincolum + 1; j < endcolum; j++)
                            {
                                if (Chess[j, beginrow].Getname() != "nochess")
                                {
                                    cango = false;
                                    break;
                                }
                                else
                                {
                                    cango = true;

                                }
                            }
                        }
                        else if (begincolum - endcolum == 0 && endrow - beginrow < 0)
                        {
                            for (int i = beginrow - 1; i < endrow; i--)
                            {
                                if (Chess[begincolum, i].Getname() != "nochess")
                                {
                                    cango = false;
                                    break;
                                }
                                else
                                {
                                    cango = true;

                                }

                            }

                        }
                        else if (beginrow - endrow == 0 && endcolum - begincolum < 0)
                        {
                            for (int j = begincolum - 1; j < endcolum; j--)
                            {
                                if (Chess[j, beginrow].Getname() != "nochess")
                                {
                                    cango = false;
                                    break;
                                }
                                else
                                {
                                    cango = true;
                                }
                            }
                        }
                        else
                        {
                            cango = false;
                            break;
                        }




                    }

                    break;
            }
            return cango;

        }

        //通过找黑红的将生死看游戏有没有结束
        public bool GeneralAlive()
        {
            return blackgeneral.alive && redgeneral.alive;
        }

        public bool blackGeneralAlive()
        {
            return blackgeneral.alive ;
        }

        //这是查找将的生死，之后用排除法得是黑赢还是红赢
        public bool WhoWin()
        {
            return blackgeneral.alive;
        }

        //因为是把棋盘当成二维数组，所以我们把创建的棋子变量初始化到棋盘数组里
        public void InitializeBorad()
        {
            Chess[0,0] = blackRood1;

            Chess[1, 0] = blackHorse1;

            Chess[2, 0] = blackElephant1;

            Chess[3, 0] = blackguard1;

            Chess[4, 0] = blackgeneral;

            Chess[5, 0] = blackguard2;

            Chess[6, 0] = blackElephant2;

            Chess[7, 0] = blackHorse2;

            Chess[8, 0] = blackRood2;

            Chess[1, 2] = blackCannon1;

            Chess[7, 2] = blackCannon2;

            Chess[0, 3] = blacksoldier1;

            Chess[2, 3] = blacksoldier2;

            Chess[4, 3] = blacksoldier3;

            Chess[6, 3] = blacksoldier4;

            Chess[8, 3] = blacksoldier5;

            Chess[0, 9] = redRood1;

            Chess[1, 9] = redHorse1;

            Chess[2, 9] = redElephant1;

            Chess[3, 9] = redguard1;

            Chess[4, 9] = redgeneral;

            Chess[5, 9] = redguard2;

            Chess[6, 9] = redElephant2;

            Chess[7, 9] = redHorse2;

            Chess[8, 9] = redRood2;

            Chess[1, 7] = redCannon1;

            Chess[7, 7] = redCannon2;

            Chess[0, 6] = redsoldier1;

            Chess[2, 6] = redsoldier2;

            Chess[4, 6] = redsoldier3;

            Chess[6, 6] = redsoldier4;

            Chess[8, 6] = redsoldier5;

            for (int j = 0; j < 10; j++)
            {
                for (int i = 0; i < 9; i++)
                {
                    if (Chess[i, j] == null)
                    {
                        Chess[i, j] = new nochess(i, j);
                    }
                }
            }
        }
       
        public void Wherecanchessgo(int colum, int row)
        {
            switch (Chess[colum, row].Getname())
            {
                case "兵":
                    switch(Chess[colum, row].Getcolor())
                    {
                        case "red":
                            if (row >= 5)
                            {
                                if (Chess[colum, row - 1].Getcolor() != "red")
                                {
                                    Chess[colum, row - 1].changeCango();
                                }
                            }
                            else if (row<=4){
                                if (colum == 0)
                                {
                                    if(row == 0)
                                    {
                                        if (Chess[colum + 1, row ].Getcolor() != "red")
                                        {
                                            Chess[colum + 1, row].changeCango();
                                        }
                                    }
                                    else 
                                    {
                                        if (Chess[colum + 1, row].Getcolor() != "red")
                                        {
                                            Chess[colum + 1, row].changeCango();
                                        }
                                        if (Chess[colum , row - 1].Getcolor() != "red")
                                        {
                                            Chess[colum, row - 1].changeCango();
                                        }
                                    }
                                }
                                else if (row==0)
                                {
                                    if (colum == 0)
                                    {
                                        if (Chess[colum + 1, row].Getcolor() != "red")
                                        {
                                            Chess[colum + 1, row].changeCango();
                                        }
                                    }
                                    else if(colum == 8)
                                    {
                                        if (Chess[colum - 1, row].Getcolor() != "red")
                                        {
                                            Chess[colum - 1, row].changeCango();
                                        }
                                    }
                                    else
                                    {
                                        Chess[colum + 1, row].changeCango();
                                        Chess[colum - 1, row].changeCango();
                                    }
                                }
                                else if(colum == 8){
                                    if (row == 0)
                                    {
                                        if (Chess[colum - 1, row].Getcolor() != "red")
                                        {
                                            Chess[colum - 1, row].changeCango();
                                        }
                                    }
                                    else
                                    {
                                        if (Chess[colum - 1, row].Getcolor() != "red")
                                        {
                                            Chess[colum - 1, row].changeCango();
                                        }
                                        if (Chess[colum, row - 1].Getcolor() != "red")
                                        {
                                            Chess[colum, row - 1].changeCango();
                                        }
                                    }
                                }
                                else
                                {
                                    if(Chess[colum + 1,row].Getcolor() != "red")
                                    {
                                        Chess[colum + 1, row].changeCango();
                                    }
                                    if (Chess[colum - 1, row].Getcolor() != "red")
                                    {
                                        Chess[colum - 1, row].changeCango();
                                    }
                                    if (Chess[colum  , row-1].Getcolor() != "red")
                                    {
                                        Chess[colum , row-1].changeCango();
                                    }
                                }
                            }
                            break;

                        case "black":
                            if (row <= 4)
                            {
                                Chess[colum, row + 1].changeCango();
                            }
                            else if (row >= 5)
                            {
                                if (colum == 0)
                                {
                                    if (row == 9)
                                    {
                                        if (Chess[colum + 1, row].Getcolor() != "black")
                                        {
                                            Chess[colum + 1, row].changeCango();
                                        }
                                    }
                                    else
                                    {
                                        if (Chess[colum + 1, row].Getcolor() != "black")
                                        {
                                            Chess[colum + 1, row].changeCango();
                                        }
                                        if (Chess[colum , row+1].Getcolor() != "black")
                                        {
                                            Chess[colum , row+1].changeCango();
                                        }
                                    }
                                }
                                else if (row == 9)
                                {
                                    if (colum == 0)
                                    {
                                        Chess[colum + 1, row].changeCango();
                                    }
                                    else if (colum == 8)
                                    {
                                        Chess[colum - 1, row].changeCango();
                                    }
                                    else
                                    {
                                        Chess[colum + 1, row].changeCango();
                                        Chess[colum - 1, row].changeCango();
                                    }
                                }
                                else if (colum == 8)
                                {
                                    if (row == 0)
                                    {

                                        if (Chess[colum - 1, row].Getcolor() != "black")
                                        {
                                            Chess[colum - 1, row].changeCango();
                                        }
                                    }
                                    else
                                    {
                                        if (Chess[colum - 1, row].Getcolor() != "black")
                                        {
                                            Chess[colum - 1, row].changeCango();
                                        }
                                        if (Chess[colum, row + 1].Getcolor() != "black")
                                        {
                                            Chess[colum, row + 1].changeCango();
                                        }
                                    }
                                }
                                else
                                {
                                    if (Chess[colum + 1, row].Getcolor() != "black")
                                    {
                                        Chess[colum + 1, row].changeCango();
                                    }
                                    if (Chess[colum - 1, row].Getcolor() != "black")
                                    {
                                        Chess[colum - 1, row].changeCango();
                                    }
                                    if (Chess[colum, row + 1].Getcolor() != "black")
                                    {
                                        Chess[colum, row + 1].changeCango();
                                    }
                                }
                            }
                            break;
                    }
                    break;
                //--------------------------------------------------------------------------------------------
                case "炮":

                    for (int i = row - 1; i >= 0; i--)
                    {
                        //如果起始点的下一个位置没有棋子，则显示可走
                        if (Chess[colum, i].Getname().Equals("nochess"))
                        {
                            Chess[colum, i].changeCango();
                        }
                        //如果下一个位置有棋子X
                        else
                        {
                            //那么，从这个棋子X开始，往棋子X之后继续遍历
                            for (int i1 = i - 1; i1 >= 0; i1--)
                            {
                                //如果棋子X之后一个位置有棋子，且为对方的棋子，则显示可走，然后到此为止，即退出当前循环，也要退出最外层的循环
                                if ((!Chess[colum, i1].Getname().Equals("nochess")) && (!Chess[colum, i1].Getcolor().Equals(Chess[colum, row].Getcolor())))
                                {
                                    Chess[colum, i1].changeCango();
                                    i = -1;
                                    break;

                                }
                                //如果棋子X之后一个位置有棋子，但是是我方棋子，此时，也到此位置，退出当前循环和最外层循环
                                else if ((!Chess[colum, i1].Getname().Equals("nochess")) && (Chess[colum, i1].Getcolor().Equals(Chess[colum, row].Getcolor())))
                                {
                                    i = -1;
                                    break;
                                }
                                //如果棋子X之后一个位置没棋子，此时，也到此位置，退出当前循环和最外层循环
                                else if (Chess[colum, i1].Getname().Equals("nochess"))
                                {
                                    i = -1;
                                    
                                }
                                //如果棋子X之后一个位置没有棋子，则继续进行此循环，看看棋子X之后的一个位置是否有棋子。。。。。。
                            }
                        }
                    }
                    for (int i = row + 1; i <= 9; i++)
                    {
                        if (Chess[colum, i].Getname().Equals("nochess"))
                        {
                            Chess[colum, i].changeCango();
                        }
                        else
                        {
                            for (int i1 = i + 1; i1 <= 9; i1++)
                            {
                                if ((!Chess[colum, i1].Getname().Equals("nochess")) && (!Chess[colum, i1].Getcolor().Equals(Chess[colum, row].Getcolor())))
                                {
                                    Chess[colum, i1].changeCango();

                                    i = 10;
                                    break;
                                }
                                else if ((!Chess[colum, i1].Getname().Equals("nochess")) && (Chess[colum, i1].Getcolor().Equals(Chess[colum, row].Getcolor())))
                                {
                                    i = 10;
                                    break;
                                }
                                else if (Chess[colum, i1].Getname().Equals("nochess"))
                                {
                                    i = 10;
                                    
                                }
                            }
                        }
                    }
                    for (int j = colum - 1; j >= 0; j--)
                    {
                        if (Chess[j, row].Getname().Equals("nochess"))
                        {
                            Chess[j, row].changeCango();
                        }
                        else
                        {
                            for (int j1 = j - 1; j1 >= 0; j1--)
                            {
                                if ((!Chess[j1, row].Getname().Equals("nochess")) && (!Chess[j1, row].Getcolor().Equals(Chess[colum, row].Getcolor())))
                                {
                                    Chess[j1, row].changeCango();
                                    j = -1;
                                    break;
                                }
                                else if ((!Chess[j1, row].Getname().Equals("nochess")) && (Chess[j1, row].Getcolor().Equals(Chess[colum, row].Getcolor())))
                                {
                                    j = -1;
                                    break;
                                }else if(Chess[j1, row].Getname().Equals("nochess"))
                                {
                                    j = -1;
                                    
                                }
                            }
                        }
                    }
                    for (int j = colum + 1; j <= 8; j++)
                    {
                        if (Chess[j, row].Getname().Equals("nochess"))
                        {
                            Chess[j, row].changeCango();
                        }
                        else
                        {
                            for (int j1 = j + 1; j1 <= 8; j1++)
                            {
                                if ((!Chess[j1, row].Getname().Equals("nochess")) && (!Chess[j1, row].Getcolor().Equals(Chess[colum, row].Getcolor())))
                                {
                                    Chess[j1, row].changeCango();
                                    j = 9;
                                    break;
                                }
                                else if ((!Chess[j1, row].Getname().Equals("nochess")) && (Chess[j1, row].Getcolor().Equals(Chess[colum, row].Getcolor())))
                                {
                                    j = 9;
                                    break;
                                }
                                else if (Chess[j1, row].Getname().Equals("nochess"))
                                {
                                    j = 9;
                                    
                                }
                            }
                        }
                    }
                    break;
                //-------------------------------------------------------------------------------------------------------------------------------------------
                case "象":
                    switch (Chess[colum, row].Getcolor())
                    {
                        case "black":
                            if (row <= 4)
                            {
                                if (row == 0)
                                {
                                    if (Chess[colum - 1, row + 1].Getname() == "nochess")
                                    {
                                       if(Chess[colum - 2, row + 2].Getname() == "nochess")
                                        {
                                            Chess[colum - 2, row + 2].changeCango();
                                            
                                        }else if(Chess[colum - 2, row + 2].Getname() != "nochess" && Chess[colum - 2, row + 2].Getcolor().Equals("red"))
                                        {
                                            Chess[colum - 2, row + 2].changeCango();
                                        }
                                        
                                        
                                        
                                    }
                                    if(Chess[colum + 1, row + 1].Getname() == "nochess")
                                    {
                                        if (Chess[colum + 2, row + 2].Getname() == "nochess")
                                        {
                                            Chess[colum + 2, row + 2].changeCango();

                                        }
                                        else if (Chess[colum + 2, row + 2].Getname() != "nochess" && Chess[colum + 2, row + 2].Getcolor().Equals("red"))
                                        {
                                            Chess[colum + 2, row + 2].changeCango();
                                        }

                                    }
                                    

                                }
                                if ((row == 2) && (colum == 0) && (Chess[colum + 1, row + 1].Getname() == "nochess"))
                                {
                                    if(Chess[colum + 2, row + 2].Getname() == "nochess")
                                    {
                                        Chess[colum + 2, row + 2].changeCango();
                                    }
                                    else if(Chess[colum + 2, row + 2].Getname() != "nochess" && Chess[colum + 2, row + 2].Getcolor().Equals("red"))
                                    {
                                        Chess[colum + 2, row + 2].changeCango();
                                    }
                                    

                                }
                                if ((row == 2) && (colum == 4))
                                {
                                    if(Chess[colum - 1, row + 1].Getname() == "nochess")
                                    {
                                        if(Chess[colum - 2, row + 2].Getname() == "nochess")
                                        {
                                            Chess[colum - 2, row + 2].changeCango();
                                        }else if(Chess[colum - 2, row + 2].Getname() != "nochess" && Chess[colum - 2, row + 2].Getcolor().Equals("red"))
                                        {
                                            Chess[colum - 2, row + 2].changeCango();
                                        }
                                    }
                                    
                                    if((Chess[colum + 1, row + 1].Getname() == "nochess"))
                                    {
                                        if (Chess[colum + 2, row + 2].Getname() == "nochess")
                                        {
                                            Chess[colum + 2, row + 2].changeCango();
                                        }
                                        else if (Chess[colum + 2, row + 2].Getname() != "nochess" && Chess[colum + 2, row + 2].Getcolor().Equals("red"))
                                        {
                                            Chess[colum + 2, row + 2].changeCango();
                                        }
                                    }
                                }
                                if ((row == 2) && (colum == 8) && Chess[colum - 1, row + 1].Getname() == "nochess")
                                {
                                    if (Chess[colum - 2, row + 2].Getname() == "nochess")
                                    {
                                        Chess[colum - 2, row + 2].changeCango();
                                    }
                                    else if (Chess[colum - 2, row + 2].Getname() != "nochess" && Chess[colum - 2, row + 2].Getcolor().Equals("red"))
                                    {
                                        Chess[colum - 2, row + 2].changeCango();
                                    }
                                }



                            }
                           








                            break;

                        case "red":
                            if (row >= 5)
                            {

                                if (row == 9)
                                {
                                    if (Chess[colum - 1, row - 1].Getname() == "nochess")
                                    {
                                        if (Chess[colum - 2, row - 2].Getname() == "nochess")
                                        {
                                            Chess[colum - 2, row - 2].changeCango();

                                        }
                                        else if (Chess[colum - 2, row - 2].Getname() != "nochess" && Chess[colum - 2, row - 2].Getcolor().Equals("black"))
                                        {
                                            Chess[colum - 2, row - 2].changeCango();
                                        }



                                    }
                                    if (Chess[colum + 1, row - 1].Getname() == "nochess")
                                    {
                                        if (Chess[colum + 2, row - 2].Getname() == "nochess")
                                        {
                                            Chess[colum + 2, row - 2].changeCango();

                                        }
                                        else if (Chess[colum + 2, row - 2].Getname() != "nochess" && Chess[colum + 2, row - 2].Getcolor().Equals("black"))
                                        {
                                            Chess[colum + 2, row - 2].changeCango();
                                        }

                                    }
                                }

                                if ((row == 7) && (colum == 0) && (Chess[colum + 1, row - 1].Getname() == "nochess"))
                                {
                                    if (Chess[colum + 2, row - 2].Getname() == "nochess")
                                    {
                                        Chess[colum + 2, row - 2].changeCango();
                                    }
                                    else if (Chess[colum + 2, row - 2].Getname() != "nochess" && Chess[colum + 2, row - 2].Getcolor().Equals("black"))
                                    {
                                        Chess[colum + 2, row - 2].changeCango();
                                    }


                                }
                                if ((row == 7) && (colum == 4))
                                {
                                    if (Chess[colum - 1, row - 1].Getname() == "nochess")
                                    {
                                        if (Chess[colum - 2, row - 2].Getname() == "nochess")
                                        {
                                            Chess[colum - 2, row - 2].changeCango();
                                        }
                                        else if (Chess[colum - 2, row - 2].Getname() != "nochess" && Chess[colum - 2, row - 2].Getcolor().Equals("black"))
                                        {
                                            Chess[colum - 2, row - 2].changeCango();
                                        }
                                    }

                                    if ((Chess[colum + 1, row - 1].Getname() == "nochess"))
                                    {
                                        if (Chess[colum + 2, row - 2].Getname() == "nochess")
                                        {
                                            Chess[colum + 2, row - 2].changeCango();
                                        }
                                        else if (Chess[colum + 2, row - 2].Getname() != "nochess" && Chess[colum + 2, row - 2].Getcolor().Equals("black"))
                                        {
                                            Chess[colum + 2, row - 2].changeCango();
                                        }
                                    }
                                }
                                if ((row == 7) && (colum == 8) && Chess[colum - 1, row - 1].Getname() == "nochess")
                                {
                                    if (Chess[colum - 2, row - 2].Getname() == "nochess")
                                    {
                                        Chess[colum - 2, row - 2].changeCango();
                                    }
                                    else if (Chess[colum - 2, row - 2].Getname() != "nochess" && Chess[colum - 2, row - 2].Getcolor().Equals("black"))
                                    {
                                        Chess[colum - 2, row - 2].changeCango();
                                    }
                                }



                            }





                            break;





                    }

                    break;

                //-------------------------------------------------------------------------------------------------------------------------------------------
                case "车": //（0，0）==》（0，1）
                    for (int i = row - 1; i >= 0; i--)
                    {
                        if (Chess[colum, i].Getname().Equals("nochess"))
                        {
                            Chess[colum, i].changeCango();
                        }
                        else if (Chess[colum, i].Getcolor().Equals(Chess[colum, row].Getcolor()))
                        {
                            break;
                        }
                        else if ((!Chess[colum, i].Getname().Equals("nochess")) && (!Chess[colum, i].Getcolor().Equals(Chess[colum, row].Getcolor())))
                        {
                            Chess[colum, i].changeCango();
                            break;
                        }


                    }


                    for (int i = row + 1; i <= 9; i++)
                    {
                        if (Chess[colum, i].Getname().Equals("nochess"))
                        {
                            Chess[colum, i].changeCango();
                        }
                        else if (Chess[colum, i].Getcolor().Equals(Chess[colum, row].Getcolor()))
                        {
                            break;
                        }
                        else if ((!Chess[colum, i].Getname().Equals("nochess")) && (!Chess[colum, i].Getcolor().Equals(Chess[colum, row].Getcolor())))
                        {
                            Chess[colum, i].changeCango();
                            break;
                        }

                    }

                    for (int j = colum - 1; j >= 0; j--)
                    {
                        if (Chess[j, row].Getname().Equals("nochess"))
                        {
                            Chess[j, row].changeCango();
                        }
                        else if ((Chess[j, row].Getcolor().Equals(Chess[colum, row].Getcolor())))
                        {
                            break;
                        }
                        else if ((!Chess[j, row].Getname().Equals("nochess")) && (!Chess[j, row].Getcolor().Equals(Chess[colum, row].Getcolor())))
                        {
                            Chess[j, row].changeCango();

                            break;

                        }
                    }


                    for (int j = colum + 1; j <= 8; j++)
                    {
                        if (Chess[j, row].Getname().Equals("nochess"))
                        {
                            Chess[j, row].changeCango();
                        }
                        else if ((Chess[j, row].Getcolor().Equals(Chess[colum, row].Getcolor())))
                        {
                            break;
                        }
                        else if ((!Chess[j, row].Getname().Equals("nochess")) && (!Chess[j, row].Getcolor().Equals(Chess[colum, row].Getcolor())))
                        {
                            Chess[j, row].changeCango();
                            break;
                        }

                    }
                    break;
                //-------------------------------------------------------------------------------------------------------------------------------------------
                case "将":
                    switch(Chess[colum, row].Getcolor())
                    {
                        case "red":
                            if (row - 1 >= 7)
                            {
                                if (Chess[colum, row - 1].Getname() == "nochess" || Chess[colum, row - 1].Getcolor() != Chess[colum, row].Getcolor())
                                {
                                    Chess[colum, row - 1].changeCango();
                                }
                            }
                            if (row + 1 <= 9)
                            {
                                if (Chess[colum, row + 1].Getname() == "nochess" || Chess[colum, row + 1].Getcolor() != Chess[colum, row].Getcolor())
                                {
                                    Chess[colum, row + 1].changeCango();
                                }
                            }
                            if (colum - 1 >= 3)
                            {
                                if (Chess[colum - 1, row].Getname() == "nochess" || Chess[colum - 1, row].Getcolor() != Chess[colum, row].Getcolor())
                                {
                                    Chess[colum - 1, row].changeCango();
                                }
                            }
                            if (colum + 1 <= 5)
                            {
                                if (Chess[colum + 1, row].Getname() == "nochess" || Chess[colum + 1, row].Getcolor() != Chess[colum, row].Getcolor())
                                {
                                    Chess[colum + 1, row].changeCango();
                                }
                            }
                            //飞将
                            if(colum == blackgeneral.colum)
                            {
                                int middlePiece = 0;
                                for(int i = row - 1;i > blackgeneral.row; i--)
                                {
                                    if (Chess[colum,i].Getname() != "nochess")
                                    {
                                        middlePiece = middlePiece + 1;
                                    }
                                    
                                }
                                if(middlePiece == 0)
                                {
                                    Chess[blackgeneral.colum, blackgeneral.row].changeCango();
                                }
                            }
                            break;

                        case "black":
                            if (row - 1 >= 0)
                            {
                                if (Chess[colum, row - 1].Getname() == "nochess" || Chess[colum, row - 1].Getcolor() != Chess[colum, row].Getcolor())
                                {
                                    Chess[colum, row - 1].changeCango();
                                }
                            }
                            if (row + 1 <= 2)
                            {
                                if (Chess[colum, row + 1].Getname() == "nochess" || Chess[colum, row + 1].Getcolor() != Chess[colum, row].Getcolor())
                                {
                                    Chess[colum, row + 1].changeCango();
                                }
                            }
                            if (colum - 1 >= 3)
                            {
                                if (Chess[colum - 1, row].Getname() == "nochess" || Chess[colum - 1, row].Getcolor() != Chess[colum, row].Getcolor())
                                {
                                    Chess[colum - 1, row].changeCango();
                                }
                            }
                            if (colum + 1 <= 5)
                            {
                                if (Chess[colum + 1, row].Getname() == "nochess" || Chess[colum + 1, row].Getcolor() != Chess[colum, row].Getcolor())
                                {
                                    Chess[colum + 1, row].changeCango();
                                }
                            }
                            //飞将
                            if (colum == redgeneral.colum)
                            {
                                int middlePiece = 0;
                                for (int i = row + 1; i < redgeneral.row; i++)
                                {
                                    if (Chess[colum, i].Getname() != "nochess")
                                    {
                                        middlePiece = middlePiece + 1;
                                    }

                                }
                                if (middlePiece == 0)
                                {
                                    Chess[redgeneral.colum, redgeneral.row].changeCango();
                                }
                            }
                            break;
                     }
                    break;
             //----------------------------------------------------------------------------------------------------------------------------------------------
                case "士":
                    switch (Chess[colum, row].Getcolor())
                    {
                        case "red":
                            if(row - 1 >= 7 && colum + 1 <= 5)
                            {
                                if(Chess[colum + 1, row - 1].Getname().Equals("nochess"))
                                {
                                    Chess[colum + 1, row - 1].changeCango();
                                }else if(!(Chess[colum + 1, row - 1].Getname().Equals("nochess") || Chess[colum + 1, row - 1].Getcolor().Equals(Chess[colum, row].Getcolor())))
                                {
                                    Chess[colum + 1, row - 1].changeCango();
                                }
                            }

                            if (row - 1 >= 7 && colum - 1 >= 3)
                            {
                                if (Chess[colum - 1, row - 1].Getname().Equals("nochess"))
                                {
                                    Chess[colum - 1, row - 1].changeCango();
                                }
                                else if (!(Chess[colum - 1, row - 1].Getname().Equals("nochess") || Chess[colum - 1, row - 1].Getcolor().Equals(Chess[colum, row].Getcolor())))
                                {
                                    Chess[colum - 1, row - 1].changeCango();
                                }
                            }

                            if (row + 1 <= 9 && colum - 1 >= 3)
                            {
                                if (Chess[colum - 1, row + 1].Getname().Equals("nochess"))
                                {
                                    Chess[colum - 1, row + 1].changeCango();
                                }
                                else if (!(Chess[colum - 1, row + 1].Getname().Equals("nochess") || Chess[colum - 1, row + 1].Getcolor().Equals(Chess[colum, row].Getcolor())))
                                {
                                    Chess[colum - 1, row + 1].changeCango();
                                }
                            }

                            if (row + 1 <= 9 && colum + 1 <= 5)
                            {
                                if (Chess[colum + 1, row + 1].Getname().Equals("nochess"))
                                {
                                    Chess[colum + 1, row + 1].changeCango();
                                }
                                else if (!(Chess[colum + 1, row + 1].Getname().Equals("nochess") || Chess[colum + 1, row + 1].Getcolor().Equals(Chess[colum, row].Getcolor())))
                                {
                                    Chess[colum + 1, row + 1].changeCango();
                                }
                            }

                            break;
                        case "black":
                            if (row - 1 >= 0 && colum + 1 <= 5)
                            {
                                if (Chess[colum + 1, row - 1].Getname().Equals("nochess"))
                                {
                                    Chess[colum + 1, row - 1].changeCango();
                                }
                                else if (!(Chess[colum + 1, row - 1].Getname().Equals("nochess") || Chess[colum + 1, row - 1].Getcolor().Equals(Chess[colum, row].Getcolor())))
                                {
                                    Chess[colum + 1, row - 1].changeCango();
                                }
                            }

                            if (row - 1 >= 0 && colum - 1 >= 3)
                            {
                                if (Chess[colum - 1, row - 1].Getname().Equals("nochess"))
                                {
                                    Chess[colum - 1, row - 1].changeCango();
                                }
                                else if (!(Chess[colum - 1, row - 1].Getname().Equals("nochess") || Chess[colum - 1, row - 1].Getcolor().Equals(Chess[colum, row].Getcolor())))
                                {
                                    Chess[colum - 1, row - 1].changeCango();
                                }
                            }

                            if (row + 1 <= 2 && colum - 1 >= 3)
                            {
                                if (Chess[colum - 1, row + 1].Getname().Equals("nochess"))
                                {
                                    Chess[colum - 1, row + 1].changeCango();
                                }
                                else if (!(Chess[colum - 1, row + 1].Getname().Equals("nochess") || Chess[colum - 1, row + 1].Getcolor().Equals(Chess[colum, row].Getcolor())))
                                {
                                    Chess[colum - 1, row + 1].changeCango();
                                }
                            }

                            if (row + 1 <= 2 && colum + 1 <= 5)
                            {
                                if (Chess[colum + 1, row + 1].Getname().Equals("nochess"))
                                {
                                    Chess[colum + 1, row + 1].changeCango();
                                }
                                else if (!(Chess[colum + 1, row + 1].Getname().Equals("nochess") || Chess[colum + 1, row + 1].Getcolor().Equals(Chess[colum, row].Getcolor())))
                                {
                                    Chess[colum + 1, row + 1].changeCango();
                                }
                            }
                            break;
                    }
                break;

            }
        }
    }
}
