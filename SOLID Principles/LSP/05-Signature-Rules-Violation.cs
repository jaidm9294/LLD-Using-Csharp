namespace SOLIDPrinciples.LSP;

public class AnimalForSignatureRules
{ }
public class DogForSignatureRules : AnimalForSignatureRules
{ }

//The base contract accepts any Animal.
public class AnimalProcessor
{
    public virtual void Process(AnimalForSignatureRules animal)
    {
        Console.WriteLine("Processing an animal.");
    }
}

// This class does not override Process(AnimalForSignatureRules). It declares a separate overload that accepts only Dog.
public class DogProcessorViolation : AnimalProcessor
{
    public new void Process(DogForSignatureRules dog)
    {
        //This method is available only when the argument is a Dog and the expression's compile-time type exposes this overload.
        Console.WriteLine("Processing a dog.");
    }
}

public static class SignatureRulesViolationDemo
{
    public static void Run()
    {
        //The reference type is AnimalProcessor.
        AnimalProcessor processor = new DogProcessorViolation();

        //The base method is called because the derived method did not override the base method's signature.
        processor.Process(new DogForSignatureRules());
    }
}
