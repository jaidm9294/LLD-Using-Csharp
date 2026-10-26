// Interface Segregation Principle: Clients should not be forced to depend on interfaces they do not use.

namespace SOLIDPrinciples;

//Each interface represents one focused capability.
public interface IPrinter
{
    void Print(string document);
}

public interface IScanner
{
    void Scan(string document);
}

public interface IFax
{
    void Fax(string document);
}

//BasicPrinter only implements printing because that is all it supports.
public class BasicPrinterFollowing : IPrinter
{
    public void Print(string document)
    {
        Console.WriteLine($"Printing document: {document}");
    }
}

//MultiFunctionPrinter supports all three capabilities.
public class MultiFuntionPrinter : IPrinter, IScanner, IFax
{
    public void Print(string document)
    {
        Console.WriteLine($"Scanning document: {document}");
    }

    public void Scan(string document)
    {
        Console.WriteLine($"Scanning document: {document}");
    }

    public void Fax(string document)
    {
        Console.WriteLine($"Faxing document: {document}");
    }
}

//Demonstrates the Interface Segregation Principle.
public static class IspFollowingDemo
{
    public static void Run()
    {
        // A basic printer is exposed only through its printing capability.
        IPrinter basicPrinter = new BasicPrinterFollowing();
        basicPrinter.Print("Report.pdf");

        // A multifunction printer can be used through each supported capability, without forcing other devices to implement them.
        var multiFunctionPrinter = new MultiFuntionPrinter();

        IPrinter printer = multiFunctionPrinter;
        IScanner scanner = multiFunctionPrinter;
        IFax fax = multiFunctionPrinter;

        printer.Print("Invoice.pdf");
        scanner.Scan("Scanned.pdf");
        fax.Fax("Faxed.pdf");
    }
}