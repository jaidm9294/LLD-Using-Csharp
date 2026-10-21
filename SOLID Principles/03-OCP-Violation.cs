namespace SOLIDPrinciples;

//This class calculates discounts for different customer types.
//The design violates OCP bcz adding a new type of customer requires modifying the exisintg method.

public class DiscountCalculatorViolation
{
    public decimal CalculateDiscount(string customerType, decimal amount)
    {
        //Different customer types have different discount rules.
        if (customerType == "Regular")
        {
            return amount * 0.10m; //10% discount for regular customers
        }
        else if (customerType == "Premium")
        {
            return amount * 0.20m; //20% discount for premium customers
        }
        else if (customerType == "VIP")
        {
            return amount * 0.30m; //30% discount for VIP customers
        }
        else
        {
            return 0; //No discount for other customer types
        }
    }
}
//This class demonstrates the OCP violation.
public static class OcpViolationDemo
{
    public static void Run()
    {
        var calculator = new DiscountCalculatorViolation();
        decimal regularDiscount = calculator.CalculateDiscount("Regular", 1000m);
        decimal premiumDiscount = calculator.CalculateDiscount("Premium", 1000m);
        decimal vipDiscount = calculator.CalculateDiscount("VIP", 1000m);
        decimal otherDiscount = calculator.CalculateDiscount("Other", 1000m);

        Console.WriteLine($"Regular Customer Discount: {regularDiscount:C}");
        Console.WriteLine($"Premium Customer Discount: {premiumDiscount:C}");
        Console.WriteLine($"VIP Customer Discount: {vipDiscount:C}");
        Console.WriteLine($"Other Customer Discount: {otherDiscount:C}");

        //Problem:
        //To support a new customer type, we need to modify the existing DiscountCalculatorViolation class, which violates the Open/Closed Principle.
    }
}
