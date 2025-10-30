namespace ClassBoxData.Models
{
	public class Box
	{
        private const string PropertyExeption = "{0} cannot be zero or negative.";

		private double length;
        private double width;
        private double height;

		public double Length
		{
			get => length;

			private set
			{
				if (value <= 0)
				{
					throw new ArgumentException(string.Format(PropertyExeption, nameof(Length)));
				}

				this.length = value;
			}
		}

        public double Width
        {
            get => width;

            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(string.Format(PropertyExeption, nameof(Width)));
                }

                this.width = value;
            }
        }

        public double Height
        {
            get => height;

            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(string.Format(PropertyExeption, nameof(Height)));
                }

                this.height = value;
            }
        }

        public Box(double length, double width, double height)
		{
            this.Length = length;
            this.Width = width;
            this.Height = height;
		}

        public double SurfaceArea()
        {
            return 2 * (Length * Width) + 2 * (Length * Height) + 2 * (Width*Height);
        }

        public double LateralSurfaceArea()
        {
            return 2 * (Length * Height) + 2*(Width*Height);
        }

        public double Volume()
        {
            return Length * Width * Height;
        }
    }
}