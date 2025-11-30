namespace GameObjects
{
    public class FoodDollar : Food
    {
        public FoodDollar(int leftX, int topY) : base(leftX, topY)
        {
            Symbol = '$';
            Points = 2;
        }
    }
}