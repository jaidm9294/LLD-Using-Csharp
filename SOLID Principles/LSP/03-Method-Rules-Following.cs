namespace SOLIDPrinciples.LSP;

//The base class defines the withdrawal contract.
public class BankAccountForMethodRules
{
    public decimal Balance { get; protected set; }

    public BankAccountForMethodRules(decimal balance)
    {
        Balance = balance;
    }

    public virtual void Withdraw(decimal amount)
    {
        if (amount <= 0 || amount > Balance)
        {
            throw new ArgumentException("Amount must be positive and within the available balance.");
        }

        Balance -= amount;
    }
}

//This subtype does not add stricter withdrawal conditions. It preserves the base class behavior.

public class PremiumBankAccount : BankAccountForMethodRules
{
    public PremiumBankAccount(decimal balance) : base(balance)
    { }

    //Inheriting Withdraw() preserves the base contract. Other premium features can be added without restricting the withdrawal behavior promised by the base class.
}

public static class MethodRulesFollowingDemo
{
    public static void Run()
    {
        //The base type can safely refer to a derived account.
        BankAccountForMethodRules account = new PremiumBankAccount(2000m);

        account.Withdraw(1000m);

        Console.WriteLine($"Withdrawal successful. Remaining balance: {account.Balance}");
    }
}