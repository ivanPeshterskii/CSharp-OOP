namespace GameObjects
{
    public class FoodHash : Food
    {
        public FoodHash(int leftX, int topY) : base(leftX, topY)
        {
            Symbol = '#';
            Points = 3;
        }
    }
}