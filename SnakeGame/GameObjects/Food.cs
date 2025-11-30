using System;
using System.Collections.Generic;

namespace GameObjects
{
    public abstract class Food : Point
    {
        protected readonly Random rnd = new Random();
        public int Points { get; protected set; }
        public char Symbol { get; protected set; }

        protected Food(int leftX, int topY) : base(leftX, topY)
        {
        }

        
        public virtual void SetRandomPosition(Queue<Point> snakeParts, Wall wall)
        {
            int leftX;
            int topY;
            do
            {
                leftX = rnd.Next(1, wallLeft(wall)); 
                topY = rnd.Next(1, wallTop(wall));
            }
            while (IsOnSnake(leftX, topY, snakeParts));

            this.LeftX = leftX;
            this.TopY = topY;

            
            var prevBg = Console.BackgroundColor;
            
            Draw(Symbol);
            Console.BackgroundColor = prevBg;
        }

        private int wallLeft(Wall wall) => wall.LeftX;
        private int wallTop(Wall wall) => wall.TopY;

        private bool IsOnSnake(int x, int y, Queue<Point> snakeParts)
        {
            foreach (var p in snakeParts)
            {
                if (p.LeftX == x && p.TopY == y)
                    return true;
            }
            return false;
        }

        public bool IsFoodPoint(Point snakeHead)
        {
            return this.LeftX == snakeHead.LeftX && this.TopY == snakeHead.TopY;
        }
    }
}