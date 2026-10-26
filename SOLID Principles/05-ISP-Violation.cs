namespace SOLIDPrinciples;

//This interface combines multiple capabilities into one large interface. Not every machine supports every operation.
public interface IMachine
{
    void Print(string document);
    void Scan(string document);
    void Fax(string document);
}

// A basic printer only supports printing. However, it is forced to implement all IMachine methods.
public class BasicPrinter : IMachine
{
    public void Print(string document)
    {
        Console.WriteLine($"Printing document: {document}");
    }

    public void Scan(string document)
    {
        // A basic printer cannot scan. Throwing an exception exposes the interface design problem.
        throw new NotSupportedException("BasicPrinter does not support scanning");
    }

    public void Fax(string document)
    {
        // A basic printer cannot send faxes either.
        throw new NotSupportedException("BasicPrinter does not support faxing");
    }
}

//Demonstrates the Interfcae Segregation Principle violation.
public static class IspViolationDemo
{
    public static void Run()
    {
        IMachine printer = new BasicPrinter();

        //This operation works.
        printer.Print("Report.pdf");

        //These operations are available on the interface but unsupported by this implementation, so they fail at runtime.
        try
        {
            printer.Scan("Report.pdf");
        }
        catch (NotSupportedException ex)
        {
            Console.WriteLine($"ISP violation: {ex.Message}");
        }
    }
}