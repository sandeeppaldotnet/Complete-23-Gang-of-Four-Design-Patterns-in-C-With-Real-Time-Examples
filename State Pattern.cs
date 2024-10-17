State Pattern
Definition:
Allows an object to alter its behavior when its internal state changes. The object will appear to change its class.
Use Case:
Implementing a simple traffic light system where the behavior changes based on the light color.
Example:
csharp
Copy code
// State Interface
public interface ITrafficLightState
{
    void Change(TrafficLight light);
}

// Concrete States
public class RedState : ITrafficLightState
{
    public void Change(TrafficLight light)
    {
        Console.WriteLine("Red light - stop.");
        light.SetState(new GreenState());
    }
}

public class GreenState : ITrafficLightState
{
    public void Change(TrafficLight light)
    {
        Console.WriteLine("Green light - go.");
        light.SetState(new YellowState());
    }
}

public class YellowState : ITrafficLightState
{
    public void Change(TrafficLight light)
    {
        Console.WriteLine("Yellow light - caution.");
        light.SetState(new RedState());
    }
}

// Context
public class TrafficLight
{
    private ITrafficLightState _state;

    public TrafficLight()
    {
        _state = new RedState(); // Initial state
    }

    public void SetState(ITrafficLightState state) => _state = state;
    
    public void Change() => _state.Change(this);
}

// Usage
class Program
{
    static void Main()
    {
        var light = new TrafficLight();

        for (int i = 0; i < 6; i++)
        {
            light.Change();
        }
    }
}
