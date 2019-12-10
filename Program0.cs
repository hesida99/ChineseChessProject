using System;

namespace Xiangqi
{
    public abstract class Piece
    {
        public string theNameOfPiece;
        public bool color;
        public int xCoordinate;
        public int yCoordinate;

        public Piece(bool color, string theNameOfPiece, int xCoordinate, int yCoordinate)
        {
            this.color = color;
            if(this.color == true)
            {
                this.theNameOfPiece = theNameOfPiece + "r";
            }else
                this.theNameOfPiece = theNameOfPiece + "b";

            this.xCoordinate = xCoordinate;
            this.yCoordinate = yCoordinate;
        }
        public string GettheNameOfPiece()
        {
            return this.theNameOfPiece;
        }

        public bool GetColor()
        {
            return this.color;
        }

        public int GetxCoordinate()
        {
            return this.xCoordinate;
        }

        public int GetyCoordinate()
        {
            return this.yCoordinate;
        }

        public void SetxCoordinate(int newXcoordinate)
        {
            this.xCoordinate = newXcoordinate;
        }
        public void SetyCoordinate(int newYcoordinate)
        {
            this.yCoordinate = newYcoordinate;
        }
        public abstract void Move(Board board);
        
    }

    public class Canon : Piece
    {
        public Canon(bool color, int xCoordinate, int yCoordinate)
            : base(color, "C", xCoordinate, yCoordinate)
        {}
        public override void Move(Board board)
        {
            
        }
    }

    public class Rook : Piece
    {
        public Rook(bool color, int xCoordinate, int yCoordinate)
            : base(color, "R", xCoordinate, yCoordinate)
        { }
        public override void Move(Board board)
        {

        }
    }

    public class Horse : Piece
    {
        public Horse(bool color, int xCoordinate, int yCoordinate)
            : base(color, "H", xCoordinate, yCoordinate)
        { }
        public override void Move(Board board)
        {

        }
    }

    public class Elephant : Piece
    {
        public Elephant(bool color, int xCoordinate, int yCoordinate)
            : base(color, "E", xCoordinate, yCoordinate)
        { }
        public override void Move(Board board)
        {

        }
    }

    public class Guard : Piece
    {
        public Guard(bool color, int xCoordinate, int yCoordinate)
            : base(color, "G", xCoordinate, yCoordinate)
        { }
        public override void Move(Board board)
        {

        }
    }

    public class King : Piece
    {
        public King(bool color, int xCoordinate, int yCoordinate)
            : base(color, "K", xCoordinate, yCoordinate)
        { }
        public override void Move(Board board)
        {

        }
    }

    public class Soldier : Piece
    {
        public Soldier(bool color, int xCoordinate, int yCoordinate)
            : base(color, "S", xCoordinate, yCoordinate)
        { }
        public override void Move(Board board)
        {

        }
    }


    public class Board //the Board class
    {
        private string[,] board = new string[10,9];  //creat the 9×10 matrix, we represent it by 2-dimension array.
        private string value;

        public Board()
        {
            board[0, 0] = "┌ ";
            board[0, 8] = "┐ ";
            board[9, 0] = "└ ";
            board[9, 8] = "┘ ";
            board[1, 4] = "×";
            board[8, 4] = "×";
            for (int j = 1; j < 8; j++)
            {
                board[0, j] = "┬ ";
                board[4, j] = "┴ ";
                board[5, j] = "┬ ";
                board[9, j] = "┴ ";
            }
            for(int i = 1; i < 9; i++)
            {
                board[i, 0] = "├ ";
                board[i, 8] = "┤";
            }
            for(int i = 0; i < 10; i++)
            {
                for(int j = 0; j < 9; j++)
                {
                    if(board[i,j] == null)
                    {
                        board[i, j] = "＋";
                    }
                }
            }
            
        }

