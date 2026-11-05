using DocumentEditor.Models;
namespace DocumentEditor.Services;

public class DocumentSaveService
{
    public void Save(Document document)
    {
        string directoryPath = "Documents";

        Directory.CreateDirectory(directoryPath);  // Creates the Documents directory if doesn't already exist.

        string fileName = $"{document.Title}.txt";  //Genrates the filename

        string filePath = Path.Combine(directoryPath, fileName);  //Constructs the file path, combines the directory and filename using the appropriate path separator for the OS

        File.WriteAllText(filePath, document.Content);

        Console.WriteLine($"Document saved successfully at: {filePath}");
    }
}