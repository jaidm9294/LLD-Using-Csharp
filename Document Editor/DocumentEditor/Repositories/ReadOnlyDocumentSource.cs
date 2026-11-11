using DocumentEditor.Interfaces;
using DocumentEditor.Models;

namespace DocumentEditor.Repositories;

public class ReadOnlyDocumentSource : IDocumentReader
{
    private readonly Dictionary<string, Document> _documents = new();

    public ReadOnlyDocumentSource(IEnumerable<Document> documents)
    {
        foreach (Document document in documents)
        {
            _documents[document.Title] = CopyDocument(document);
        }
    }

    public Document? GetByTitle(string title)
    {
        if (!_documents.TryGetValue(title, out Document? document))
        {
            return null;
        }

        return CopyDocument(document);
    }

    private static Document CopyDocument(Document document)
    {
        Document copy = new Document(document.Title);
        copy.AddText(document.Content);

        return copy;
    }
}