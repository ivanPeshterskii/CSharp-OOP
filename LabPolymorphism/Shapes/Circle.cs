namespace Shapes
{
	public class Circle : Shape
	{
        private int radius;

        public int Radius
        {
            get
            {
                return this.radius;
            }
            private set
            {
                this.radius = value;
            }
        }

		public Circle(int radius)
		{
            this.Radius = radius;
		}

        public override double CalculateArea()
        {
            return Math.PI * this.Radius * this.Radius;
        }

        public override double CalculatePerimeter()
        {
            return 2 * Math.PI * this.Radius;
        }

        public override string Draw()
        {
            return base.Draw();
        }
    }
}

