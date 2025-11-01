namespace Shapes
{
	public class Rectangle : Shape
	{
        private int height;
        private int width;

        public int Height
        {
            get
            {
                return this.height;
            }
            private set
            {
                this.height = value;
            }
        }

        public int Width
        {
            get
            {
                return this.width;
            }
            private set
            {
                this.width = value;
            }
        }

        public Rectangle(int height, int width)
		{
            this.Height = height;
            this.Width = width;
		}

        public override double CalculateArea()
        {
            return this.Height * this.Width;
        }

        public override double CalculatePerimeter()
        {
            return 2 * (this.Height + this.Width);
        }

        public override string Draw()
        {
            return base.Draw();
        }
    }
}