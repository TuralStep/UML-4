namespace Adapter;


interface ITwoSideCharger
{
    void UseCharger();   
}


class AzerbaijanPowerSocket : ITwoSideCharger
{
    public void UseCharger() =>
        Console.WriteLine("Works in AzerbaijanPowerSocket...");
}

class TurkeyPowerSocket : ITwoSideCharger
{
    public void UseCharger() =>
        Console.WriteLine("Works in TurkeyPowerSocket...");
}


class AmericaPowerSocket
{
    public void ChargerUsed() =>
        Console.WriteLine("Works in AmericaPowerSocket...");
}


class ChargerAdapter : ITwoSideCharger
{
    private readonly AmericaPowerSocket? apc = null;

    public ChargerAdapter()
    {
        apc = new AmericaPowerSocket();
    }

    public void UseCharger()
    {
        apc?.ChargerUsed();
    }
}



class Program
{
    static void Main()
    {
        List<ITwoSideCharger> chargers = new()
        {
            new AzerbaijanPowerSocket(),
            new TurkeyPowerSocket(),
            new ChargerAdapter(),
            new AzerbaijanPowerSocket(),
            new ChargerAdapter(),
        };

        foreach (var charger in chargers)
            charger.UseCharger();

    }
}