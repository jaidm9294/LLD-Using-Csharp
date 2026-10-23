namespace SOLIDPrinciples.LSP;

//The base class permits withdrawls up to the available balance.
public class BankAccountForMethodViolation
{
    public decimal Balance { get; protected set; }

    public BankAccountForMethodViolation(decimal balance)
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

//This subclass strengthens the precondition by imposing an additional limit of 500 pr w.
public class LimitedBankAccount : BankAccountForMethodViolation
{
    public LimitedBankAccount(decimal balance) : base(balance)
    { }

    public override void Withdraw(decimal amount)
    {
        //The base class would allow this withdrawal if the balance is sufficient, but this subclass rejects it.
        if (amount > 500)
        {
            throw new ArgumentException("This account allows only 500 per withdrawal.");
        }
        base.Withdraw(amount);
    }
}

public static class MethodRulesViolationDemo
{
    public static void Run()
    {
        BankAccountForMethodViolation account = new LimitedBankAccount(2000m);

        // A caller expects to withdraw 1000, because the balance is sufficient , according to the base class's contract. 
        try
        {
            account.Withdraw(1000m); // This will throw an exception due to the subclass's stricter rule.
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine($"Method Rule Violation Error: {ex.Message}");
        }
    }
}