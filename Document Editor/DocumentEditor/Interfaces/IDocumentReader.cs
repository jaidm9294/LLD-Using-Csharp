using DocumentEditor.Models;

namespace DocumentEditor.Interfaces;

public interface IDocumentReader
{
    Document? GetByTitle(string title);
}
