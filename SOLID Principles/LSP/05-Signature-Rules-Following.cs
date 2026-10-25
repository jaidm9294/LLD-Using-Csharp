namespace SOLIDPrinciples.LSP;

public class AnimalForSignatureFollowing
{ }

public class DogForSignatureFollowing : AnimalForSignatureFollowing
{ }

//The contract accepts any Animal.
public class AnimalProcessorFollowing
{
    public virtual void Process(AnimalForSignatureFollowing animal)
    {
        Console.WriteLine("Processing an animal.");
    }
}

//Correct: the parameter type matches the base mathod's signature. The method overrides the existing behavior instead of hiding it.
public class DogProcessorFollowing : AnimalProcessorFollowing
{
    public override void Process(AnimalForSignatureFollowing animal)
    {
        if (animal is DogForSignatureFollowing)
        {
            Console.WriteLine("Processing a dog.");
        }
        else
        {
            //Other animals remain supported by the base contract.
            base.Process(animal);
        }
    }
}

public static class SignatureRulesFollowingDemo
{
    public static void Run()
    {
        //Code can use the derived instance trough the base type.
        AnimalProcessorFollowing processor = new DogProcessorFollowing();

        //Dispatches to the override, which handles this dog specially.
        processor.Process(new DogForSignatureFollowing());

        //It also accepts other animals, as the base contract promises.
        processor.Process(new AnimalForSignatureFollowing());
    }
}