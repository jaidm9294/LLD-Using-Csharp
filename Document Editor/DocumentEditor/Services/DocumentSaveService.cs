using DocumentEditor.Interfaces;
using DocumentEditor.Models;

namespace DocumentEditor.Services;

public class DocumentSaveService
{
    private readonly IDocumentWriter _documentWriter;

    public DocumentSaveService(IDocumentWriter documentWriter)
    {
        _documentWriter = documentWriter;
    }

    public void Save(Document document)
    {
        _documentWriter.Save(document);
    }
}