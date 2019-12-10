using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    public abstract class Chess
    {
        public string theNameOfChess;
        public string color;
        public int xCoordinate;
        public int yCoordinate;

        public Chess(string color, string theNameOfChess, int xCoordinate, int yCoordinate)
        {
            this.color = color;
            if (this.color == "red")
            {
                this.theNameOfChess = theNameOfChess + "r";
            }
            else if(this.color == "black")
                this.theNameOfChess = theNameOfChess + "b";

            this.xCoordinate = xCoordinate;
            this.yCoordinate = yCoordinate;
        }
        public string GettheNameOfChess()
        {
            return this.theNameOfChess;
        }

        public string GetColor()
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
        

    }

    public class Cannon : Chess
    {
        public Cannon(string color, int xCoordinate, int yCoordinate)
            : base(color, "C", xCoordinate, yCoordinate)
        { }
        
    }

    public class Rook : Chess
    {
        public Rook(string color, int xCoordinate, int yCoordinate)
            : base(color, "R", xCoordinate, yCoordinate)
        { }
        
    }

    public class Horse : Chess
    {
        public Horse(string color, int xCoordinate, int yCoordinate)
            : base(color, "H", xCoordinate, yCoordinate)
        { }
        
    }

    public class Elephant : Chess
    {
        public Elephant(string color, int xCoordinate, int yCoordinate)
            : base(color, "E", xCoordinate, yCoordinate)
        { }
        
    }

    public class Guard : Chess
    {
        public Guard(string color, int xCoordinate, int yCoordinate)
            : base(color, "G", xCoordinate, yCoordinate)
        { }
        
    }

    public class King : Chess
    {
        public King(string color, int xCoordinate, int yCoordinate)
            : base(color, "K", xCoordinate, yCoordinate)
        { }
        
    }

    public class Soldier : Chess
    {
        public Soldier(string color, int xCoordinate, int yCoordinate)
            : base(color, "S", xCoordinate, yCoordinate)
        { }


    }
}
