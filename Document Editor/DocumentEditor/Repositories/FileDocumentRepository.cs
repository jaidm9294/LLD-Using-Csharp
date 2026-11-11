using DocumentEditor.Interfaces;
using DocumentEditor.Models;

namespace DocumentEditor.Repositories;

public class FileDocumentRepository : IDocumentRepository
{
    // Passing the directory path through constructor rather than hardcoding it inside the saving method
    private readonly string _directoryPath;

    public FileDocumentRepository(string directoryPath)
    {
        _directoryPath = directoryPath;
    }

    public void Save(Document document)
    {
        Directory.CreateDirectory(_directoryPath);

        string fileName = $"{document.Title}.txt";
        string filePath = Path.Combine(_directoryPath, fileName);

        File.WriteAllText(filePath, document.Content);  //saving the document
    }

    public Document? GetByTitle(string title)
    {
        string fileName = $"{title}.txt";
        string filePath = Path.Combine(_directoryPath, fileName);

        if (!File.Exists(filePath))
        {
            return null;
        }

        string content = File.ReadAllText(filePath);

        Document document = new Document(title);
        document.AddText(content);

        return document;
    }
}