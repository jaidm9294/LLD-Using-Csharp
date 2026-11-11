using DocumentEditor.Interfaces;
using DocumentEditor.Models;
namespace DocumentEditor.Services;

public class DocumentSaveService
{
    // Service depends on an abstraction rather than concrete implementation
    private readonly IDocumentRepository _documentRepository;

    public DocumentSaveService(IDocumentRepository documentRepository)
    {
        _documentRepository = documentRepository;
    }
    public void Save(Document document)
    {
        _documentRepository.Save(document);
    }
}