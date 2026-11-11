using DocumentEditor.Models;

namespace DocumentEditor.Interfaces;

//This interface defines a contract
public interface IDocumentRepository
{
    void Save(Document document);
}