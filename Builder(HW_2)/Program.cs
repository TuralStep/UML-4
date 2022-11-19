namespace Builder_HW_2;


public class Engine { };
public class SportEngine : Engine { };

class Car {}
class Manual {}


interface IBuilder
{

    void Reset();
    void SetSeats(int number);
    void SetEngine(Engine engine);
    void SetTripComputer();
    void SetGPS();

}

class CarBuilder : IBuilder
{

    private Car _car;

    public void Reset() =>
        this._car = new Car();

    public void SetSeats(int number) =>
        Console.WriteLine($"Add {number} seat(s)...");

    public void SetEngine(Engine engine) =>
        Console.WriteLine($"Add {engine} engine...");

    public void SetTripComputer() =>
        Console.WriteLine($"Add a trip computer instruction...");

    public void SetGPS() =>
        Console.WriteLine($"Add a GPS instruction...");

    public Car GetResult() =>
        this._car;
}

class ManualBuilder : IBuilder
{

    private Manual _manual;

    public void Reset() =>
        this._manual = new Manual();

    public void SetSeats(int number) =>
        Console.WriteLine($"Add {number} seat(s)...");

    public void SetEngine(Engine engine) =>
        Console.WriteLine($"Add {engine} engine...");

    public void SetTripComputer() =>
        Console.WriteLine($"Add a trip computer instruction...");

    public void SetGPS() =>
        Console.WriteLine($"Add a GPS instruction...");

    public Manual GetResult() =>
        this._manual;
}



class Director
{
    public void MakeSUV(IBuilder builder) { }

    public void MakeSportsCar(IBuilder builder)
    {
        builder.Reset();
        builder.SetSeats(2);
        builder.SetEngine(
            new SportEngine());
        builder.SetTripComputer();
        builder.SetGPS();
    }
}



class Client
{
    public void Start()
    {
        Director dir = new();
        CarBuilder builder = new();
        dir.MakeSportsCar(builder);
        Car car = builder.GetResult();
    }
}