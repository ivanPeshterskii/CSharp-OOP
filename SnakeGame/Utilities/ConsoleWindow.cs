using System;

namespace Utilities
{
    public static class ConsoleWindow
    {
        public static void SetupConsole()
        {
            Console.CursorVisible = false;
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.Title = "Snake Game - SoftUni Workshop";
            
            try
            {
                Console.SetWindowSize(100, 30);
                Console.SetBufferSize(100, 30);
            }
            catch
            {
                
            }
        }
    }
}