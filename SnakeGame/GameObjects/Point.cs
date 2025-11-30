using System;

namespace GameObjects
{
    public class Point
    {
        public int LeftX { get; set; }
        public int TopY { get; set; }

        public Point(int leftX, int topY)
        {
            LeftX = leftX;
            TopY = topY;
        }

        
        public virtual void Draw(char symbol)
        {
            try
            {
                Console.SetCursorPosition(LeftX, TopY);
                Console.Write(symbol);
            }
            catch (ArgumentOutOfRangeException)
            {
                
            }
        }

        
        public virtual void Draw(int leftX, int topY, char symbol)
        {
            try
            {
                Console.SetCursorPosition(leftX, topY);
                Console.Write(symbol);
            }
            catch (ArgumentOutOfRangeException)
            {
                
            }
        }

        
        public bool IsAtPosition(Point other)
        {
            return this.LeftX == other.LeftX && this.TopY == other.TopY;
        }
    }
}