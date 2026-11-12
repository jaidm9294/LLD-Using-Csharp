// Adapter Pattern - Allows two incompatible interfaces to work together.
// Suppose, our application expects an object with a particular interface, but we have an existing class that provides similar functionality through a different interface. Instead of modifying the existing class, we create an Adapter that converts the existing interface into the interface expected by our application.

using System;

namespace DesignPatterns.StructuralPatterns
{
    // Target interface
    // This is the interface our application expects.
    public interface IPaymentProcessor
    {
        void ProcessPayment(double amount);
    }

    // Adaptee - existing third-party class with an incompatible interface
    public class LegacyPaymentGateway
    {
        public void MakePayment(double amount)
        {
            Console.WriteLine($"Payment of Rs.{amount} processes using Legacy Payment Gateway.");
        }
    }

    // Adpter - converts the LegacyPaymentGateway interface into the IPaymentProcessor interface.
    public class PaymentGatewayAdapter : IPaymentProcessor
    {
        private readonly LegacyPaymentGateway _legacyPaymentGateway;

        public PaymentGatewayAdapter(LegacyPaymentGateway legacyPaymentGateway)
        {
            _legacyPaymentGateway = legacyPaymentGateway;
        }

        public void ProcessPayment(double amount)
        {
            Console.WriteLine("Adapter: Converting payment request...");

            //Calling the existing method through the adapter.
            _legacyPaymentGateway.MakePayment(amount);
        }
    }

    // Client - It works only with the target interface.
    public class PaymentService
    {
        private readonly IPaymentProcessor _paymentProcessor;

        public PaymentService(IPaymentProcessor paymentProcessor)
        {
            _paymentProcessor = paymentProcessor;
        }

        public void MakePayment(double amount)
        {
            Console.WriteLine("Payment Service: Initiating payment...");

            _paymentProcessor.ProcessPayment(amount);
        }
    }

    public class Program
    {
        public static void Main(string[] args)
        {
            // Existing third-party payment gateway.
            LegacyPaymentGateway legacyGateway = new LegacyPaymentGateway();

            // Creating an adapter for the legacy gateway.
            IPaymentProcessor paymentAdapter = new PaymentGatewayAdapter(legacyGateway);

            // Client receives the expected interface.
            PaymentService paymentService = new PaymentService(paymentAdapter);

            //Processing payment.
            paymentService.MakePayment(1500);
        }
    }
}