        public void printBoard()
        {
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 9; j++)
                {

                    Console.Write(board[i, j]);
                }
                Console.WriteLine("");
            }
            
        }
        public string getValue(int xCoordinate, int yCoordinate)
        {
            this.value = board[xCoordinate, yCoordinate];
            return this.value;
        }
        public void placeThePieces(string theNameOfPiece, int xCoordinate, int yCoordinate)
        {
            board[xCoordinate, yCoordinate] = theNameOfPiece;
        }

    }

    


    class Program0
    {
        static void Main(string[] args)
        {
            //创建棋盘和摆放棋子
            const bool red = true;//player red side
            const bool black = false;//player black side
            bool turn = red;

            

            Soldier Sr1 = new Soldier(red, 6, 0); Soldier Sr2 = new Soldier(red, 6, 2);
            Soldier Sr3 = new Soldier(red, 6, 4); Soldier Sr4 = new Soldier(red, 6, 6);
            Soldier Sr5 = new Soldier(red, 6, 8);
            Canon Cr1 = new Canon(red, 7, 1); Canon Cr2 = new Canon(red, 7, 7);
            Rook Rr1 = new Rook(red, 9, 0); Rook Rr2 = new Rook(red, 9, 8);
            Horse Hr1 = new Horse(red, 9, 1); Horse Hr2 = new Horse(red, 9, 7);
            Elephant Er1 = new Elephant(red, 9, 2); Elephant Er2 = new Elephant(red, 9, 6);
            Guard Gr1 = new Guard(red, 9, 3); Guard Gr2 = new Guard(red, 9, 5);
            King Kr = new King(red, 9, 4);

            Soldier Sb1 = new Soldier(black, 3, 0); Soldier Sb2 = new Soldier(black, 3, 2);
            Soldier Sb3 = new Soldier(black, 3, 4); Soldier Sb4 = new Soldier(black, 3, 6);
            Soldier Sb5 = new Soldier(black, 3, 8);
            Canon Cb1 = new Canon(black, 2, 1); Canon Cb2 = new Canon(black, 2, 7);
            Rook Rb1 = new Rook(black, 0, 0); Rook Rb2 = new Rook(black, 0, 8);
            Horse Hb1 = new Horse(black, 0, 1); Horse Hb2 = new Horse(black, 0, 7);
            Elephant Eb1 = new Elephant(black, 0, 2); Elephant Eb2 = new Elephant(black, 0, 6);
            Guard Gb1 = new Guard(black, 0, 3); Guard Gb2 = new Guard(black, 0, 5);
            King Kb = new King(black, 0, 4);

            Board B = new Board();

            B.placeThePieces(Sr1.GettheNameOfPiece(), Sr1.GetxCoordinate(), Sr1.GetyCoordinate());
            B.placeThePieces(Sr2.GettheNameOfPiece(), Sr2.GetxCoordinate(), Sr2.GetyCoordinate());
            B.placeThePieces(Sr3.GettheNameOfPiece(), Sr3.GetxCoordinate(), Sr3.GetyCoordinate());
            B.placeThePieces(Sr4.GettheNameOfPiece(), Sr4.GetxCoordinate(), Sr4.GetyCoordinate());
            B.placeThePieces(Sr5.GettheNameOfPiece(), Sr5.GetxCoordinate(), Sr5.GetyCoordinate());
            B.placeThePieces(Cr1.GettheNameOfPiece(), Cr1.GetxCoordinate(), Cr1.GetyCoordinate());
            B.placeThePieces(Cr2.GettheNameOfPiece(), Cr2.GetxCoordinate(), Cr2.GetyCoordinate());
            B.placeThePieces(Rr1.GettheNameOfPiece(), Rr1.GetxCoordinate(), Rr1.GetyCoordinate());
            B.placeThePieces(Rr2.GettheNameOfPiece(), Rr2.GetxCoordinate(), Rr2.GetyCoordinate());
            B.placeThePieces(Hr1.GettheNameOfPiece(), Hr1.GetxCoordinate(), Hr1.GetyCoordinate());
            B.placeThePieces(Hr2.GettheNameOfPiece(), Hr2.GetxCoordinate(), Hr2.GetyCoordinate());
            B.placeThePieces(Er1.GettheNameOfPiece(), Er1.GetxCoordinate(), Er1.GetyCoordinate());
            B.placeThePieces(Er2.GettheNameOfPiece(), Er2.GetxCoordinate(), Er2.GetyCoordinate());
            B.placeThePieces(Gr1.GettheNameOfPiece(), Gr1.GetxCoordinate(), Gr1.GetyCoordinate());
            B.placeThePieces(Gr2.GettheNameOfPiece(), Gr2.GetxCoordinate(), Gr2.GetyCoordinate());
            B.placeThePieces(Kr.GettheNameOfPiece(), Kr.GetxCoordinate(), Kr.GetyCoordinate());
            B.placeThePieces(Sb1.GettheNameOfPiece(), Sb1.GetxCoordinate(), Sb1.GetyCoordinate());
            B.placeThePieces(Sb2.GettheNameOfPiece(), Sb2.GetxCoordinate(), Sb2.GetyCoordinate());
            B.placeThePieces(Sb3.GettheNameOfPiece(), Sb3.GetxCoordinate(), Sb3.GetyCoordinate());
            B.placeThePieces(Sb4.GettheNameOfPiece(), Sb4.GetxCoordinate(), Sb4.GetyCoordinate());
            B.placeThePieces(Sb5.GettheNameOfPiece(), Sb5.GetxCoordinate(), Sb5.GetyCoordinate());
            B.placeThePieces(Cb1.GettheNameOfPiece(), Cb1.GetxCoordinate(), Cb1.GetyCoordinate());
            B.placeThePieces(Cb2.GettheNameOfPiece(), Cb2.GetxCoordinate(), Cb2.GetyCoordinate());
            B.placeThePieces(Rb1.GettheNameOfPiece(), Rb1.GetxCoordinate(), Rb1.GetyCoordinate());
            B.placeThePieces(Rb2.GettheNameOfPiece(), Rb2.GetxCoordinate(), Rb2.GetyCoordinate());
            B.placeThePieces(Hb1.GettheNameOfPiece(), Hb1.GetxCoordinate(), Hb1.GetyCoordinate());
            B.placeThePieces(Hb2.GettheNameOfPiece(), Hb2.GetxCoordinate(), Hb2.GetyCoordinate());
            B.placeThePieces(Eb1.GettheNameOfPiece(), Eb1.GetxCoordinate(), Eb1.GetyCoordinate());
            B.placeThePieces(Eb2.GettheNameOfPiece(), Eb2.GetxCoordinate(), Eb2.GetyCoordinate());
            B.placeThePieces(Gb1.GettheNameOfPiece(), Gb1.GetxCoordinate(), Gb1.GetyCoordinate());
            B.placeThePieces(Gb2.GettheNameOfPiece(), Gb2.GetxCoordinate(), Gb2.GetyCoordinate());
            B.placeThePieces(Kb.GettheNameOfPiece(), Kb.GetxCoordinate(), Kb.GetyCoordinate());

            B.printBoard();
            
            //-------------------------------------------------------------------------------------------
            Console.WriteLine("\n-----------------------------------\n");
            if(turn == red)
            {
                Console.WriteLine("It's RED side turn!\n");
                
                //输入所选位置
                int x0; int y0;
                Console.WriteLine("Please choose a Piece you want to move\n");

                Console.Write("x:");
                string X0 = Console.ReadLine();
                x0 = Convert.ToInt32(X0);

                Console.Write("y:");
                string Y0 = Console.ReadLine();
                y0 = Convert.ToInt32(Y0);

                //得到所选位置的名称
                B.getValue(x0, y0);
                
                //判断所选是否为我方棋子
                if(!B.getValue(x0, y0).Contains("r"))
                {
                    Console.WriteLine("you must choose a RED piece!");
                     
                }
                //输入要移动到的位置
            }
            
            else if(turn == black)
            {
                Console.WriteLine("It's BLACK side turn!\n");
            }
            //turn = !turn;
           
            
            


        }
    }
    
}
