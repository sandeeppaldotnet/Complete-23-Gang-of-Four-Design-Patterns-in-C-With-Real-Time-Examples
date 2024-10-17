Bridge Pattern
Definition:
Decouples an abstraction from its implementation, allowing them to vary independently.
Use Case:
Developing a drawing application where shapes can be drawn in different styles.
Example:
csharp
Copy code
// Abstraction
public abstract class Shape
{
    protected IDrawingAPI _drawingAPI;

    protected Shape(IDrawingAPI drawingAPI) => _drawingAPI = drawingAPI;

    public abstract void Draw();
}

// Implementation Interface
public interface IDrawingAPI
{
    void DrawCircle(double x, double y, double radius);
}

// Concrete Implementations
public class DrawingAPI1 : IDrawingAPI
{
    public void DrawCircle(double x, double y, double radius) =>
        Console.WriteLine($"Drawing Circle at ({x}, {y}) with radius {radius} using API 1.");
}

public class DrawingAPI2 : IDrawingAPI
{
    public void DrawCircle(double x, double y, double radius) =>
        Console.WriteLine($"Drawing Circle at ({x}, {y}) with radius {radius} using API 2.");
}

// Refined Abstraction
public class Circle : Shape
{
    private double _x, _y, _radius;

    public Circle(double x, double y, double radius, IDrawingAPI drawingAPI) 
        : base(drawingAPI) 
    {
        _x = x;
        _y = y;
        _radius = radius;
    }

    public override void Draw() => _drawingAPI.DrawCircle(_x, _y, _radius);
}

// Usage
class Program
{
    static void Main()
    {
        Shape circle1 = new Circle(5, 10, 2, new DrawingAPI1());
        Shape circle2 = new Circle(5, 10, 2, new DrawingAPI2());

        circle1.Draw();
        circle2.Draw();
    }
}
