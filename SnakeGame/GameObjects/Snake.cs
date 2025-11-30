using System;
using System.Collections.Generic;
using System.Linq;
using SnakeGame.Enums;

namespace GameObjects
{
    public class Snake
    {
        private Queue<Point> snakeParts;
        private readonly char snakeSymbol = 'O';
        private readonly Random rnd = new Random();
        private List<Food> foods;
        private int score;
        private int sleepTime = 100;

        public Snake()
            : base()
        {
            snakeParts = new Queue<Point>();
            CreateSnake();
            GetFoods();
        }

        
        private void CreateSnake()
        {
            
            int startX = 10;
            int startY = 10;

            for (int i = 1; i <= 6; i++)
            {
                snakeParts.Enqueue(new Point(startX + i, startY));
            }

            
            foreach (var p in snakeParts)
            {
                p.Draw(snakeSymbol);
            }
        }

        
        private void GetFoods()
        {
            foods = new List<Food>
            {
                new FoodAsterisk(0,0),
                new FoodDollar(0,0),
                new FoodHash(0,0)
            };
        }

        
        public static Point DirectionToPoint(Direction dir)
        {
            switch (dir)
            {
                case Direction.Left:
                    return new Point(-1, 0);
                case Direction.Right:
                    return new Point(1, 0);
                case Direction.Up:
                    return new Point(0, -1);
                case Direction.Down:
                    return new Point(0, 1);
                default:
                    return new Point(0, 0);
            }
        }

        
        private Point GetHead()
        {
            return snakeParts.Last();
        }

        
        private Point GetNextPoint(Point direction, Point head)
        {
            int nextX = head.LeftX + direction.LeftX;
            int nextY = head.TopY + direction.TopY;
            return new Point(nextX, nextY);
        }

        
        public bool IsMoving(Point direction, Wall wall)
        {
            Point head = GetHead();
            Point nextPoint = GetNextPoint(direction, head);

            
            foreach (var part in snakeParts)
            {
                if (part.LeftX == nextPoint.LeftX && part.TopY == nextPoint.TopY)
                {
                    return false;
                }
            }

            
            if (wall.IsPointOfWall(nextPoint))
            {
                return false;
            }

            
            snakeParts.Enqueue(nextPoint);
            nextPoint.Draw(snakeSymbol);

            
            var food = foods.FirstOrDefault(f => f.IsFoodPoint(nextPoint));
            if (food != null)
            {
                Eat(food);
            }
            else
            {
                
                var tail = snakeParts.Dequeue();
                tail.Draw(' ');
            }

            
            System.Threading.Thread.Sleep(sleepTime);
            return true;
        }

        
        private void Eat(Food food)
        {
            score += food.Points;

            
            for (int i = 0; i < (food.Points - 1); i++)
            {
                
                var head = GetHead();
                snakeParts.Enqueue(new Point(head.LeftX, head.TopY));
            }

            
            int idx = rnd.Next(foods.Count);
            foods[idx].SetRandomPosition(snakeParts, ProgramWallHolder.WallInstance);
            
        }

        
        public void InitializeFoods(Wall wall)
        {
            foreach (var f in foods)
            {
                f.SetRandomPosition(snakeParts, wall);
            }
        }
    }

    
    internal static class ProgramWallHolder
    {
        public static Wall WallInstance;
    }
}
