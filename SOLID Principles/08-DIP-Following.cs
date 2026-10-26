//Dependency Injection Principle : High-level modules shoud not depend directly on low-level modules. Both should depend on abstractions. Abstractions should not depend on details. Details should depend on abstractions.

namespace SOLIDPrinciples;

// Abstraction: the high-level module depends on this interface, not on a specific notification service.
public interface INotificationService
{
    void SendNotification(string message);
}

//Low-level implementation: sends notifications through email.
public class EmailNotificationService : INotificationService
{
    public void SendNotification(string message)
    {
        Console.WriteLine($"Sending email: {message}");
    }
}

// Another low-level implementation: sends notifications through SMS.
public class SmsNotificationService : INotificationService
{
    public void SendNotification(string message)
    {
        Console.WriteLine($"Sending SMS: {message}");
    }
}

//High-level module: contains the order-processing business logic.
public class OrderProcessorFollowing
{
    private readonly INotificationService _notificationService;

    //Dependency Injection: the caller supplies the implementation. OrderProcessorFollowing depends on an abstraction, not Email or SMS.
    public OrderProcessorFollowing(INotificationService notificationService)
    {
        _notificationService = notificationService;
    }

    public void ProcessOrder()
    {
        Console.WriteLine("Processing order...");

        //Uses the abstraction without knowing the delivery mechanism.
        _notificationService.SendNotification("Your order has been processed.");
    }
}

public static class DipFollowingDemo
{
    public static void Run()
    {
        // Inject the email implementation.
        INotificationService emailService = new EmailNotificationService();

        var emailOrderProcessor = new OrderProcessorFollowing(emailService);

        emailOrderProcessor.ProcessOrder();

        Console.WriteLine();

        //Switch to SMS without changing OrderProcessorFollowing.
        INotificationService smsService = new SmsNotificationService();

        var smsOrderProcessor = new OrderProcessorFollowing(smsService);

        smsOrderProcessor.ProcessOrder();
    }
}