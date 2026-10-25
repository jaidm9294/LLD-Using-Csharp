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

        Console.WriteLine("\n=== Violating Property Rules ===");
        PropertyRulesViolationDemo.Run();

        Console.WriteLine("\n=== Following Property Rules ===");
        PropertyRulesFollowingDemo.Run();

        Console.WriteLine("\n=== Violating Signature Rules ===");
        SignatureRulesViolationDemo.Run();

        Console.WriteLine("\n=== Following Signature Rules ===");
        SignatureRulesFollowingDemo.Run();

    }
}