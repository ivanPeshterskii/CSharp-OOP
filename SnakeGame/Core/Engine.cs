using System;
using System.Collections.Generic;
using System.Threading;
using GameObjects;
using SnakeGame.Enums;

namespace Core
{
    public class Engine
    {
        private readonly Wall wall;
        private readonly Snake snake;
        private readonly Dictionary<Direction, Point> directions;
        private Direction currentDirection = Direction.Right;
        private int defaultSleep = 100;

        public Engine(Wall wall, Snake snake)
        {
            this.wall = wall;
            this.snake = snake;
            GameObjects.ProgramWallHolder.WallInstance = wall;
            directions = InitializeDirections();
            snake.InitializeFoods(wall);
            Console.CursorVisible = false;
        }

        private Dictionary<Direction, Point> InitializeDirections()
        {
            return new Dictionary<Direction, Point>
            {
                { Direction.Right, new Point(1, 0) },
                { Direction.Left, new Point(-1, 0) },
                { Direction.Up, new Point(0, -1) },
                { Direction.Down, new Point(0, 1) }
            };
        }

        public void Run()
        {
            while (true)
            {
                if (Console.KeyAvailable)
                {
                    var key = Console.ReadKey(true);
                    currentDirection = GetNextDirection(key, currentDirection);
                }

                var dirPoint = directions[currentDirection];

                bool isAlive = snake.IsMoving(dirPoint, wall);
                if (!isAlive)
                {
                    AskUserForRestart();
                }

                Thread.Sleep(defaultSleep);
            }
        }

        private Direction GetNextDirection(ConsoleKeyInfo keyInfo, Direction current)
        {
            switch (keyInfo.Key)
            {
                case ConsoleKey.LeftArrow:
                    if (current != Direction.Right) return Direction.Left;
                    break;
                case ConsoleKey.RightArrow:
                    if (current != Direction.Left) return Direction.Right;
                    break;
                case ConsoleKey.UpArrow:
                    if (current != Direction.Down) return Direction.Up;
                    break;
                case ConsoleKey.DownArrow:
                    if (current != Direction.Up) return Direction.Down;
                    break;
                case ConsoleKey.Escape:
                    StopGame();
                    break;
            }
            return current;
        }

        private void AskUserForRestart()
        {
            Console.SetCursorPosition(10, 12);
            Console.Write("Would you like to continue? y/n");
            while (true)
            {
                var key = Console.ReadKey(true);
                if (key.Key == ConsoleKey.Y)
                {
                    Console.Clear();
                   
                    var newWall = new Wall(wallLeft(), wallTop());
                    var newSnake = new Snake();
                    var engine = new Engine(newWall, newSnake);
                    engine.Run(); 
                    return;
                }
                else if (key.Key == ConsoleKey.N)
                {
                    StopGame();
                }
            }
        }

        private int wallLeft()
        {
            return wall.LeftX + 1; 
        }

        private int wallTop()
        {
            return wall.TopY + 1; 
        }

        private void StopGame()
        {
            Console.Clear();
            Console.SetCursorPosition(10, 10);
            Console.WriteLine("Game Over");
            Environment.Exit(0);
        }
    }
}
