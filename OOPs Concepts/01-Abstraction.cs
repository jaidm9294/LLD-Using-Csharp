namespace LowLevelDesign;

//abstract class defines a common contract for all shapes.
public abstract class Shape
{
    //Derived classes must provide their own implementation for area calculation.
    public abstract double CalculateArea();
}

//CircleShape class inherits from Shape and provides its own implementation for area calculation.
public class CircleShape: Shape
{
    private readonly double _radius;
    public CircleShape(double radius)
    {
        _radius = radius;
    }

    public override double CalculateArea()
    {
        return Math.PI * _radius * _radius;
    }
}

public static class AbstractionDemo
{
    public static void Run()
    {
        //interact with shape through its public method.
        Shape circle = new CircleShape(5);
        double area = circle.CalculateArea();
        Console.WriteLine($"Area of the circle: {area}");
    }
}