namespace SOLIDPrinciples.LSP;

//Base class cantains only behavior common to all birds.
public abstract class Birds
{
    public abstract void Eat();
}

//This interface represents the ability to fly. Only birds that can actually fly should implement it.
public interface IFlyable
{
    void Fly();
}

//Sparrow is a bird that can fly.
public class Sparrow : Birds, IFlyable
{
    public override void Eat()
    {
        Console.WriteLine("Sparrow is eating seeds.");
    }

    public void Fly()
    {
        Console.WriteLine("Sparrow is flying.");
    }
}

//Penguin is a bird, but it does not implement IFlyable.
public class Penguins : Birds
{
    public override void Eat()
    {
        Console.WriteLine("Penguin is eating fish.");
    }
    //No Fly() method is required because penguins cannot fly.
}

public static class LspFollowingDemo
{
    //This method accepts only objects that support flying.
    public static void MakeBirdFly(IFlyable bird)
    {
        bird.Fly();
    }

    public static void Run()
    {
        Birds sparrow = new Sparrow();
        Birds penguin = new Penguins();

        //Both subclasses can safely substitute for Bird.
        sparrow.Eat(); 
        penguin.Eat();

        //Only flying birds can be passed to MakeBirdFly().
        IFlyable flyableSparrow = new Sparrow();
        MakeBirdFly(flyableSparrow); 

        // A Penguin cannot accidentally be apssed to MakeBirdFly() because it does not implement IFlyable.
    }
}