using DocumentEditor.Interfaces;
using DocumentEditor.Models;

namespace DocumentEditor.Repositories;

public class InMemoryDocumentRepository : IDocumentRepository
{
    private readonly Dictionary<string, Document> _documents = new();

    public void Save(Document document)
    {
        _documents[document.Title] = CopyDocument(document);
    }

    public Document? GetByTitle(string title)
    {
        if(!_documents.TryGetValue(title, out Document? document))
        {
            return null;
        }

        return CopyDocument(document);
    }

// Copy a document when saving and retrieving it so callers don't receive a direct reference to the repository's internally stored object.
    private static Document CopyDocument(Document document)
    {
        Document copy = new Document(document.Title);
        copy.AddText(document.Content);

        return copy;
    }
}