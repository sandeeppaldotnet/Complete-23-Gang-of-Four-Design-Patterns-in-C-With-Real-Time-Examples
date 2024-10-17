Iterator Pattern
Definition:
Provides a way to access the elements of an aggregate object sequentially without exposing its underlying representation.
Use Case:
Iterating over a collection of items, like a list of products.
Example:
csharp
Copy code
// Iterator Interface
public interface IIterator<T>
{
    bool HasNext();
    T Next();
}

// Aggregate Interface
public interface IAggregate<T>
{
    IIterator<T> CreateIterator();
}

// Concrete Iterator
public class ProductIterator : IIterator<Product>
{
    private readonly ProductCollection _collection;
    private int _current = 0;

    public ProductIterator(ProductCollection collection) => _collection = collection;

    public bool HasNext() => _current < _collection.Count;

    public Product Next() => _collection[_current++];
}

// Product Class
public class Product
{
    public string Name { get; }

    public Product(string name) => Name = name;
}

// Concrete Aggregate
public class ProductCollection : IAggregate<Product>
{
    private readonly List<Product> _products = new List<Product>();

    public void Add(Product product) => _products.Add(product);
    public int Count => _products.Count;
    public Product this[int index] => _products[index];

    public IIterator<Product> CreateIterator() => new ProductIterator(this);
}

// Usage
class Program
{
    static void Main()
    {
        var collection = new ProductCollection();
        collection.Add(new Product("Product 1"));
        collection.Add(new Product("Product 2"));
        collection.Add(new Product("Product 3"));

        var iterator = collection.CreateIterator();
        while (iterator.HasNext())
        {
            Console.WriteLine(iterator.Next().Name);
        }
    }
}
