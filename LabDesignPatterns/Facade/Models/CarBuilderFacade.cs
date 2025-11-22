using Facade.Models;

public class CarBuilderFacade
{
    protected Car car;

    public CarBuilderFacade()
    {
        car = new Car();
    }

    public CarInfoBuilder Info => new CarInfoBuilder(car);

    public CarAddressBuilder Address => new CarAddressBuilder(car);

    public Car Build() => car;
}