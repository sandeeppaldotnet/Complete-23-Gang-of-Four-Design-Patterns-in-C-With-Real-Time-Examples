Template Method Pattern
Definition:
Defines the skeleton of an algorithm in a method, deferring some steps to subclasses. Template Method lets subclasses redefine certain steps of an algorithm without changing the algorithm's structure.
Use Case:
Creating a framework for a cooking recipe where each recipe has steps, but specific details can be implemented in subclasses.
Example:
csharp
Copy code
// Abstract Class
public abstract class Recipe
{
    public void Cook()
    {
        GatherIngredients();
        Prepare();
        CookMethod();
        Serve();
    }

    protected abstract void GatherIngredients();
    protected abstract void Prepare();
    protected abstract void CookMethod();
    
    private void Serve() => Console.WriteLine("Serving the dish.");
}

// Concrete Class
public class PastaRecipe : Recipe
{
    protected override void GatherIngredients()
    {
        Console.WriteLine("Gathering pasta, sauce, and cheese.");
    }

    protected override void Prepare()
    {
        Console.WriteLine("Boiling pasta and preparing sauce.");
    }

    protected override void CookMethod()
    {
        Console.WriteLine("Cooking pasta with sauce.");
    }
}

// Usage
class Program
{
    static void Main()
    {
        var pastaRecipe = new PastaRecipe();
        pastaRecipe.Cook();
    }
}
