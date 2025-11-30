using Prototype.Models;

namespace Prototype;
class Program
{
    static void Main(string[] args)
    {
        SandwichMenu menu = new SandwichMenu();

        menu["BLT"] = new Sandwich("Wheat", "Bacon","Lettuce", "Tomato");

        Sandwich sandwich = menu["BLT"].Clone() as Sandwich;

        Console.ReadKey();
    }
}

