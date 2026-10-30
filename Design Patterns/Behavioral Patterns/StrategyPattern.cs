// Strategy Pattern: Defines a family of algorithms, encapsulates each algorithm separately, and makes them interchangeable at runtime.
// Instead, of writing multiple algorithms inside one class using if-else or switch statements, we create separate classes for each algorithm and allow the client to choose which one to use.

using System;

namespace DesignPatterns.BehavioralPatterns
{
    //Strategy Interface
    public interface IPaymentStrategy
    {
        void Pay(decimal amount);
    }

    //Concrete Strategy 1
    public class CreditCardPayment : IPaymentStrategy
    {
        public void Pay(decimal amount)
        {
            Console.WriteLine($"Paid {amount:C} using Credit Card.");
        }
    }

    //Concrete Strategy 2
    public class UPIPayment : IPaymentStrategy
    {
        public void Pay(decimal amount)
        {
            Console.WriteLine($"Paid {amount:C} using UPI");
        }
    }

    //Concrete Strategy 3
    public class PayPalPayment : IPaymentStrategy
    {
        public void Pay(decimal amount)
        {
            Console.WriteLine($"Paid {amount:C} using PayPal.");
        }
    }

    //Context class
    public class ShoppingCart
    {
        private IPaymentStrategy _paymentStrategy;

        public ShoppingCart(IPaymentStrategy paymentStrategy)
        {
            _paymentStrategy = paymentStrategy ?? throw new ArgumentNullException(nameof(paymentStrategy));
        }

        //Change payment strategy at runtime
        public void SetPaymentStrategy(
            IPaymentStrategy paymentStrategy)
        {
            _paymentStrategy = paymentStrategy ?? throw new ArgumentNullException(nameof(paymentStrategy));
        }

        //Delegate payment processing to selected strategy
        public void Checkkout(decimal amount)
        {
            if (amount <= 0)
            {
                throw new ArgumentException("Payment amount must be greater than zero.");
            }
            _paymentStrategy.Pay(amount);
        }
    }

    //Program Entry Point
    internal class Program
    {
        static void Main(string[] args)
        {
            //Create ShoppingCart with Credit Card strategy
            ShoppingCart cart = new ShoppingCart(new CreditCardPayment());
            cart.Checkkout(1500);

            //Change strategy to UPI at runtime
            cart.SetPaymentStrategy(new UPIPayment());
            cart.Checkkout(2000);

            //Change strategy to PayPal at runtime
            cart.SetPaymentStrategy(new PayPalPayment());
            cart.Checkkout(3500);
        }
    }
}