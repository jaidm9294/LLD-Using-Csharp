using DocumentEditor.Models;

namespace DocumentEditor.Services;

public class DocumentDisplayService
{
    public void Display(Document document)
    {
        Console.WriteLine();
        Console.WriteLine($"Document Title: {document.Title}");
        Console.WriteLine("-------------------------");

        Console.WriteLine(document.Content);

        Console.WriteLine("---------------------------");
    }
}

// The display logic has its own responsibility. If we want to change the console formatting, we modify DocumentDisplayService, not Document. It follow the SRP.