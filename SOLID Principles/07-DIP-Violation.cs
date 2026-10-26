namespace SOLIDPrinciples;

//Low-level module: responsible for sending email notifications.
public class EmailService
{
    public void SendEmail(string message)
    {
        Console.WriteLine($"Sending email: {message}");
    }
}

//High-level module: handles order processing.
public class OrderProcessor
{
    //DIP violation: OrderProcessor directly depends on EmailService. It cannot easily switch to SMS or another notification service.
    private readonly EmailService _emailService = new EmailService();

    public void ProcessOrder()
    {
        Console.WriteLine("Processing order...");

        //Direct dependency on a concrete implementation.
        _emailService.SendEmail("Your order has been processed.");
    }
}

public static class DipViolationDemo
{
    public static void Run()
    {
        var orderProcessor = new OrderProcessor();
        orderProcessor.ProcessOrder();
    }
}