
public abstract class Flyweight
{
    public abstract void Operation(int extrinsicstate);
}


public class ConcreteFlyweight : Flyweight
{
    public override void Operation(int extrinsicstate)
    {
        Console.WriteLine("ConcreteFlyweight: " + extrinsicstate);
    }
}


public class UnsharedConcreteFlyweight : Flyweight
{
    public override void Operation(int extrinsicstate)
    {
        Console.WriteLine("UnsharedConcreteFlyweight: " + extrinsicstate);
    }
}


public class FlyweightFactory
{
    private Dictionary<string, Flyweight> flyweights = new Dictionary<string, Flyweight>();

    // Constructor
    public FlyweightFactory()
    {
        flyweights.Add("A", new ConcreteFlyweight());
        flyweights.Add("B", new ConcreteFlyweight());
        flyweights.Add("C", new ConcreteFlyweight());
    }

    public Flyweight GetFlyweight(string key)
    {
        return ((Flyweight)flyweights[key]);
    }
}

public class Program
{
    public static void Main()
    {
        // Arbitrary extrinsic state
        int extrinsicstate = 22;

        FlyweightFactory factory = new FlyweightFactory();

        // Work with different flyweight instances
        Flyweight fx = factory.GetFlyweight("A");
        fx.Operation(--extrinsicstate);

        Flyweight fy = factory.GetFlyweight("B");
        fy.Operation(--extrinsicstate);

        Flyweight fz = factory.GetFlyweight("C");
        fz.Operation(--extrinsicstate);

        UnsharedConcreteFlyweight fu = new UnsharedConcreteFlyweight();
        fu.Operation(--extrinsicstate);
    }
}
