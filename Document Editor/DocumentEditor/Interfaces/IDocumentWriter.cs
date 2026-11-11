using DocumentEditor.Models;

namespace DocumentEditor.Interfaces;

public interface IDocumentWriter
{
    void Save(Document document);
}