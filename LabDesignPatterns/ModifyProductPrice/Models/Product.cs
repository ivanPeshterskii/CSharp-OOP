public class Product
{
    public string Name { get; set; }
    public int Price { get; private set; }

    public Product(string name, int price)
    {
        Name = name;
        Price = price;
    }

    public void IncreasePrice(int amount)
    {
        Price += amount;
        Console.WriteLine($"{Name} price increased by {amount}. New price: {Price}");
    }

    public void DecreasePrice(int amount)
    {
        Price -= amount;
        Console.WriteLine($"{Name} price decreased by {amount}. New price: {Price}");
    }
}