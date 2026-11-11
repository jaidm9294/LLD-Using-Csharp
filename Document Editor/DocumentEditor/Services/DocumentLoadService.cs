using DocumentEditor.Interfaces;
using DocumentEditor.Models;

namespace DocumentEditor.Services;

public class DocumentLoadService
{
    private readonly IDocumentReader _documentReader;

    public DocumentLoadService(IDocumentReader documentReader)
    {
        _documentReader = documentReader;
    }

    public Document? Load(string title)
    {
        return _documentReader.GetByTitle(title);
    }
}