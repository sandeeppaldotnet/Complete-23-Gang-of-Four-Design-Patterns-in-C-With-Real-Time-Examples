Decorator Pattern
Definition:
Allows behavior to be added to individual objects dynamically without affecting the behavior of other objects.
Use Case:
Adding features to a coffee order (like milk, sugar) without changing the core Coffee class.
Example:
csharp
Copy code
// Component
public interface ICoffee
{
    double Cost();
    string Description();
}

// Concrete Component
public class SimpleCoffee : ICoffee
{
    public double Cost() => 1.00;
    public string Description() => "Simple Coffee";
}

// Decorator
public abstract class CoffeeDecorator : ICoffee
{
    protected ICoffee _coffee;

    protected CoffeeDecorator(ICoffee coffee) => _coffee = coffee;

    public virtual double Cost() => _coffee.Cost();
    public virtual string Description() => _coffee.Description();
}

// Concrete Decorators
public class MilkDecorator : CoffeeDecorator
{
    public MilkDecorator(ICoffee coffee) : base(coffee) { }

    public override double Cost() => base.Cost() + 0.50;
    public override string Description() => base.Description() + ", Milk";
}

public class SugarDecorator : CoffeeDecorator
{
    public SugarDecorator(ICoffee coffee) : base(coffee) { }

    public override double Cost() => base.Cost() + 0.25;
    public override string Description() => base.Description() + ", Sugar";
}

// Usage
class Program
{
    static void Main()
    {
        ICoffee coffee = new SimpleCoffee();
        Console.WriteLine($"{coffee.Description()} costs {coffee.Cost()}");

        coffee = new MilkDecorator(coffee);
        Console.WriteLine($"{coffee.Description()} costs {coffee.Cost()}");

        coffee = new SugarDecorator(coffee);
        Console.WriteLine($"{coffee.Description()} costs {coffee.Cost()}");
    }
}
