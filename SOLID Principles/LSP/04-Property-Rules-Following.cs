namespace SOLIDPrinciples.LSP;

//The common contract exposes only the behavior shared by both shapes. It does not proise independently mutable width and height properties.
public interface IAreaShape
{
    int CalculateArea();
}

// A rectangle has independently defined width and height.
public class RectangleForPropertyRules : IAreaShape
{
    public int Width { get; }
    public int Height { get; }

    public RectangleForPropertyRules(int width, int height)
    {
        Width = width;
        Height = height;
    }

    public int CalculateArea()
    {
        return Width * Height;
    }
}

// A square has one side length, preserving its own invariant.
public class SquareForPropertyRules : IAreaShape
{
    public int Side { get; }

    public SquareForPropertyRules(int side)
    {
        Side = side;
    }

    public int CalculateArea()
    {
        return Side * Side;
    }
}

public static class PropertyRulesFollowingDemo
{
    //The caller depends only on the shared area contract.
    public static void PrintArea(IAreaShape shape)
    {
        Console.WriteLine($"Area: {shape.CalculateArea()}");
    }

    public static void Run()
    {
        IAreaShape rectangle = new RectangleForPropertyRules(10, 5);
        IAreaShape square = new SquareForPropertyRules(5);

        PrintArea(rectangle);
        PrintArea(square);
    }
}