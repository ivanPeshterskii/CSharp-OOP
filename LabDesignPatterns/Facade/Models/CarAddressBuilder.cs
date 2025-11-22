using Facade.Models;

public class CarAddressBuilder : CarBuilderFacade
{
    public CarAddressBuilder(Car car)
    {
        this.car = car;
    }

    public CarAddressBuilder InCity(string city)
    {
        car.City = city;
        return this;
    }

    public CarAddressBuilder WithStreet(string street)
    {
        car.Street = street;
        return this;
    }
}


