using System;


public abstract class Product
{
    public abstract string Operation();
}


public class ConcreteProduct1 : Product
{
    public override string Operation()
    {
        return "{Result of the ConcreteProduct1}";
    }
}

public class ConcreteProduct2 : Product
{
    public override string Operation()
    {
        return "{Result of the ConcreteProduct2}";
    }
}


public abstract class Creator
{
    public abstract Product FactoryMethod();

    public string SomeOperation()
    {
        // Call the factory method to create a Product object.
        Product product = FactoryMethod();
        // Now, use the product.
        return "Creator: The same creator's code has just worked with " + product.Operation();
    }
}

public class ConcreteCreator1 : Creator
{
    public override Product FactoryMethod()
    {
        return new ConcreteProduct1();
    }
}

public class ConcreteCreator2 : Creator
{
    public override Product FactoryMethod()
    {
        return new ConcreteProduct2();
    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("App: Launched with the ConcreteCreator1.");
        ClientCode(new ConcreteCreator1());
        Console.WriteLine();

        Console.WriteLine("App: Launched with the ConcreteCreator2.");
        ClientCode(new ConcreteCreator2());
    }

    static void ClientCode(Creator creator)
    {
        Console.WriteLine("Client: I'm not aware of the creator's class," +
            "but it still works.\n" + creator.SomeOperation());
    }
}
