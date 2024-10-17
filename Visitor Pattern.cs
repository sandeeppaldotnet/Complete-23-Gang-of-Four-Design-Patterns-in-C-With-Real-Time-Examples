Visitor Pattern
Definition:
Separates an algorithm from the object structure on which it operates. Allows adding new operations to existing object structures without modifying them.
Use Case:
Calculating taxes for different product types in a shopping cart.
Example:
csharp
Copy code
// Visitor Interface
public interface IShoppingCartVisitor
{
    void Visit(Book book);
    void Visit(Fruit fruit);
}

// Element Interface
public interface IShoppingCartElement
{
    void Accept(IShoppingCartVisitor visitor);
}

// Concrete Elements
public class Book : IShoppingCartElement
{
    public double Price { get; }
    
    public Book(double price) => Price = price;

    public void Accept(IShoppingCartVisitor visitor) => visitor.Visit(this);
}

public class Fruit : IShoppingCartElement
{
    public double Price { get; }
    
    public Fruit(double price) => Price = price;

    public void Accept(IShoppingCartVisitor visitor) => visitor.Visit(this);
}

// Concrete Visitor
public class ShoppingCart : IShoppingCartVisitor
{
    private double _total;

    public void Visit(Book book) => _total += book.Price * 0.9; // 10% discount on books
    public void Visit(Fruit fruit) => _total += fruit.Price; // No discount

    public double GetTotal() => _total;
}

// Usage
class Program
{
    static void Main()
    {
        var items = new List<IShoppingCartElement>
        {
            new Book(20),
            new Fruit(5)
        };

        var cart = new ShoppingCart();
        foreach (var item in items)
        {
            item.Accept(cart);
        }

        Console.WriteLine($"Total: {cart.GetTotal()}");
    }
}
