using System;
using System.Collections.Generic;

namespace GameObjects
{
    public class Wall : Point
    {
        private readonly int width;
        private readonly int height;
        private const char WallSymbol = '\u25A0'; // ■
        private HashSet<(int x, int y)> borderPoints;

        public Wall(int width, int height) : base(width - 1, height - 1)
        {
            this.width = width;
            this.height = height;
            borderPoints = new HashSet<(int x, int y)>();
            InitializeWallBorders();
        }

        private void InitializeWallBorders()
        {
            
            SetHorizontalLine(0);
            SetHorizontalLine(height - 1);

            
            SetVerticalLine(0);
            SetVerticalLine(width - 1);
        }

        
        private void SetHorizontalLine(int topY)
        {
            for (int x = 0; x < width; x++)
            {
                Draw(x, topY, WallSymbol);
                borderPoints.Add((x, topY));
            }
        }

        
        private void SetVerticalLine(int leftX)
        {
            for (int y = 0; y < height; y++)
            {
                Draw(leftX, y, WallSymbol);
                borderPoints.Add((leftX, y));
            }
        }

        
        public bool IsPointOfWall(Point point)
        {
            return borderPoints.Contains((point.LeftX, point.TopY));
        }
    }
}