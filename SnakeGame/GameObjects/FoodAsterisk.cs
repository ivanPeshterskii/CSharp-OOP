namespace GameObjects
{
    public class FoodAsterisk : Food
    {
        public FoodAsterisk(int leftX, int topY) : base(leftX, topY)
        {
            Symbol = '*';
            Points = 1;
        }
    }
}