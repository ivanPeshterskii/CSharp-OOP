namespace Facade;
class Program
{
    static void Main(string[] args)
    {
        var car = new CarBuilderFacade()
            .Info
                .WithType("BMW")
                .WithColor("Black")
            .Address
                .InCity("Berlin")
                .WithStreet("Street 12")
            .Build();

        Console.WriteLine(car);

        Console.ReadKey();
    }
}

