namespace SOLIDPrinciples;

//The interface defines a common contract for all discount strategies.
//New discount types can implement this interface without changing the existing  calculator.

public interface IDiscountStrategy
{
    decimal CalculateDiscount(decimal amount);
}

//Strategy for regular customers.
public class RegularCustomerDiscount : IDiscountStrategy
{
    public decimal CalculateDiscount(decimal amount)
    {
        return amount * 0.10m; //10% discount for regular customers
    }
}

//Strategy for premium customers.
public class PremiumCustomerDiscount : IDiscountStrategy
{
    public decimal CalculateDiscount(decimal amount)
    {
        return amount * 0.20m; //20% discount for premium customers
    }
}

//Strategy for VIP customers.
public class VipCustomerDiscount : IDiscountStrategy
{
    public decimal CalculateDiscount(decimal amount)
    {
        return amount * 0.30m; //30% discount for VIP customers
    }
}

//This class depends on the abstraction (interface), not on specific customer types. Its implementation does not need to change when a new discount strategy is added, following to the Open/Closed Principle.
public class DiscountCalculator
{
    public decimal CalculateDiscount(IDiscountStrategy discountStrategy, decimal amount)
    {
        //Polymorphism calls the appropriate strategy implementation.
        return discountStrategy.CalculateDiscount(amount);
    }
}

//Demonstates the OCP_following implementation.
public static class OcpFollowingDemo
{
    public static void Run()
    {
        var calculator = new DiscountCalculator();

        //Pass the desired discount strategy to the calculator.
        IDiscountStrategy regularStrategy = new RegularCustomerDiscount();
        IDiscountStrategy premiumStrategy = new PremiumCustomerDiscount();
        IDiscountStrategy vipStrategy = new VipCustomerDiscount();
        Console.WriteLine($"Regular Customer Discount: {calculator.CalculateDiscount(regularStrategy, 1000m):C}");
        Console.WriteLine($"Premium Customer Discount: {calculator.CalculateDiscount(premiumStrategy, 1000m):C}");
        Console.WriteLine($"VIP Customer Discount: {calculator.CalculateDiscount(vipStrategy, 1000m):C}");
        //To add another customer category, create a new class implementing IDiscountStrategy. No changes are needed in the existing DiscountCalculator class, following the Open/Closed Principle.

    }
}
