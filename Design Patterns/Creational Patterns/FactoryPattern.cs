//Factory Pattern is a creational design approach that centralizes object creation so that client code does not need to know the concrete class being instantiated. 
// Without a factory, the client code may need to decide which class to instantiate and how to create it. 

using System;

namespace DesignPatterns.CreationalPatterns
{
    //Common interface for all notification types
    public interface INotification
    {
        void Send(string message);
    }

    //Concrete product 1
    public class EmailNotification : INotification
    {
        public void Send(string message)
        {
            Console.WriteLine($"Sending Email: {message}");
        }
    }

    //Concrete product 2
    public class SMSNotification : INotification
    {
        public void Send(string message)
        {
            Console.WriteLine($"Sending SMS: {message}");
        }
    }

    //Concrete product 3
    public class WhatsAppNotification : INotification
    {
        public void Send(string message)
        {
            Console.WriteLine($"Sending WhatsApp Message: {message}");
        }
    }

    //Factory responsible for creating notification objects
    public static class NotificationFactory
    {
        public static INotification CreateNotification(string type)
        {
            return type.Trim().ToLowerInvariant() switch
            {
                "email" => new EmailNotification(),
                "sms" => new SMSNotification(),
                "whatsapp" => new WhatsAppNotification(),
                _ => throw new ArgumentException($"Unsupported notification type: {type}", nameof(type))
            };
        }
    }

    //Program entry point
    internal class program
    {
        static void Main(string[] args)
        {
            //Create an Email notification
            INotification email = NotificationFactory.CreateNotification("email");
            email.Send("Welcome to our application");

            //Create an SMS notification
            INotification sms = NotificationFactory.CreateNotification("sms");
            sms.Send("Your verfication code is 2006");

            //Create a WhatsApp notification
            INotification whatsapp = NotificationFactory.CreateNotification("whatsapp");
            whatsapp.Send("Thanks for joining our group!");
        }
    }
}