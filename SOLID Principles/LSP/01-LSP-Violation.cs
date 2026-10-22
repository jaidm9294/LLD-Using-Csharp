namespace SOLIDPrinciples.LSP;

//Base class assumes that every bird can fly. This assumption is incorrect for some bird species.
public class Bird
{
    public virtual void Fly()
    {
        Console.WriteLine("The bird is flying.");
    }
}

//Penguin is a Bird, but it cannot fly. Therefore, it cannot fulfill the base class's behavior.
public class Penguin : Bird
{
    public override void Fly()
    {
        //This exception reveals the design problem: code expecting any bird to fly can now fail.
        throw new NotSupportedException("Penguins cannot fly.");
    }
}

public static class LspViolationDemo
{
    public static void MakeBirdFly(Bird bird)
    {
        //This method assumes every bird supports flying.
        bird.Fly(); 
    }

    public static void Run()
    {
        Bird sparrow = new Bird();
        Bird penguin = new Penguin();

        //Works for the ordinary Bird implementation.
        MakeBirdFly(sparrow); 

        //Throws NotSupportedException at runtime. Penguin cannot safely substitute for a flying bird.
        try
        {
            MakeBirdFly(penguin); 
        }
        catch (NotSupportedException ex)
        {
            Console.WriteLine($"LSP Violation Error: {ex.Message}");
        }
    }
}