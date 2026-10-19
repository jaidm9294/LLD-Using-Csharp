namespace SOLIDPrinciples;

//Responsibility: represent invoice data.
//Changes to invoice data shape belong here.

public class Invoice
{
    public string CustomerName { get; }
    public decimal Amount { get; }
    public decimal TaxRate { get; }

    public Invoice(string customerName, decimal amount, decimal taxRate)
    {
        CustomerName = customerName;
        Amount = amount;
        TaxRate = taxRate;
    }
}

//Responsibility: calculate invoice totals only.
public class InvoiceCalculator
{
    public decimal CalculateTotal(Invoice invoice)
    {
        return invoice.Amount + (invoice.Amount * invoice.TaxRate);
    }
}

//Responsibility: format and display invoice informantion only.
public class InvoicePrinter
{
    private readonly InvoiceCalculator _calculator;
    public InvoicePrinter(InvoiceCalculator calculator)
    {
        _calculator = calculator;
    }

    public void Print(Invoice invoice)
    {
        decimal tax = invoice.Amount * invoice.TaxRate;
        decimal total = _calculator.CalculateTotal(invoice);

        Console.WriteLine($"Invoice for: {invoice.CustomerName}");
        Console.WriteLine($"Amount: {invoice.Amount:C}");
        Console.WriteLine($"Tax: {tax:C}");
        Console.WriteLine($"Total: {total:C}");
    }
}

//Responsibility: save invoice to file only.
public class InvoiceRepository
{
    private readonly InvoiceCalculator _calculator;

    public InvoiceRepository(InvoiceCalculator calculator)
    {
        _calculator = calculator;
    }

    public void SaveToFile(Invoice invoice)
    {
        decimal tax = invoice.Amount * invoice.TaxRate;
        decimal total = _calculator.CalculateTotal(invoice);

        string invoiceText =
              $"Customer: {invoice.CustomerName}{Environment.NewLine}" +
                $"Amount: {invoice.Amount:C}{Environment.NewLine}" +
                $"Tax: {tax:C}{Environment.NewLine}" +
                $"Total: {total:C}{Environment.NewLine}";

        File.WriteAllText("invoice-srp.txt", invoiceText);
        Console.WriteLine("Invoice saved to invoice-srp.txt");
    }
}

public static class SrpFollowDemo
{
    public static void Run()
    {
        var invoice = new Invoice("Yuvraj", 1000m, 0.15m);
        var calculator = new InvoiceCalculator();

        //Each object has a focused responsibility: calculate, print, or save.
        var printer = new InvoicePrinter(calculator);
        var repository = new InvoiceRepository(calculator);

        printer.Print(invoice);
        repository.SaveToFile(invoice);
    }
}