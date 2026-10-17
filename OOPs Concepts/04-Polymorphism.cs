namespace LowLevelDesign;

public class Notification
{
    public virtual void Send()
    {
        Console.WriteLine("Sending a notification.");
    }
}

public class EmailNotification : Notification
{
    //override replaces the base class implementation.
    public override void Send()
    {
        Console.WriteLine("Sending an email notification.");
    }
}

public class SmsNotification : Notification
{
    public override void Send()
    {
        Console.WriteLine("Sending an SMS notification.");
    }
}

public static class PolymorphismDemo
{
    public static void Run()
    {
        //One base class reference can point to different implementations of the Send menthod.

        Notification notification = new EmailNotification();
        notification.Send(); // Output: Sending an email notification.

        notification = new SmsNotification();
        notification.Send(); // Output: Sending an SMS notification.
    }
}

