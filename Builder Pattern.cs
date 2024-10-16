Builder Pattern
Definition:
Separates the construction of a complex object from its representation, allowing the same construction process to create different representations.
Use Case:
Building complex objects like a pizza with various toppings.
Example:


// Product
public class Pizza
{
    public string Dough { get; set; }
    public string Sauce { get; set; }
    public List<string> Toppings { get; } = new List<string>();

    public override string ToString() =>
        $"Pizza with {Dough} dough, {Sauce} sauce and toppings: {string.Join(", ", Toppings)}";
}

// Builder Interface
public interface IPizzaBuilder
{
    void SetDough(string dough);
    void SetSauce(string sauce);
    void AddTopping(string topping);
    Pizza Build();
}

// Concrete Builder
public class MargheritaPizzaBuilder : IPizzaBuilder
{
    private Pizza _pizza = new Pizza();

    public void SetDough(string dough) => _pizza.Dough = dough;
    public void SetSauce(string sauce) => _pizza.Sauce = sauce;
    public void AddTopping(string topping) => _pizza.Toppings.Add(topping);
    public Pizza Build() => _pizza;
}

// Director
public class PizzaDirector
{
    private readonly IPizzaBuilder _builder;

    public PizzaDirector(IPizzaBuilder builder) => _builder = builder;

    public Pizza ConstructMargheritaPizza()
    {
        _builder.SetDough("Thin Crust");
        _builder.SetSauce("Tomato");
        _builder.AddTopping("Mozzarella");
        return _builder.Build();
    }
}

// Usage
class Program
{
    static void Main()
    {
        IPizzaBuilder builder = new MargheritaPizzaBuilder();
        PizzaDirector director = new PizzaDirector(builder);
        Pizza pizza = director.ConstructMargheritaPizza();
        Console.WriteLine(pizza);
    }
}
