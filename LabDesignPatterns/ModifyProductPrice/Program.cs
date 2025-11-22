using ModifyProductPrice.Models.Enumerables;

namespace ModifyProductPrice;
class Program
{
    static void Main(string[] args)
    {
        var product = new Product("PS5", 1000);

        var modifyPrice = new ModifyPrice();

        modifyPrice.SetCommand(new ProductCommand(product, PriceAction.Increase, 200));
        modifyPrice.SetCommand(new ProductCommand(product, PriceAction.Decrease, 150));

        Console.WriteLine($"Final price: {product.Price}");
    }
}

