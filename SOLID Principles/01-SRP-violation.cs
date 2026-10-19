namespace SOLIDPrinciples;
//This class has several unrealted responsibilities:
//1. Holding invoice data
//2. Calculating the total
//3. Printing the invoice
//4. Saving the invoice

public class InvoiceViolation
{
    public string CustomerName {get; set;}
    public decimal Amount {get; set;}
    public decimal TaxRate {get; set;}

    public InvoiceViolation(string customerName, decimal amount, decimal taxRate)
    {
        CustomerName = customerName;
        Amount = amount;
        TaxRate = taxRate;
    }

    //Responsibility: business calculation
    public decimal CalculateTotal()
    {
        return Amount + (Amount * TaxRate);
    }

    //Responsibility: presenation/output
    public void PrintInvoice()
    {
        Console.WriteLine($"Invoice for: {CustomerName}");
        Console.WriteLine($"Amount: {Amount:C}");
        Console.WriteLine($"Tax: {(Amount * TaxRate) :C}");
        Console.WriteLine($"Total: {CalculateTotal():C}");
    }

    //Responsibility: persistence
    //This demo writes to a file to illustrate the responsibility; production code would typically use an injected repository.
    public void SaveToFile()
    {
        string invoiceText = 
           $"Customer: {CustomerName}{Environment.NewLine}" +
           $"Amount: {Amount:C}{Environment.NewLine}" +
           $"Tax: {(Amount * TaxRate):C}{Environment.NewLine}" +
           $"Total: {CalculateTotal():C}{Environment.NewLine}";
        File.WriteAllText("invoice-violation.txt", invoiceText);
        Console.WriteLine("INvoice saved to invoice-violation.txt");
    }
}

public static class SrpViolationDemo
{
    public static void Run()
    {
        var invoice = new InvoiceViolation("Aryan", 1000m, 0.15m);
        //one object calculates, prints, and saves: too many reasons to change.
        invoice.PrintInvoice();
        invoice.SaveToFile();
    }
}