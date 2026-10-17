namespace LowLevelDesign;

public class BankAccount
{
    private decimal _balance;
    public BankAccount(decimal initialBalance)
    {
        if (initialBalance < 0)
        {
            throw new ArgumentException("Initial balance cannot be negative.");
        }
        _balance = initialBalance;
    }

    //Public property allows reading, but not directly setting, balance.
    public decimal Balance => _balance;

    public void Deposit(decimal amount)
    {
        if(amount<=0)
        {
            throw new ArgumentOutOfRangeException(nameof(amount), "Deposit amount must be positive.");
        }

        //Balances changes only through this validated method.
        _balance += amount;
    }
}

public static class EncapsulationDemo
{
    public static void Run()
    {
        var account = new BankAccount(1000m);
        account.Deposit(500m);
        Console.WriteLine($"Current balance: {account.Balance}");
    }
}