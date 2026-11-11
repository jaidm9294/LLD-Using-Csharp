namespace DocumentEditor.Models;

public class Document
{
    //Content can be read from outside the class, but it can't be modified directly.
    public string Title { get; private set; }
    public string Content { get; private set; }

    public Document(string title)
    {
        Title = title;
        Content = string.Empty;
    }

// Modification happen through the AddText() method.
    public void AddText(string text)
    {
        Content += text;
    }


    // Below part is moved to the Services folder, now Document class is responsible for maintaining the document title, content and modifying the content. It no loonger knows how the document should be displayed.
    // public void Display()
    // {
    //     Console.WriteLine($"Document Title: {Title}");
    //     Console.WriteLine("---------------------");
    //     Console.WriteLine(Content);
    //     Console.WriteLine("---------------------");
    // }
}