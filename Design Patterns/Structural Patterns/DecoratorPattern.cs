// Decorator Pattern : Allows us to dynamically add new reponsibilities or functionality to an object without modifying its existing class.
// Instead of changing an existing class or creating many subclasses, we wrap an object inside another object that adds extra functionality.

using System;

namespace DesignPatterns.StructuralPatterns
{
    // 1. Component Interface
    public interface ICoffee
    {
        string GetDescription();
        decimal GetCost();
    }

    // 2. Concrete Component
    public class BasicCoffee : ICoffee
    {
        public string GetDescription()
        {
            return "Basic Coffee";
        }
        public decimal GetCost()
        {
            return 100m;
        }
    }

    // 3. Abstract Decorator
    public abstract class CoffeeDecorator : ICoffee
    {
        protected readonly ICoffee _coffee; // decorator contains another component that it can enhance
        protected CoffeeDecorator(ICoffee coffee)
        {
            _coffee = coffee ?? throw new ArgumentNullException(nameof(coffee));
        }

        public virtual string GetDescription()
        {
            return _coffee.GetDescription();
        }

        public virtual decimal GetCost()
        {
            return _coffee.GetCost();
        }
    }

    // 4. Concrete Decorator - Milk
    public class MilkDecorator : CoffeeDecorator
    {
        public MilkDecorator(ICoffee coffee) : base(coffee) { }

        public override string GetDescription()
        {
            return _coffee.GetDescription() + ", Milk";
        }

        public override decimal GetCost()
        {
            return _coffee.GetCost() + 20m;
        }
    }

    // 5. Concrete Decorator - Sugar
    public class SugarDecorator : CoffeeDecorator
    {
        public SugarDecorator(ICoffee coffee) : base(coffee) { }

        public override string GetDescription()
        {
            return _coffee.GetDescription() + ", Sugar";
        }

        public override decimal GetCost()
        {
            return _coffee.GetCost() + 10m;
        }
    }

    // 6. Concrete Decorator - Whiped Cream
    public class WhippedCreamDecorator : CoffeeDecorator
    {
        public WhippedCreamDecorator(ICoffee coffee) : base(coffee) { }

        public override string GetDescription()
        {
            return _coffee.GetDescription() + ", Whipped Cream";
        }

        public override decimal GetCost()
        {
            return _coffee.GetCost() + 30m;
        }
    }

    // 7. Program Entry Point
    internal class Program
    {
        static void Main(string[] args)
        {
            //Start with basic coffee
            ICoffee coffee = new BasicCoffee();

            Console.WriteLine($"{coffee.GetDescription()} = ₹{coffee.GetCost()}");

            // Add Milk
            coffee = new MilkDecorator(coffee);

            Console.WriteLine($"{coffee.GetDescription()} = ₹{coffee.GetCost()}");

            // Add Sugar
            coffee = new SugarDecorator(coffee);

            Console.WriteLine($"{coffee.GetDescription()} = ₹{coffee.GetCost()}");

            // Add Whipped Cream
            coffee = new WhippedCreamDecorator(coffee);

            Console.WriteLine($"{coffee.GetDescription()} = ₹{coffee.GetCost()}");
        }
    }
}