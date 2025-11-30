using System;
using Core;
using GameObjects;
using Utilities;

namespace SnakeGame
{
    internal class StartUp
    {
        static void Main()
        {
            ConsoleWindow.SetupConsole();
            Wall wall = new Wall(80, 25);
            Snake snake = new Snake();
            Engine engine = new Engine(wall, snake);
            engine.Run();
        }
    }
}