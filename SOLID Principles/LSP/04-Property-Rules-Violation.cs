namespace SOLIDPrinciples.LSP;

//The contract assumes width and height can be changed independently.
public class RectangleForPropertyViolation
{
    public virtual int Width { get; set; }
    public virtual int Height { get; set; }

    public RectangleForPropertyViolation(int width, int height)
    {
        Width = width;
        Height = height;
    }

    public int CalculateArea()
    {
        return Width * Height;
    }
}

//A square requires equal sides, so setting one property also changes the other. This breaks the base property contract.
public class SquareForPropertyViolation : RectangleForPropertyViolation
{
    public SquareForPropertyViolation(int side) : base(side, side)
    { }

    public override int Width
    {
        get => base.Width;
        set
        {
            base.Width = value;
            base.Height = value; // Changing Width also changes Height, violating the base class's contract.
        }
    }

    public override int Height
    {
        get => base.Height;
        set
        {
            base.Height = value;
            base.Width = value; // Changing Height also changes Width, violating the base class's contract.
        }
    }
}

public static class PropertyRulesViolationDemo
{
    //The caller expects setting width to leave height unchanged.
    public static void ResizeWidth(RectangleForPropertyViolation rectangle)
    {
        rectangle.Width = 10;
        rectangle.Height = 5;

        Console.WriteLine($"Width: {rectangle.Width}");
        Console.WriteLine($"Height: {rectangle.Height}");
        Console.WriteLine($"Area: {rectangle.CalculateArea()}");
    }

    public static void Run()
    {
        RectangleForPropertyViolation rectangle = new RectangleForPropertyViolation(4, 6);

        RectangleForPropertyViolation square = new SquareForPropertyViolation(4);

        Console.WriteLine("Ordinary Rectangle:");
        ResizeWidth(rectangle); // Works as expected.

        Console.WriteLine("\nSquare used as a Rectangle:");
        ResizeWidth(square); // Violates the base class's property contract, leading to unexpected behavior.
    }
}