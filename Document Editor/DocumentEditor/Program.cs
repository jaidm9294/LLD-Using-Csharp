namespace DocumentEditor;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("==== DOCUMENT EDITOR ====");

        Console.WriteLine("Enter document title: ");
        string title = Console.ReadLine() ?? "Untitled";

        Document document = new Document(title);

        bool isRunning = true;

        while (isRunning)
        {
            Console.WriteLine("\n==== MENU ====");
            Console.WriteLine("1. Add Text");
            Console.WriteLine("2. Display Document");
            Console.WriteLine("3. Exit");
            Console.WriteLine("Enter your choice: ");

            string choice = Console.ReadLine() ?? string.Empty;

            switch (choice)
            {
                case "1":
                    Console.WriteLine("Enter text: ");
                    string text = Console.ReadLine() ?? string.Empty;

                    document.AddText(text);
                    Console.WriteLine("Text added successfully.");
                    break;

                case "2":
                    document.Display();
                    break;

                case "3":
                    isRunning = false;
                    Console.WriteLine("Exiting Document Editor...");
                    break;

                default:
                    Console.WriteLine("Invalid choice. Please try again");
                    break;
            }
        }
    }
}