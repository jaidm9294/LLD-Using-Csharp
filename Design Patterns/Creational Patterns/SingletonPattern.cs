//Singleton Pattern : It ensures that a class has only one instance and provides a global access point to that instance.
// Common examples include: Application configuration managers, Logging services, Shared in-memory caches.

using System;

namespace DesignPatterns.CreationalPatterns
{
    //Singleton Class
    public sealed class AppConfiguration
    {
        //One lazily initialized instance, readonly prevents reassignment of the holder after initialization.
        private static readonly Lazy<AppConfiguration> _instance = new Lazy<AppConfiguration>(() => new AppConfiguration());

        //Public access point
        public static AppConfiguration Instance => _instance.Value;

        //Private constructor prevents external instantiation
        private AppConfiguration()
        {
            Console.WriteLine("AppConfiguration instance created.");
        }

        //Example property 
        public string ApplicationName { get; set; } = "My Application";

        //Example method
        public void DisplayConfiguration()
        {
            Console.WriteLine($"Application Name: {ApplicationName}");
        }
    }

    //Program entry point
    internal class Program
    {
        static void Main(String[] args)
        {
            //Access the Singleton instance
            AppConfiguration config1 = AppConfiguration.Instance;

            config1.DisplayConfiguration();
            Console.WriteLine();

            //Access the instance again
            AppConfiguration config2 = AppConfiguration.Instance;
            config2.ApplicationName = "Design Patterns Project";
            config2.DisplayConfiguration();
            Console.WriteLine();

            //Check whether both variables reference the same object
            Console.WriteLine($"Are both instances the same? {ReferenceEquals(config1, config2)}");

            Console.WriteLine($"Same object hash code? {config1.GetHashCode() == config2.GetHashCode()}");
        }
    }
}