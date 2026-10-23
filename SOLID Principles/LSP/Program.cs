namespace SOLIDPrinciples.LSP;

public static class Program
{
    public static void Main()
    {
        Console.WriteLine("=== LSP Violation ===");
        LspViolationDemo.Run();

        Console.WriteLine("\n=== Following LSP ===");
        LspFollowingDemo.Run();

        Console.WriteLine("\n=== Method Rules Violation ===");
        MethodRulesViolationDemo.Run();

        Console.WriteLine("\n=== Following Method Rules ===");
        MethodRulesFollowingDemo.Run();
    }
}